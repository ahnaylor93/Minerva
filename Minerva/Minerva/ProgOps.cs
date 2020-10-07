using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Minerva
{
    class ProgOps
    {
        /*
        TODO: Map Back-End: General idea is to create a DataTable that handles all DB Updates.
        
        ISSUE: Endpoint has no data dump.
        */

        public const string CONNECT_STRING = @"Server=cstnt.tstc.edu;Database=inew2330fa20;User Id=group2bfa202330;password=1829375";

        public const string QUERY_STRING = @"http://openlibrary.org/search.json?q=";

        // image queries are "https://covers.openlibrary.org/b/isbn/{ book ISBN }-M.jpg" i.e. IMAGE_QUERY + ISBN + IMG_TAG

        public const string IMAGE_QUERY = "https://covers.openlibrary.org/b/isbn/";
        public const string IMG_TAG = "-M.jpg";

        private static SqlConnection _cntDatabase = new SqlConnection(CONNECT_STRING);
        private static SqlCommand _sqlResCommand;
        private static SqlDataAdapter _daRes = new SqlDataAdapter();
        private static DataTable _dtResTable = new DataTable();

        public static DataTable DTResTable
        {
            get { return _dtResTable; }
            set { _dtResTable = value; }
        }

        public static void OpenDB()
        {
            try
            {
                if (_cntDatabase.State == ConnectionState.Closed) _cntDatabase.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection to db was open successfully",
                        "Database Connection",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }

        public void CloseDB()
        {
            _cntDatabase.Close();
            _cntDatabase.Dispose();
        }
    }
}
