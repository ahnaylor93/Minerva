using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Minerva.models
{
    public class Book
    {
        // Model Book Object
        public int ISBN { get; set; }
        public String title { get; set; }
        public String publish_date { get; set; }
        public int actual_quantity { get; set; }
        public int checked_in { get; set; }
        public int checked_out { get; set; }
    }
}
