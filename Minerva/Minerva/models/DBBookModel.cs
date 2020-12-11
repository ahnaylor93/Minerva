using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Minerva.models
{
    public class DBBookModel
    {
        // Model Book from DB Object
        public String ISBN { get; set; }
        public String title { get; set; }
        public String subtitle { get; set; }
        public String author { get; set; }
        public String publish_date { get; set; }
        public String image_url { get; set; }
        public int actual_quantity { get; set; }
        public int checked_in { get; set; }
        public int checked_out { get; set; }
    }
}
