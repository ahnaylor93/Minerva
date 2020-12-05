using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minerva.models
{
    public class JSONResult
    {
        // Model JSONResult Object
        //needed for deserializing JSON data
        public String title_suggest;
        public String[] edition_key;
        public String subtitle = null;
        public bool has_fulltext;
        public String[] text;
        public String[] author_name;
        public String[] seed;
        public String[] isbn;
        public String[] author_key;
        public String title;
        public String[] publish_date;
        public String type;
        public int ebook_count_i;
        public String[] publish_place;
        public int edition_count;
        public String key;
        public String[] publisher;
        public String[] id_amazon;
        public String[] language;
        public int last_modified_i;
        public String[] author_alternative_name;
        public String cover_edition_key;
        public int[] publish_year;
        public int first_publish_year;
    }
}
