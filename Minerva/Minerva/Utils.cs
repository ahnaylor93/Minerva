using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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

        // helper method to deserialize json data
        public static void _deserializeJSON(String json)
        {
            try
            {
                var jsonObject = JsonConvert.DeserializeObject<dynamic>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
            }
        }

        // Creates random User Id
        public static int _userIDGenerator()
        {
            var random = new Random();
            string id = String.Empty;
            for (int i = 0; i < 15; i++)
                id = String.Concat(id, random.Next(10).ToString());

            return Int32.Parse(id);
        }
    }
}
