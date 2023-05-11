namespace LMS.API.Utils
{
    public static class Constants
    {
        public const string VALUE_SEPARATOR = "||";

        public const int SUCCESS_CODE = 200;
        public const string SUCCESS_MSG = "Success";

        public static class DatabaseUtils
        {
            public static string SQL_CONNECTION_STRING = string.Empty;
           
            public static string SQLDB_CONNECTION_STRING
            {
                get
                {
                    return SQL_CONNECTION_STRING;
                }
            }
            public static string SQLDB_CONNECTION_STRING_DELIMITER
            {
                get
                {
                    return ";";
                }
            }
        }

        public enum EntityState
        {
            Unchanged,
            Added,
            Modified,
            Deleted
        }
    }
}
