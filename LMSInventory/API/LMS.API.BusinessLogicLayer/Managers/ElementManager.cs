using LMS.API.BusinessLogicLayer.Interfaces;
using LMS.API.BusinessLogicLayer.Services;
using LMS.API.DataAccessLayer.Models;
using LMS.API.DataAccessLayer.Services;
using LMS.API.DTOs.RequestDTOs;
using LMS.API.DTOs.ResponseDTOs;
using LMS.API.Exceptions;
using static LMS.API.Utils.Constants;

namespace LMS.API.BusinessLogicLayer.Managers
{
    public class ElementManager : IElementManager
    {
        private readonly IDataAccessService _dataAccessService;

        public ElementManager(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        #region Public Methods

        public List<ElementResDTO> GetAllElements(int pageSize, int pageNumber)
        {
            List<Element> elements = new();

            if (pageSize == 0 || pageNumber == 0)
            {
                elements = _dataAccessService.GetAllElements().ToList();
            }
            else
            {
                elements = _dataAccessService.GetAllElements(pageSize, pageNumber).ToList();
            }

            List<ElementResDTO> result = elements.Select(MapperService.ToElementResDTOMap).ToList();

            return result;
        }

        public ElementResDTO GetElementById(int id)
        {

            Element element = _dataAccessService.GetElementById(id);

            if (element == null)
                throw new ElementException(ElementExceptions.ElementInfoNotFound);

            ElementResDTO result = MapperService.ToElementResDTOMap(element);

            return result;
        }

        public ElementResDTO SaveElement(ElementReqDTO reqDTO)
        {
            ValidateElementReqDTO(reqDTO);

            Element elementToBeAdded = MapperService.ToElementModelMap(reqDTO);

            elementToBeAdded.EntityState = EntityState.Added;

            _dataAccessService.AddElements(elementToBeAdded);

            if(elementToBeAdded.Id == 0)
                throw new ElementException(ElementExceptions.ElementSaveFailed);

            ElementResDTO result = MapperService.ToElementResDTOMap(_dataAccessService.GetElementById(elementToBeAdded.Id));

            return result;
        }

        public ElementResDTO EditElement(ElementReqDTO reqDTO)
        {
            Element elementToBeUpdated = _dataAccessService.GetElementById(reqDTO.Id);

            if (elementToBeUpdated == null)
                throw new ElementException(ElementExceptions.WrongElementInfo);

            ValidateElementReqDTO(reqDTO);

            elementToBeUpdated.Name = reqDTO.Name;
            elementToBeUpdated.Height = reqDTO.Height;
            elementToBeUpdated.Width = reqDTO.Width;
            elementToBeUpdated.Rack = _dataAccessService.GetRackById(reqDTO.RackId);
            elementToBeUpdated.EntityState = EntityState.Modified;
            elementToBeUpdated.Rack.EntityState = EntityState.Modified;
            elementToBeUpdated.Rack.Store.EntityState = EntityState.Modified;

            _dataAccessService.UpdateElements(elementToBeUpdated);

            ElementResDTO result = MapperService.ToElementResDTOMap(_dataAccessService.GetElementById(elementToBeUpdated.Id));

            return result;
        }

        public ResponseDTO DeleteElement(int id)
        {
            Element elementToBeDeleted = _dataAccessService.GetElementById(id);

            if (elementToBeDeleted == null)
                throw new ElementException(ElementExceptions.WrongElementInfo);

            elementToBeDeleted.EntityState = EntityState.Deleted;
            elementToBeDeleted.Rack.EntityState = EntityState.Modified;
            elementToBeDeleted.Rack.Store.EntityState = EntityState.Modified;

            _dataAccessService.DeleteElements(elementToBeDeleted);

            Element element = _dataAccessService.GetElementById(id);

            if (element != null)
                throw new ElementException(ElementExceptions.ElementDeleteFailed);

            return new ResponseDTO
            {
                Status = SUCCESS_CODE,
                Message = SUCCESS_MSG
            };
        }

        #endregion Public Methods

        #region Private Methods

        private void ValidateElementReqDTO(ElementReqDTO reqDTO)
        {
            Rack elementRack = _dataAccessService.GetRackById(reqDTO.RackId);

            if (elementRack == null)
                throw new ElementException(ElementExceptions.InvalidRack);

            if(elementRack.QuantityOfRacks == elementRack.Elements.Count)
                throw new ElementException(ElementExceptions.RackFull);
        }

        #endregion Private Methods
    }
}
