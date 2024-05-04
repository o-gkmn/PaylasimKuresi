using AutoMapper;
using Models.DTOs.CommentDTOs;
using Models.DTOs.CommentLikeDTOs;
using Models.DTOs.CommunityDTOs;
using Models.DTOs.CommunityUserDTOs;
using Models.DTOs.DmDTOs;
using Models.DTOs.FollowDTOs;
using Models.DTOs.GroupDTOs;
using Models.DTOs.GroupUserDTOs;
using Models.DTOs.ImagePostDTOs;
using Models.DTOs.PostDTOs;
using Models.DTOs.PostLikeDTOs;
using Models.DTOs.RoleDTOs;
using Models.DTOs.TextPostDTOs;
using Models.DTOs.UserDTOs;
using Models.DTOs.VideoPostDTOs;
using Models.DTOs.VoicePostDTOs;
using Models.Entities;

namespace Shared.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            //Comment Map
            CreateMap<CreateCommentDto, Comment>();
            CreateMap<UpdateCommentDto, Comment>();
            CreateMap<GetCommentDto, Comment>().ReverseMap();

            //CommentLike Map
            CreateMap<CreateCommentLikeDto, CommentLike>();
            CreateMap<UpdateCommentLikeDto, CommentLike>();
            CreateMap<GetCommentLikeDto, CommentLike>().ReverseMap();

            //Community Map
            CreateMap<CreateCommunityDto, Community>();
            CreateMap<UpdateCommunityDto, Community>();
            CreateMap<GetCommunityDto, Community>().ReverseMap();

            //CommunityUser Map
            CreateMap<CreateCommunityUserDto, CommunityUser>();
            CreateMap<UpdateCommunityUserDto, CommunityUser>();
            CreateMap<GetCommunityUserDto, CommunityUser>();

            //Dm Map
            CreateMap<CreateDmDto, Dm>();
            CreateMap<UpdateDmDto, Dm>();
            CreateMap<GetDmDto, Dm>().ReverseMap();

            //Follow Map
            CreateMap<CreateFollowDto, Follow>();
            CreateMap<UpdateFollowDto, Follow>();
            CreateMap<GetFollowDto, Follow>().ReverseMap();

            //Group Map
            CreateMap<CreateGroupDto, Group>();
            CreateMap<UpdateGroupDto, Group>();
            CreateMap<GetGroupDto, Group>().ReverseMap();

            //GroupUser Map
            CreateMap<CreateGroupUserDto, GroupUser>();
            CreateMap<UpdateGroupUserDto, GroupUser>();
            CreateMap<GetGroupUserDto, GroupUser>().ReverseMap();

            //ImagePost Map
            CreateMap<CreateImagePostDto, ImagePost>();
            CreateMap<UpdateImagePostDto, ImagePost>();
            CreateMap<GetImagePostDto, ImagePost>().ReverseMap();

            //Post Map
            CreateMap<CreatePostDto, Post>();
            CreateMap<UpdatePostDto, Post>();
            CreateMap<GetPostDto, Post>().ReverseMap();

            //PostLike Map
            CreateMap<CreatePostLikeDto, PostLike>();
            CreateMap<UpdatePostLikeDto, PostLike>();
            CreateMap<GetPostLikeDto, PostLike>().ReverseMap();

            //Role Map
            CreateMap<CreateRoleDto, Role>();
            CreateMap<UpdateRoleDto, Role>();
            CreateMap<GetRoleDto, Role>().ReverseMap();

            //TextPost Map
            CreateMap<CreateTextPostDto, TextPost>();
            CreateMap<UpdateTextPostDto, TextPost>();
            CreateMap<GetTextPostDto, TextPost>().ReverseMap();

            //User Map
            CreateMap<SignInUserDto, User>();
            CreateMap<CreateUserDto, User>()
                .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => DateTime.Parse(src.DateOfBirth))); ;
            CreateMap<UpdateUserDto, User>();
            CreateMap<GetUserDto, User>().ReverseMap();

            //VideoPost
            CreateMap<CreateVideoPostDto, VideoPost>();
            CreateMap<UpdateVideoPostDto, VideoPost>();
            CreateMap<GetVideoPostDto, VideoPost>().ReverseMap();

            //VoicePost
            CreateMap<CreateVoicePostDto, VoicePost>();
            CreateMap<UpdateVoicePostDto, VoicePost>();
            CreateMap<GetVoicePostDto, VoicePost>().ReverseMap();
        }
    }
}
