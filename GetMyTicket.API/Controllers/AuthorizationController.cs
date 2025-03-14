﻿using GetMyTicket.Common.Constants;
using GetMyTicket.Common.DTOs.User;
using GetMyTicket.Common.Entities;
using GetMyTicket.Common.JwtToken;
using GetMyTicket.Service.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;

namespace GetMyTicket.API.Controllers
{
    [Route("api/authorization")]
    [ApiController]

    public class AuthorizationController : ControllerBase
    {
        //TODO: REFACTOR!

        private readonly ConnectionMultiplexer muxer;
        private readonly IDatabase RedisDb;
        private readonly UserManager<User> userManager;
        private readonly IConfiguration configuration;

        private readonly IAuthorizationService authorizationService;

        public AuthorizationController(
            IAuthorizationService authorizationService,
            UserManager<User> userManager,
            IConfiguration configuration)
        {
            this.authorizationService = authorizationService;
            this.userManager = userManager;

            var redisConfig = configuration.GetSection("Redis");

            muxer = ConnectionMultiplexer.Connect(
            new ConfigurationOptions
            {
                EndPoints = { { redisConfig["EndPoints:0:Host"], int.Parse(redisConfig["EndPoints:0:Port"]) } },
                User = redisConfig["User"],
                Password = redisConfig["Password"]
            }
            );

            RedisDb = muxer.GetDatabase();
            this.configuration = configuration;
        }

        [HttpPost("refreshToken")]
        public async Task<IActionResult> RefreshToken(string refreshToken, Guid userId)
        {
            var tokenExists = await RedisDb.KeyExistsAsync(refreshToken);

            if (!tokenExists)
            {
                return BadRequest(ErrorMessages.SomethingWentWrong);
            }

            //TODO -> REMOVE OR REFACTOR TO BE USED. Email only for test purposes
            var tokenModel = GenerateTokens(userId);

            await RedisDb.KeyRenameAsync(refreshToken, tokenModel.RefreshToken);

            return Ok(tokenModel);
        }

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

        //TODO REFACTOR: SHOULD NOT NEED REFRESH TOKEN
        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
           // var result = await RedisDb.KeyDeleteAsync(refreshToken);

           // if (!result)
           // {
           //     return BadRequest(ErrorMessages.SomethingWentWrong);
           // }

            return Ok("Successfully logged out.");
        }


        private JwtTokenModel GenerateTokens(Guid userId)
        {
            string accessToken = authorizationService.GenerateAccessToken(userId);
            string refreshToken = authorizationService.GenerateRefreshToken();

            var tokenModel = new JwtTokenModel(accessToken, refreshToken, userId);

            return tokenModel;

        }

    }
}