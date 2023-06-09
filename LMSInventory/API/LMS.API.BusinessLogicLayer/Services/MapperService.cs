﻿using LMS.API.DataAccessLayer.Models;
using LMS.API.DTOs.RequestDTOs;
using LMS.API.DTOs.ResponseDTOs;
using static System.Formats.Asn1.AsnWriter;

namespace LMS.API.BusinessLogicLayer.Services
{
    public class MapperService
    {
        public static StoreResDTO ToStoreResDTOMap(Store store)
        {
            if (store == null)
                return new();

            return new StoreResDTO()
            {
                Id = store.Id,
                Name = store.Name,
                Country = store.Country,
                Racks = store.Racks.Select(ToRackResDTOMap).ToList()
            };
        }

        public static RackResDTO ToRackResDTOMap(Rack rack)
        {
            if (rack == null)
                return new();

            return new RackResDTO()
            {
                Id = rack.Id,
                Name = rack.Name,
                QuantityOfRacks = rack.QuantityOfRacks,
                StoreName = rack.Store.Name,
                StoreId = rack.Store.Id,
                Elements = rack.Elements.Select(ToElementResDTOMap).ToList()
            };
        }

        public static ElementResDTO ToElementResDTOMap(Element element)
        {
            if (element == null)
                return new();

            return new ElementResDTO()
            {
                Id = element.Id,
                Name = element.Name,
                Height = element.Height,
                Width = element.Width,
                RackName = element.Rack.Name,
                RackId = element.Rack.Id
            };
        }

        public static Store ToStoreModelMap(StoreReqDTO reqDTO)
        {
            if (reqDTO == null)
                return new();

            return new Store()
            {
                Id = 0,
                Name = reqDTO.Name,
                Country = reqDTO.Country
            };
        }

        public static Rack ToRackModelMap(RackReqDTO reqDTO)
        {
            if (reqDTO == null)
                return new();

            return new Rack()
            {
                Id = 0,
                Name = reqDTO.Name,
                QuantityOfRacks = reqDTO.QuantityOfRacks,
                StoreId = reqDTO.StoreId
            };
        }

        public static Element ToElementModelMap(ElementReqDTO reqDTO)
        {
            if (reqDTO == null)
                return new();

            return new Element()
            {
                Id = 0,
                Name = reqDTO.Name,
                Height = reqDTO.Height,
                Width = reqDTO.Width,
                RackId = reqDTO.RackId
            };
        }
    }
}
