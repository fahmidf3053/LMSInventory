namespace LMS.API.Exceptions
{
    public class RackException : Exception
    {
        public RackException(string errorType)
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
                "RackInfoNotFound", new List<string>(){"404", "Not Found", "Rack Info Not Found." }
            },
            {
                "RackSaveFailed", new List<string>(){"400", "Bad Request", "Couldn't Save the Rack." }
            },
            {
                "WrongRackInfo", new List<string>(){"400", "Bad Request", "Wrong Rack Info." }
            },
            {
                "RackDeleteFailed", new List<string>(){"400", "Bad Request", "Couldn't Delete the Rack." }
            },
            {
                "UnhandledError", new List<string>(){"500", "Server Error", "Internal Server Error." }
            }
        };

    }
    public static class RackExceptions
    {
        public const string RackInfoNotFound = "RackInfoNotFound";
        public const string RackSaveFailed = "RackSaveFailed";
        public const string WrongRackInfo = "WrongRackInfo";
        public const string RackDeleteFailed = "RackDeleteFailed";
        public const string UnhandledError = "UnhandledError";
    }
}
