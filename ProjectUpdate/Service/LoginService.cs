﻿using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ProjectUpdateApp.Dto;
using ProjectUpdateApp.IRepository;
using ProjectUpdateApp.IService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProjectUpdateApp.Service
{
    public class LoginService: ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public LoginService(ILoginRepository loginRepository, IMapper mapper, IConfiguration configuration)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
            _configuration = configuration;
        }

        public string UserLogin(LoginDto logindto)
        {
            var response = _loginRepository.UserLogin(logindto);
            if (response == "valid")
            {
                var token = GenerateJwtToken(logindto.Email);
                return token.ToString();
            }
            return response;
        }

        private string GenerateJwtToken(string Email)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var signingCredentials = new SigningCredentials(
                                    new SymmetricSecurityKey(key),
                                    SecurityAlgorithms.HmacSha256
                                );
            var subject = new ClaimsIdentity(new[]
             {
                new Claim(JwtRegisteredClaimNames.Sub, Email),
                new Claim(JwtRegisteredClaimNames.Email,Email),
             });
            var expires = DateTime.UtcNow.AddMinutes(10);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = subject,
                Expires = DateTime.UtcNow.AddMinutes(10),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = signingCredentials
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);



            return jwtToken;
        }


    }
}
