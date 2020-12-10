using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Net.Http;
using System.Collections.Generic;

namespace Minerva
{
    class ProgOps
    {
        /*
        TODO: 
            Map Back-End: Async API Queries and store data in Data Table; handles books
            DB: Database will be used for CRUD on employee and user information; no book data
        */

        #region Initialize
        // TransactionList for Receipts and Admin filtering

        public static SqlConnection _cntDatabase;
        public static SqlDataAdapter _daRes;

        public static DataTable UserTable;
        public static DataTable BookTable;
        public static DataTable TransactionTable;

        public static ArrayList TransactionListByQuery;
        public static ArrayList UserListByQuery;

        // Model Objects
        public static models.DBBookModel BookObject;
        public static models.TransactionModel TransactionObject;
        public static models.UserModel UserObject;

        #endregion


        #region Comunication methods

        public static void ConnectDB()
        {
            _cntDatabase = new SqlConnection(Utils.CONNECT_STRING);
            String _connect = DotNetEnv.Env.GetString("CONNECT_STRING");
            try
            {
                if (_cntDatabase.State == ConnectionState.Closed) _cntDatabase.Open();
                // For test only
                // MessageBox.Show("Connection Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MessageBox.Show(_connect);
            }
        }

        public static void CloseDB()
        {
            _cntDatabase.Close();
            _cntDatabase.Dispose();
        }

        #endregion


        #region API Query Method
        // Searches API for book and creates C# object to be saved

        public static async Task<List<models.APIBookModel>> GetBook(String searchQuery)
        {
            String url = "http://openlibrary.org/search.json?q=" + searchQuery;

            using (HttpResponseMessage res = await models.APIHelper.APIClient.GetAsync(url))
            {
                if (res.IsSuccessStatusCode)
                {
                    models.APIBookResultModel result = await res.Content.ReadAsAsync<models.APIBookResultModel>();

                    return result.docs.ToList<models.APIBookModel>();
                }
                else
                {
                    throw new Exception(res.ReasonPhrase);
                }
            }
        }

        #endregion


        #region DataTable Query Methods
        // filter users and transactions ArrayList method?

        public static models.DBBookModel _getBookFromTable(string searchQuery)
        {
            BookObject = new models.DBBookModel();
            return BookObject;
        }

        public static void _getUserFromTable(string searchQuery)
        {

        }

        public static ArrayList _getTransactionFromTable(string id)
        {

            TransactionListByQuery = new ArrayList();

            /*
             Requires DataTable search for transaction id or issuer_id

             Returns all transactions to array list for print format
             */

            return TransactionListByQuery;
        }


        public static void _filterUsersFromTable(string designation)
        {

            UserListByQuery = new ArrayList();
            //UserView = new DataGridView();

            /*
             Admin Query
             Requires DataTable search for designation. get all Employees, etc.

             Should update DataGridView
             */
        }

        #endregion

        #region Delete Methods
        public static bool _deleteTransactionFromDB(int ID)
        {
            String del;
            bool flag = false;
            try
            {
                using (_cntDatabase = new SqlConnection(Utils.CONNECT_STRING))
                {
                    del = "DELETE FROM " + Utils.DB + ".TRANSACTION_DETAILS ";
                    del += "WHERE TRANSACTION_ID = " + ID;

                    using (SqlCommand cmd = new SqlCommand(del, _cntDatabase))
                    {
                        _cntDatabase.Open();
                        cmd.ExecuteNonQuery();
                    }
                    flag = true;
                    CloseDB();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return flag;
        }

        #endregion

        #region Save Methods
        // Maps Object data to DB; Can be used to update
        // Runs on ```Are You Sure```
        public static void _saveBook(models.DBBookModel bookObj) { }

        public static void _saveUser(int user_id, String
            firstname, String lastname, String username, String password, String access)
        {
            String upd;

            user_id = Utils._IDGenerator();

            using (_cntDatabase = new SqlConnection(Utils.CONNECT_STRING))
            {
                _cntDatabase.Open();
                upd = "INSERT INTO " + Utils.DB + ".USER_DETAILS ";
                upd += "VALUES(@USER_ID, @USER_FIRSTNAME, @USER_LASTNAME, @USERNAME, @PASSWORD, @DESIGNATION)";
                using (var cmd = new SqlCommand(upd, _cntDatabase))
                {
                    cmd.Parameters.AddWithValue("@USER_ID", user_id);
                    cmd.Parameters.AddWithValue("@USER_FIRSTNAME", firstname);
                    cmd.Parameters.AddWithValue("@USER_LASTNAME", lastname);
                    cmd.Parameters.AddWithValue("@USERNAME", username);
                    cmd.Parameters.AddWithValue("@PASSWORD", password);
                    cmd.Parameters.AddWithValue("@DESIGNATION", access);

                    cmd.ExecuteNonQuery();
                }
                CloseDB();
            }
        }

        public static void _saveTransaction(models.TransactionModel transactionObj)
        {

        }

        #endregion
    }
}
