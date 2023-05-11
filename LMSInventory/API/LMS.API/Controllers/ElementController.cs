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
    public class ElementController : ControllerBase
    {
        private readonly IElementManager _elementManager;

        public ElementController(IElementManager elementManager)
        {
            _elementManager = elementManager;
        }

        [HttpPost("getAllElements")]
        public IActionResult GetAllElements(int pageSize, int pageNumber)
        {
            try
            {
                var elements = _elementManager.GetAllElements(pageSize, pageNumber);

                return Ok(elements);
            }
            catch (ElementException ex)
            {
                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
            catch (Exception e)
            {
                ElementException ex = new(ElementExceptions.UnhandledError);

                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
        }

        [HttpPost("getElementById")]
        public IActionResult GetElementById([Required] int id)
        {
            try
            {
                var elements = _elementManager.GetElementById(id);

                return Ok(elements);
            }
            catch (ElementException ex)
            {
                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
            catch (Exception e)
            {
                ElementException ex = new(ElementExceptions.UnhandledError);

                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
        }

        [HttpPost("saveElement")]
        public IActionResult SaveElement([Required] ElementReqDTO reqDTO)
        {
            try
            {
                var element = _elementManager.SaveElement(reqDTO);

                return Ok(element);
            }
            catch (ElementException ex)
            {
                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
            catch (Exception e)
            {
                ElementException ex = new(ElementExceptions.UnhandledError);

                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
        }

        [HttpPost("editElement")]
        public IActionResult EditElement([Required] ElementReqDTO reqDTO)
        {
            try
            {
                var element = _elementManager.EditElement(reqDTO);

                return Ok(element);
            }
            catch (ElementException ex)
            {
                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
            catch (Exception e)
            {
                ElementException ex = new(ElementExceptions.UnhandledError);

                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
        }

        [HttpPost("deleteElement")]
        public IActionResult DeleteElement([Required] int id)
        {
            try
            {
                var response = _elementManager.DeleteElement(id);

                return Ok(response);
            }
            catch (ElementException ex)
            {
                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
            catch (Exception e)
            {
                ElementException ex = new(ElementExceptions.UnhandledError);

                return Problem(detail: ex.StatusMessage, statusCode: ex.StatusCode, title: ex.Title);
            }
        }
    }
}
