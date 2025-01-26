﻿using GetMyTicket.Common.Constants;
using GetMyTicket.Common.DTOs.User;
using GetMyTicket.Common.Entities;
using GetMyTicket.Common.JwtToken;
using GetMyTicket.Service.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace GetMyTicket.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class AuthenticationController : ControllerBase
    {
        private readonly ConnectionMultiplexer muxer;
        private readonly IDatabase RedisDb;
        private readonly UserManager<User> userManager;

        private readonly TokenService tokenService;

        public AuthenticationController(
            TokenService tokenService,
            UserManager<User> userManager)
        {
            this.tokenService = tokenService;
            this.userManager = userManager;

            //TODO - implement safe storage of credentials;

            muxer = ConnectionMultiplexer.Connect(
            new ConfigurationOptions
            {
                EndPoints = { { "redis-12612.c282.east-us-mz.azure.redns.redis-cloud.com", 12612 } },
                User = "default",
                Password = "**"
            }
            );

            RedisDb = muxer.GetDatabase();
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken(string refreshToken, Guid userId)
        {
            var tokenExists = await RedisDb.KeyExistsAsync(refreshToken);

            if (!tokenExists)
            {
                return BadRequest(ErrorMessages.SomethingWentWrong);
            }

            var tokenModel = GenerateTokens(userId);

            await RedisDb.KeyRenameAsync(refreshToken, tokenModel.RefreshToken);

            return Ok(tokenModel);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO data)
        {
            var user = await userManager.FindByEmailAsync(data.Email);

            if (user == null)
            {
                return BadRequest(ErrorMessages.InvalidCredentials);
            }

            bool passwordIsCorrect = await userManager.CheckPasswordAsync(
                user, data.Password);

            if (!passwordIsCorrect)
            {
                return BadRequest(ErrorMessages.InvalidCredentials);
            }

            var tokenModel = GenerateTokens(user.Id);

            //TODO - encrypt token and store encrypted value
            //TODO - > CAN WE OPTIMIZE THIS? Its kinda slow
            await RedisDb.SetAddAsync(tokenModel.RefreshToken, data.Email);

            return Ok(tokenModel);

        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout(string refreshToken)
        {
            var result = await RedisDb.KeyDeleteAsync(refreshToken);

            if (!result)
            {
                return BadRequest(ErrorMessages.SomethingWentWrong);
            }

            return Ok("Successfully logged out.");
        }


        private JwtTokenModel GenerateTokens(Guid userId)
        {
            string accessToken = tokenService.GenerateAccessToken(userId);
            string refreshToken = tokenService.GenerateRefreshToken();

            var tokenModel = new JwtTokenModel(accessToken, refreshToken);

            return tokenModel;

        }

    }
}