using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

using LMS.API.BusinessLogicLayer.Interfaces;
using LMS.API.DTOs.RequestDTOs;
using LMS.API.Exceptions;

namespace LMS.API.Controllers
{
    [Authorize]
    [Route("lms/api")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreManager _storeManager;

        public StoreController(IStoreManager storeManager)
        {
            _storeManager = storeManager;
        }

        [HttpPost("getAllStores")]
        public IActionResult GetAllStores(int pageSize, int pageNumber)
        {
            try
            {
                var stores = _storeManager.GetAllStores(pageSize, pageNumber);

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

        [HttpPost("getStoreById")]
        public IActionResult GetStoreById([Required] int id)
        {
            try
            {
                var stores = _storeManager.GetStoreById(id);

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

        [HttpPost("saveStore")]
        public IActionResult SaveStore([Required] StoreReqDTO reqDTO)
        {
            try
            {
                var store = _storeManager.SaveStore(reqDTO);

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

        [HttpPost("editStore")]
        public IActionResult EditStore([Required] StoreReqDTO reqDTO)
        {
            try
            {
                var store = _storeManager.EditStore(reqDTO);

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

        [HttpPost("deleteStore")]
        public IActionResult DeleteStore([Required] int id)
        {
            try
            {
                var response = _storeManager.DeleteStore(id);

                return Ok(response);
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
