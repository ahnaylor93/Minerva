using System;
using System.Collections;
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

        #region Initialized DataTables, DataGridViews, and TransactionList
        // DataGridViews to view and filter Users and Transactions
        // TransactionList for Receipts and Admin filtering

        public static DataTable UserTable;
        public static DataTable BookTable;
        public static DataTable TransactionTable;
        public static DataGridView UserView;
        public static DataGridView TransactionView;
        public static ArrayList TransactionListByQuery;
        public static ArrayList UserListByQuery;

        #endregion


        #region Initialized Model Objects

        public static models.Book BookObject;
        public static models.Transaction TransactionObject;
        public static models.User UserObject;

        #endregion

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

        private void _queryAPI()
        {
            /*
             TODO: Create data fetch 
             */
        }

        #region Load Methods
        //Loads DataTables with initial and set data

        public static void _getAllBooks() { }
        public static void _getAllUsers() { /* Should also set UserView */ }
        public static void _getAllTransactions() { /* Should also set TransactionView */ }

        #endregion


        #region API Query Method
        // Searches API for book and creates C# object to be saved

        public static models.Book _getBook(string searchQuery)
        {
            // ArrayList for Async Searches?

            BookObject = new models.Book();
            dynamic apiQuery = Utils.QUERY_STRING + searchQuery;
            dynamic jsonObject = Utils._deserializeJSON(apiQuery);

            // Separate API Query
            String imageQuery = Utils.IMAGE_QUERY + jsonObject.ISBN + Utils.IMG_TAG;

            // set jsonObject values to BookObject values where needed. e.g. jsonObject.ISBN ect

            BookObject.subtitle = jsonObject.subtitle ? jsonObject.subtitle : null;

            return BookObject;
        }

        #endregion


        #region DataTable Query Methods
        // filter users and transactions ArrayList method?

        public static models.Book _getBookFromTable(string searchQuery)
        {
            BookObject = new models.Book();
            return BookObject;
        }

        public static models.User _getUserFromTable(string searchQuery)
        {
            UserObject = new models.User();
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
            UserView = new DataGridView();

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
        public static void _saveBook(models.Book bookObj) { }
        public static void _saveUser(models.User userObj) { }
        public static void _saveTransaction(models.Transaction transactionObj) { }
        #endregion
    }
}
