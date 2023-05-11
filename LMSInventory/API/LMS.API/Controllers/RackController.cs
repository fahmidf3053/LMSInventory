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
    public class RackController : ControllerBase
    {
        private readonly IRackManager _rackManager;

        public RackController(IRackManager rackManager)
        {
            _rackManager = rackManager;
        }

        [HttpPost("getAllRacks")]
        public IActionResult GetAllRacks(int pageSize, int pageNumber)
        {
            try
            {
                var racks = _rackManager.GetAllRacks(pageSize, pageNumber);

                return Ok(racks);
            }
            catch (RackException ex)
            {
                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
            catch (Exception e)
            {
                RackException ex = new(RackExceptions.UnhandledError);

                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
        }

        [HttpPost("getRackById")]
        public IActionResult GetRackById([Required] int id)
        {
            try
            {
                var racks = _rackManager.GetRackById(id);

                return Ok(racks);
            }
            catch (RackException ex)
            {
                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
            catch (Exception e)
            {
                RackException ex = new(RackExceptions.UnhandledError);

                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
        }

        [HttpPost("saveRack")]
        public IActionResult SaveRack([Required] RackReqDTO reqDTO)
        {
            try
            {
                var rack = _rackManager.SaveRack(reqDTO);

                return Ok(rack);
            }
            catch (RackException ex)
            {
                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
            catch (Exception e)
            {
                RackException ex = new(RackExceptions.UnhandledError);

                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
        }

        [HttpPost("editRack")]
        public IActionResult EditRack([Required] RackReqDTO reqDTO)
        {
            try
            {
                var rack = _rackManager.EditRack(reqDTO);

                return Ok(rack);
            }
            catch (RackException ex)
            {
                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
            catch (Exception e)
            {
                RackException ex = new(RackExceptions.UnhandledError);

                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
        }

        [HttpPost("deleteRack")]
        public IActionResult DeleteRack([Required] int id)
        {
            try
            {
                var response = _rackManager.DeleteRack(id);

                return Ok(response);
            }
            catch (RackException ex)
            {
                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
            catch (Exception e)
            {
                RackException ex = new(RackExceptions.UnhandledError);

                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
        }
    }
}
