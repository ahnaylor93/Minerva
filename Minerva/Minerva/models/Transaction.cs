using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minerva.models
{
    public class Transaction
    {
        // Model Transaction Object
        public int user_id { get; set; }
        public String username { get; set; }
        public int ISBN { get; set; }
        public int quantity { get; set; }
        public int issued_by { get; set; }
    }
}
