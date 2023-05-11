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
    [Route("lms/api")]
    [ApiController]
    public class GatewayController : ControllerBase
    {
        private readonly IStoreManager _productManager;
        private readonly IJWTManager _jWTManager;

        public GatewayController(IStoreManager productManager, IJWTManager jWTManager)
        {
            _productManager = productManager;
            _jWTManager = jWTManager;
        }


        [AllowAnonymous]
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

        //[Authorize]
        [HttpPost("getAllStores")]
        public IActionResult GetAllStores(int pageSize, int pageNumber)
        {
            try
            {
                var stores = _productManager.GetAllStores(pageSize, pageNumber);

                return Ok(stores);
            }
            catch (StoreException ex)
            {
                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
            catch (Exception e)
            {
                StoreException ex = new(StoreExceptions.UnhandledError);

                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
        }

        [Authorize]
        [HttpPost("saveStore")]
        public IActionResult SaveStore([Required] StoreReqDTO reqDTO)
        {
            try
            {
                var store = _productManager.SaveStore(reqDTO);

                return Ok(store);
            }
            catch (StoreException ex)
            {
                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
            catch (Exception e)
            {
                StoreException ex = new(StoreExceptions.UnhandledError);

                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
        }
    }
}
