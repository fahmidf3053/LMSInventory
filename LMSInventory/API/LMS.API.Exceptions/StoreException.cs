namespace LMS.API.Exceptions
{
    public class StoreException : Exception
    {
        public StoreException(string errorType)
        {
            StatusCode = int.Parse(ErrorDictionary[errorType][0]);
            Title = ErrorDictionary[errorType][1];
            StatusMessage = ErrorDictionary[errorType][2];
        }

        public int StatusCode { get; set; }
        public string Title { get; set; }
        public string StatusMessage { get; set; }

        private static readonly Dictionary<string, List<string>> ErrorDictionary = new()
        {
            {
                "StoreInfoNotFound", new List<string>(){"404", "Not Found", "Store Info Not Found." }
            },
            {
                "StoreSaveFailed", new List<string>(){"400", "Bad Request", "Couldn't Save the Store." }
            },
            {
                "WrongStoreInfo", new List<string>(){"400", "Bad Request", "Wrong Store Info." }
            },
            {
                "StoreDeleteFailed", new List<string>(){"400", "Bad Request", "Couldn't Delete the Store." }
            },
            {
                "UnhandledError", new List<string>(){"500", "Server Error", "Internal Server Error." }
            }
        };

    }
    public static class StoreExceptions
    {
        public const string StoreInfoNotFound = "StoreInfoNotFound";
        public const string StoreSaveFailed = "StoreSaveFailed";
        public const string WrongStoreInfo = "WrongStoreInfo";
        public const string StoreDeleteFailed = "StoreDeleteFailed";
        public const string UnhandledError = "UnhandledError";
    }
}
