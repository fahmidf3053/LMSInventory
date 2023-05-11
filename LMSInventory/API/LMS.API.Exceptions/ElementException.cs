namespace LMS.API.Exceptions
{
    public class ElementException : Exception
    {
        public ElementException(string errorType)
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
                "ElementInfoNotFound", new List<string>(){"404", "Not Found", "Element Info Not Found." }
            },
            {
                "ElementSaveFailed", new List<string>(){"400", "Bad Request", "Couldn't Save the Element." }
            },
            {
                "WrongElementInfo", new List<string>(){"400", "Bad Request", "Wrong Element Info." }
            },
            {
                "InvalidRack", new List<string>(){"400", "Bad Request", "Invalid Rack for Element." }
            },
            {
                "RackFull", new List<string>(){"400", "Bad Request", "Rack is already full. Couldn't Save the Element." }
            },
            {
                "ElementDeleteFailed", new List<string>(){"400", "Bad Request", "Couldn't Delete the Element." }
            },
            {
                "UnhandledError", new List<string>(){"500", "Server Error", "Internal Server Error." }
            }
        };

    }
    public static class ElementExceptions
    {
        public const string ElementInfoNotFound = "ElementInfoNotFound";
        public const string ElementSaveFailed = "ElementSaveFailed";
        public const string WrongElementInfo = "WrongElementInfo";
        public const string InvalidRack = "InvalidRack";
        public const string RackFull = "RackFull";
        public const string ElementDeleteFailed = "ElementDeleteFailed";
        public const string UnhandledError = "UnhandledError";
    }
}
