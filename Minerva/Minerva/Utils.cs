using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minerva
{
    public static class Utils
    {
        static Utils()
        {
            DotNetEnv.Env.Load();
        }

        public static string CONNECT_STRING => DotNetEnv.Env.GetString("CONNECT_STRING");

        // Query string... queries the API and returns JSON data
        public const string QUERY_STRING = @"http://openlibrary.org/search.json?q=";

        // API image queries are "https://covers.openlibrary.org/b/isbn/{ book ISBN }-M.jpg" i.e. IMAGE_QUERY + ISBN + IMG_TAG
        public const string IMAGE_QUERY = "https://covers.openlibrary.org/b/isbn/";
        public const string IMG_TAG = "-M.jpg";
    }
}
