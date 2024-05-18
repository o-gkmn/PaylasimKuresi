using System.Collections.Concurrent;
using System.Text.Json;
using AutoMapper;
using Business.PaylasimKuresi.Interfaces.UserServices;
using Microsoft.AspNetCore.SignalR;
using Models.DTOs.DmDTOs;

namespace Business.PaylasimKuresi.Hubs;

public class MessageHub : Hub
{
    private static readonly ConcurrentDictionary<string, string> Users = new ConcurrentDictionary<string, string>();
    private readonly IUserService _userService;
    private readonly IMapper _mapper;

    public MessageHub(IUserService userService, IMapper mapper)
    {
        _userService = userService;
        _mapper = mapper;
    }

    public void Register(string username)
    {
        Users[Context.ConnectionId] = username;
    }

    public async Task SendMessageToUser(string json)
    {
        var getDmDto = JsonSerializer.Deserialize<GetDmDto>(json);
        if (getDmDto == null)
            return;
        var receiverDto = await _userService.GetAsync(u => u.Id == getDmDto.ReceiverID);
        if (receiverDto == null)
            return;

        var senderDto = await _userService.GetAsync(u => u.Id == getDmDto.SenderID);
        if (senderDto == null)
            return;

        foreach (var user in Users)
        {
            if (user.Value == receiverDto.UserName)
            {
                await Clients.Client(user.Key).SendAsync("ReceiveMessage", getDmDto, receiverDto);
            }
        }
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        // Try to remove the user from the dictionary
        if (Users.TryRemove(Context.ConnectionId, out var username))
        {
            await Clients.All.SendAsync("UserDisconnected", username);
        }

        await base.OnDisconnectedAsync(exception);
    }
}
