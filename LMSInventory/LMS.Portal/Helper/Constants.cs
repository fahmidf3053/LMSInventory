using LMS.API.DTOs.RequestDTOs;

namespace LMS.Portal.Helper
{
    public static class Constants
    {
        public static string BASE_URL = "";
        public static UserReqDTO user = new();

        public static class APIEndpoints
        {
            public static string AUTHENTICATE = "lms/api/authenticate";

            public static string GET_ALL_STORES = "lms/api/getAllStores";
            public static string GET_STORE_BY_ID = "lms/api/getStoreById";
            public static string SAVE_STORE = "lms/api/saveStore";
            public static string EDIT_STORE = "lms/api/editStore";
            public static string DELETE_STORE = "lms/api/deleteStore";

            public static string GET_ALL_RACKS = "lms/api/getAllRacks";
            public static string GET_RACK_BY_ID = "lms/api/getRackById";
            public static string SAVE_RACK = "lms/api/saveRack";
            public static string EDIT_RACK = "lms/api/editRack";
            public static string DELETE_RACK = "lms/api/deleteRack";
        }
    }
}
