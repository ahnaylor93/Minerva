using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Minerva
{
    public static class Utils
    {
        static Utils()
        {
            DotNetEnv.Env.Load();
        }

        public static string CONNECT_STRING => DotNetEnv.Env.GetString("CONNECT_STRING");

        // Query string... queries the API and returns JSON data
        public const string QUERY_STRING = @"http://openlibrary.org/search.json?q=";

        // API image queries are "https://covers.openlibrary.org/b/isbn/{ book ISBN }-M.jpg" i.e. IMAGE_QUERY + ISBN + IMG_TAG
        public const string IMAGE_QUERY = "https://covers.openlibrary.org/b/isbn/";
        public const string IMG_TAG = "-M.jpg";

        //dummy data
        public struct Credentials
        {
            public string _username;
            public String password;
            public String email;
            public String accessLevel;
        }

        public struct Employee
        {
            public int _employeeID;
            public String firstName;
            public String lastName;
            public String address;
            public String city;
            public String state;
            public int zip;
            public String hireDate;
            public String endDate;
            public String position;
            public String salary;
        }

        public struct User
        {
            public int _userID;
            public String firstName;
            public String lastName;
            public String address;
            public String city;
            public String state;
            public int zip;
            public String phone;
            public String email;
            //should be an array of books?
            public String checkedOut;
            //also an array?
            public String overdue;
            public float amountOwed;
        }

        public struct Books
        {
            public int _ISBN;
            public String title;
            public String author;
            public String publisher;
            public String pubDate;
            public String Quantity;
            // ??? based on quantity? How many or isCheckedIn/isCheckedOut
            public int checkedIn;
            public int checkedOut;
        }
    }
}
