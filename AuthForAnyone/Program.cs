using System.Reflection;
using AuthForAnyone.ExceptionHandler;
using AuthForAnyone.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddControllers();
builder.Services.AddExceptionHandler<GlobalExceptionHandler>();
builder.Services.AddProblemDetails();
builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureServices();
builder.Services.ConfigureRepositories();
builder.Services.ConfigureIdentities();
builder.Services.ConfigureAutoMapper();
builder.Services.ConfigureJwtBearer(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandler();

app.MapControllers();

app.Run();
