﻿
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TripPlaning.API.DTO;
using TripPlaning.Core.Model;
using TripPlaning.Core.Service;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly IUserService _userService;
    private readonly IMapper _mapper;


    public AuthController(IConfiguration configuration, IUserService userService, IMapper mapper)
    {
        _configuration = configuration;
        _userService = userService;
        _mapper = mapper;

    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] SignInModel loginModel)
    {
        User u = _userService.GetUserByEmail(loginModel.Email);
        if (u == null)
        {
            return NotFound();
        }
        if (loginModel.Password != u.Password)
        {
            return BadRequest();
        }
        if (loginModel.Email == u.Email && loginModel.Password == u.Password)
        {
            var claims = new List<Claim>()
            {
                    new Claim(ClaimTypes.NameIdentifier, u.Id.ToString()),
                    new Claim(ClaimTypes.Email, u.Email),
                    new Claim(ClaimTypes.Name, u.Name),
                    new Claim(ClaimTypes.Role, u.Role.ToString()),

            };

            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("JWT:Key")));
            var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
            var tokeOptions = new JwtSecurityToken(
                issuer: _configuration.GetValue<string>("JWT:Issuer"),
                audience: _configuration.GetValue<string>("JWT:Audience"),
                claims: claims,
                expires: DateTime.Now.AddMinutes(6),
                signingCredentials: signinCredentials
            );
            var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
            return Ok(new { Token = tokenString });
        }

        return Unauthorized();
    }

    [HttpPost("signUp")]
    public IActionResult SignUp([FromBody] UserPostModel user)
    {
        Console.WriteLine("SignIn");
        //User u = _userService.SignUp(_mapper.Map<User>(user));
        User u = _userService.SignUp(_mapper.Map<User>(user));
        if (u == null)
        {
            return Conflict();
        }

        return Login(_mapper.Map<SignInModel>(u));
    }
}

