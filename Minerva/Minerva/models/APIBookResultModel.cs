using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minerva.models
{
    class APIBookResultModel
    {
        public int numFound { get; set; }
        public int start { get; set; }
        public APIBookModel[] docs { get; set; }
        public int num_found { get; set; }
    }
}
