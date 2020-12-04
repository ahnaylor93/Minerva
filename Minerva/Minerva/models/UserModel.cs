using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minerva.models
{
    public class UserModel
    {
        // Model User Object
        public int user_id { get; set; }
        public String user_firstname { get; set; }
        public String user_lastname { get; set; }
        public String username { get; set; }
        public String password { get; set; }
        public String designation { get; set; }
    }
}
