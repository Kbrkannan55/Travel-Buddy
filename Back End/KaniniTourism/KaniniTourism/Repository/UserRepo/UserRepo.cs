﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using System.Text;
using loginauth.Context;
using KaniniTourism.Models;
using loginauth.Helpers;
using Microsoft.EntityFrameworkCore;
using loginauth.Models.Dto;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;

namespace KaniniTourism.Repository.UserRepo
{
    public class UserRepo : IUserRepo
    {
        private readonly TourismContext _context;

        public UserRepo(TourismContext context)
        {
            //instead of using this as '_'
            _context = context;
        }

        public async Task<IActionResult> AddUser(User userObj)
        {
            if (userObj == null)
                return new BadRequestResult();

            // check email
            if (await CheckEmailExistAsync(userObj.Email))
                return new BadRequestObjectResult(new { Message = "Email Already Exist" });

            //check username
            if (await CheckUsernameExistAsync(userObj.Username))
                return new BadRequestObjectResult(new { Message = "Username Already Exist" });

            var passMessage = CheckPasswordStrength(userObj.Password);
            if (!string.IsNullOrEmpty(passMessage))
                return new BadRequestObjectResult(new { Message = passMessage.ToString() });

            //password hash method from helper folder
            userObj.Password = PasswordHash.HashPassword(userObj.Password);
            userObj.Token = "";
            await _context.AddAsync(userObj);
            await _context.SaveChangesAsync();
            return new OkObjectResult(new
            {
                Status = 200,
                Message = "Added Successfully!"
            });
        }

        //for register certain meathods are defined here
        //Anyasync ->import, using Microsoft.EntityFrameworkCore;

        private Task<bool> CheckEmailExistAsync(string? email)
            => _context.users.AnyAsync(x => x.Email == email);

        private Task<bool> CheckUsernameExistAsync(string? username)
            => _context.users.AnyAsync(x => x.Username == username);

        private static string CheckPasswordStrength(string pass)
        {
            StringBuilder sb = new StringBuilder();
            if (pass.Length < 9)
                sb.Append("Minimum password length should be 8" + Environment.NewLine);
            if (!(Regex.IsMatch(pass, "[a-z]") && Regex.IsMatch(pass, "[A-Z]") && Regex.IsMatch(pass, "[0-9]")))
                sb.Append("Password should be AlphaNumeric" + Environment.NewLine);
            if (!Regex.IsMatch(pass, "[<,>,@,!,#,$,%,^,&,*,(,),_,+,\\[,\\],{,},?,:,;,|,',\\,.,/,~,`,-,=]"))
                sb.Append("Password should contain special charcter" + Environment.NewLine);
            return sb.ToString();
        }


        //to authenticate
        public async Task<IActionResult> Authenticate(User userObj)
        {
            if (userObj == null)
                return new BadRequestResult();

            var user = await _context.users
                .FirstOrDefaultAsync(x => x.Email == userObj.Email);

            if (user == null)
                return new NotFoundObjectResult(new { Message = "User not found!" });

            if (!PasswordHash.VerifyPassword(userObj.Password, user.Password))
            {
                return new BadRequestObjectResult(new { Message = "Password is Incorrect" });
            }

            user.Token = CreateJwt(user);
            var newAccessToken = user.Token;
            var newRefreshToken = CreateRefreshToken();
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(1);
            await _context.SaveChangesAsync();

            return new OkObjectResult(new TokenApiDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                Role = user.Role,
                Id=user.Id
            });
        }

        //for authenticate i need ceatejwt meathod
        private string CreateJwt(User user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("This Token is the JWT Token.....");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, user.Role),
                new Claim(ClaimTypes.Email,$"{user.Email}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddSeconds(10),
                SigningCredentials = credentials
            };
            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }

        //for autheticate i need the refresh token 
        private string CreateRefreshToken()
        {
            var tokenBytes = RandomNumberGenerator.GetBytes(64);
            var refreshToken = Convert.ToBase64String(tokenBytes);

            var tokenInUser = _context.users
                .Any(a => a.RefreshToken == refreshToken);
            if (tokenInUser)
            {
                return CreateRefreshToken();
            }
            return refreshToken;
        }

        //for refresh token 
        public async Task<IActionResult> Refresh(TokenApiDto getToken)
        {
            if (getToken is null)
                return new BadRequestObjectResult("Invalid Client Request");

            string accessToken = getToken.AccessToken;
            string refreshToken = getToken.RefreshToken;
            var principal = GetPrincipleFromExpiredToken(accessToken);
            var username = principal.Identity.Name;
            var user = await _context.users.FirstOrDefaultAsync(u => u.Username == username);

            if (user is null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                return new BadRequestObjectResult("Invalid Request");

            var newAccessToken = CreateJwt(user);
            var newRefreshToken = CreateRefreshToken();
            user.RefreshToken = newRefreshToken;
            await _context.SaveChangesAsync();

            return new OkObjectResult(new TokenApiDto()
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken,
                Role = user.Role

            });
        }

        //for refresh token i need the GetPrincipleFromExpiredToken meathod
        private ClaimsPrincipal GetPrincipleFromExpiredToken(string token)
        {
            var key = Encoding.ASCII.GetBytes("This Token is the JWT Token.....");
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = false
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken securityToken;
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);
            var jwtSecurityToken = securityToken as JwtSecurityToken;
            if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("This is Invalid Token");
            return principal;

        }




        public async Task<ActionResult<List<User>>> GetAllAgent()
        {
            var details = await _context.users.Where(x => x.Role == "Agent").ToListAsync();
            return details;
        }


        public async Task<ActionResult<List<User>>> DeleteAgent(int id)
        {
           var details= await  _context.users.FirstOrDefaultAsync(d=>d.Id== id);
            _context.Remove(details);
            await _context.SaveChangesAsync();
            return await _context.users.ToListAsync();
        }
    }

}
