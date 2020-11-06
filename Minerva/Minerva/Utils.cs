using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Minerva
{
    public static class Utils
    {
        static Utils()
        {
            DotNetEnv.Env.Load();
        }

        #region API Query Variables
        /*
         Query string only needs QUERY_STRING + {searchQuery}

         API image queries are "https://covers.openlibrary.org/b/isbn/{ book ISBN }-M.jpg" i.e. IMAGE_QUERY + ISBN + IMG_TAG
        */

        // Connects to DB
        public static string CONNECT_STRING => DotNetEnv.Env.GetString("CONNECT_STRING");

        public const string QUERY_STRING = @"http://openlibrary.org/search.json?q=";

        public const string IMAGE_QUERY = "https://covers.openlibrary.org/b/isbn/";
        public const string IMG_TAG = "-M.jpg";

        #endregion


        #region Helper Methods

        // Helper method to deserialize json data
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

        // Creates random Id for use with transaction_id and user_id
        public static int _IDGenerator()
        {
            var random = new Random();
            string id = String.Empty;
            for (int i = 0; i < 15; i++)
                id = String.Concat(id, random.Next(10).ToString());

            return Int32.Parse(id);
        }

        #endregion
    }
}
