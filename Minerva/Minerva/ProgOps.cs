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

        private static SqlConnection _cntDatabase;

        public static DataTable UserTable = new DataTable();
        public static DataTable BookTable = new DataTable();
        public static DataTable TransactionTable = new DataTable();
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
                MessageBox.Show("Connection Successful", "Success", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                MessageBox.Show(_connect);
            }
        }

        public void CloseDB()
        {
            _cntDatabase.Close();
            _cntDatabase.Dispose();
        }

        #endregion


        #region Load Methods

        public static String query;

        //Loads DataTables with initial and set data
        public static DataTable _getAllBooks()
        {
            // Used to store book information temporarily until a save is necessarily. To be cleared be wiped on each save
            query = Utils.DB_QUERY + "BOOK_DETAILS";

            using (_cntDatabase = new SqlConnection(Utils.CONNECT_STRING))
            using (SqlCommand cmd = new SqlCommand(query, _cntDatabase))
            {
                try
                {
                    if (_cntDatabase.State == ConnectionState.Closed) _cntDatabase.Open();
                    BookTable.Load(cmd.ExecuteReader());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return BookTable;
            }
        }

        public static DataTable _getAllUsers()
        {
            // UsersForm will require => DataGridView UserView
            query = Utils.DB_QUERY + "USER_DETAILS";

            using (_cntDatabase = new SqlConnection(Utils.CONNECT_STRING))
            using (SqlCommand cmd = new SqlCommand(query, _cntDatabase))
            {
                try
                {
                    if (_cntDatabase.State == ConnectionState.Closed) _cntDatabase.Open();
                    UserTable.Load(cmd.ExecuteReader());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return UserTable;
            }
        }
        public static DataTable _getAllTransactions()
        {
            // TransactionsForm will require => DataGridView TransactionView
            query = Utils.DB_QUERY + "TRANSACTION_DETAILS";

            using (_cntDatabase = new SqlConnection(Utils.CONNECT_STRING))
            using (SqlCommand cmd = new SqlCommand(query, _cntDatabase))
            {
                try
                {
                    if (_cntDatabase.State == ConnectionState.Closed) _cntDatabase.Open();
                    UserTable.Load(cmd.ExecuteReader());
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "There was a problem", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                return TransactionTable;
            }
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

        public static models.UserModel _getUserFromTable(string searchQuery)
        {
            UserObject = new models.UserModel();
            return UserObject;
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


        #region Save Methods
        // Maps Object data to DB; Can be used to update
        // Runs on ```Are You Sure```
        public static void _saveBook(models.DBBookModel bookObj) { }
        public static void _saveUser(models.UserModel userObj) { }
        public static void _saveTransaction(models.TransactionModel transactionObj) { }
        #endregion
    }
}
