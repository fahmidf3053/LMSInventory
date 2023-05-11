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
    public class RackManager : IRackManager
    {
        private readonly IDataAccessService _dataAccessService;

        public RackManager(IDataAccessService dataAccessService)
        {
            _dataAccessService = dataAccessService;
        }

        #region Public Methods

        public List<RackResDTO> GetAllRacks(int pageSize, int pageNumber)
        {
            List<Rack> racks = new();

            if (pageSize == 0 || pageNumber == 0)
            {
                racks = _dataAccessService.GetAllRacks().ToList();
            }
            else
            {
                racks = _dataAccessService.GetAllRacks(pageSize, pageNumber).ToList();
            }

            List<RackResDTO> result = racks.Select(MapperService.ToRackResDTOMap).ToList();

            return result;
        }

        public RackResDTO GetRackById(int id)
        {

            Rack rack = _dataAccessService.GetRackById(id);

            if (rack == null)
                throw new RackException(RackExceptions.RackInfoNotFound);

            RackResDTO result = MapperService.ToRackResDTOMap(rack);

            return result;
        }

        public RackResDTO SaveRack(RackReqDTO reqDTO)
        {
            ValidateRackReqDTO(reqDTO);

            Rack rackToBeAdded = MapperService.ToRackModelMap(reqDTO);

            rackToBeAdded.EntityState = EntityState.Added;

            _dataAccessService.AddRacks(rackToBeAdded);

            if(rackToBeAdded.Id == 0)
                throw new RackException(RackExceptions.RackSaveFailed);

            RackResDTO result = MapperService.ToRackResDTOMap(_dataAccessService.GetRackById(rackToBeAdded.Id));

            return result;
        }

        public RackResDTO EditRack(RackReqDTO reqDTO)
        {
            Rack rackToBeUpdated = _dataAccessService.GetRackById(reqDTO.Id);

            if (rackToBeUpdated == null)
                throw new RackException(RackExceptions.WrongRackInfo);

            rackToBeUpdated.Name = reqDTO.Name;
            rackToBeUpdated.QuantityOfRacks = reqDTO.QuantityOfRacks;
            rackToBeUpdated.EntityState = EntityState.Modified;
            rackToBeUpdated.Store.EntityState = EntityState.Modified;

            _dataAccessService.UpdateRacks(rackToBeUpdated);

            RackResDTO result = MapperService.ToRackResDTOMap(_dataAccessService.GetRackById(rackToBeUpdated.Id));

            return result;
        }

        public ResponseDTO DeleteRack(int id)
        {
            Rack rackToBeDeleted = _dataAccessService.GetRackById(id);

            if (rackToBeDeleted == null)
                throw new RackException(RackExceptions.WrongRackInfo);

            rackToBeDeleted.EntityState = EntityState.Deleted;

            _dataAccessService.DeleteRacks(rackToBeDeleted);

            Rack rack = _dataAccessService.GetRackById(id);

            if (rack != null)
                throw new RackException(RackExceptions.RackDeleteFailed);

            return new ResponseDTO
            {
                Status = SUCCESS_CODE,
                Message = SUCCESS_MSG
            };
        }

        #endregion Public Methods

        #region Private Methods

        private void ValidateRackReqDTO(RackReqDTO reqDTO)
        {
            Store rackStore = _dataAccessService.GetStoreById(reqDTO.StoreId);

            if (rackStore == null)
                throw new RackException(RackExceptions.InvalidStore);
        }

        #endregion Private Methods
    }
}
