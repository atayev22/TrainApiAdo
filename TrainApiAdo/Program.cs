using BLog.IServices;
using BLog.Services;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Repo.IRepositories;
using Repo.Repositories;
using AutoMapper;
using BLog.Helper;
using DataAccess.Entities;
using DTO;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Filters;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region BLog

builder.Services.AddScoped<ITransportListService, TransportListService>();
builder.Services.AddScoped<IUserService<User, UserDTO>, UserService>();
builder.Services.AddScoped<IUserListService, UserListService>();
builder.Services.AddScoped<IOrderListService, OrderListService>();
builder.Services.AddScoped<ISubjectService, SubjectService>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

#endregion

#region Json

builder.Services.AddControllers().AddNewtonsoftJson(x => 
            x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

builder.Services.AddControllers().AddNewtonsoftJson();
#endregion

#region Mapper
var mapConfiq = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperProfile());
});

builder.Services.AddSingleton(mapConfiq.CreateMapper());

#endregion

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
        {
            options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
            {
                Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
                In = ParameterLocation.Header,
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            options.OperationFilter<SecurityRequirementsOperationFilter>();
        });

#region JwtToken



builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(builder.Configuration.GetSection("AppSetings:Token").Value)),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
