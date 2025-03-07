﻿using GetMyTicket.Common.DTOs.User;
using GetMyTicket.Service.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace GetMyTicket.API.Controllers
{
    [Route("api/accounts")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IUserService userService;

        public AccountsController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser(CreateUserDTO registerUserDTO)
        {
           var result = userService.CreateUserAsync(registerUserDTO);

            if (result.Result.Succeeded)
            {
                return Ok(result.Result);
            }

            return BadRequest(result.Result.Errors);
        }
    }
}
