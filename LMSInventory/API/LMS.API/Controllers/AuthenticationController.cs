using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

using LMS.API.BusinessLogicLayer.Interfaces;
using LMS.API.DTOs.RequestDTOs;
using LMS.API.DTOs.ResponseDTOs;
using LMS.API.Exceptions;

namespace LMS.API.Controllers
{
    [AllowAnonymous]
    [Route("lms/api")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IJWTManager _jWTManager;

        public AuthenticationController(IJWTManager jWTManager)
        {
            _jWTManager = jWTManager;
        }


        [HttpPost("authenticate")]
        public IActionResult Authenticate([Required] UserReqDTO user)
        {
            try
            {
                var token = _jWTManager.Authenticate(user);

                if (token == null)
                {
                    return Unauthorized();
                }

                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
    }
}
