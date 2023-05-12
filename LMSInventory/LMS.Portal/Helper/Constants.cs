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
        }
    }
}
