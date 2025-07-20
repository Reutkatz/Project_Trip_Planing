
using Google.Apis.Gmail.v1;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using TripPlaning.API.Controllers;
using TripPlaning.API.Mapping;
using TripPlaning.Core.Mapping;
using TripPlaning.Core.Repositories;
using TripPlaning.Core.Service;
using TripPlaning.Data;
using TripPlaning.Data.Repositories;
using TripPlaning.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Name = "Authorization",
    Description = "Bearer Authentication with JWT Token",
    Type = SecuritySchemeType.Http
});

options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITrailService, TrailService>();
builder.Services.AddScoped<ITrailRepository, TrailRepository>();
builder.Services.AddScoped<ITripService, TripService>();
builder.Services.AddScoped<ITripRepository, TripRepository>();
builder.Services.AddScoped<IStopoverPlaceService, StopoverPlaceService>();
builder.Services.AddScoped<IStopoverPlaceRepository, StopoverPlaceRepository>();
builder.Services.AddScoped<IOpenHoursRepository, OpenHoursRepository>();
builder.Services.AddScoped<IOpenHoursService, OpenHoursService>();
builder.Services.AddScoped<IAttractionRepository, AttractionRepository>();
builder.Services.AddScoped<IAttractionService, AttractionService>();
builder.Services.AddScoped<TripAlgo>();





builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular", builder =>
    {
        builder.WithOrigins("http://localhost:4200", "http://localhost:63892/", "http://localhost:49899", "http://localhost:60776")
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials(); 
    });
});
builder.Services.AddHttpClient();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(@"Server=TAMARLT\SQLEXPRESS;Database=Trips3;TrustServerCertificate=True;Trusted_Connection=True"));
builder.Services.AddAutoMapper(typeof(MappingUser), typeof(MappingTrip),typeof(SignInMapping),typeof(UserPostMapping));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["JWT:Issuer"],
        ValidAudience = builder.Configuration["JWT:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
    };
});

var app = builder.Build();


// Configure the HTTP request pipeline.

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.UseCors("AllowAngular"); 

app.UseAuthorization();

app.MapControllers();

app.Run();


