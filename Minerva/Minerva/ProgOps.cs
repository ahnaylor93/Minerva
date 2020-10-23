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
        TODO: 
            Map Back-End: Async API Queries and store data in Data Table; handles books
            DB: Database will be used for CRUD on employee and user information; no book data
        */

        private static SqlConnection _cntDatabase;

        private void ConnectDB()
        {
            _cntDatabase = new SqlConnection(Utils.CONNECT_STRING);

            try
            {
                _cntDatabase.Open();

                while (true)
                {

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void QueryAPI()
        {
            /*
             TODO: Create data fetch 
             */
        }
    }
}
