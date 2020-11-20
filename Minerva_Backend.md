<h1 align="center">Minerva Backend</h1>

***!important: Double ```.env``` file. DO NOT DELETE*** 

## Data

The database will contain 3 objects

- Users_Details
- Books_Details
- Transaction_Details



### Books_Details

|    Attribute    |       Type        | Description                                                  |
| :-------------: | :---------------: | ------------------------------------------------------------ |
|      ISBN       | int (primary key) | Unique identifier for each book                              |
|     AUTHOR      |      string       | Author of book                                               |
|      TITLE      |      string       | Provides the name of the book.                               |
|    SUBTITLE     |      string       | Subtitle if any (default null)                               |
|  PUBLISH_DATE   |       date        | (JSON data may need conversion function) Contains the year of publication |
|    IMAGE_URL    |      string       | Stores URL of the book cover needs to be rendered.           |
| ACTUAL_QUANTITY |        int        | Default to 5. This column contains the total no. of copies of each book that were initially present. |
|   CHECKED_IN    |        int        | Current books in stock                                       |
|   CHECKED_OUT   |        int        | Current books checked out                                    |

### Users_Details

|   Attribute    |  Type  | Description                                 |
| :------------: | :----: | ------------------------------------------- |
|    USER_ID     |  int   | Unique ID given to each User                |
| USER_FIRSTNAME | string | First name for each user                    |
| USER_LASTNAME  | string | Last name for each user                     |
|    USERNAME    | string | Chosen username. Should be unique.          |
|    PASSWORD    | string | Chosen username.                            |
|  DESIGNATION   | string | Sets the user as patron, employee, or admin |

### Transaction_Details

|   Attribute    |       Type        | Description                                                  |
| :------------: | :---------------: | ------------------------------------------------------------ |
| TRANSACTION_ID |        int        | Transaction number. Generated and stored for each individual transaction |
|    USER_ID     | int (foreign key) | Unique ID given to each User; Possible search query to find all transactions by user |
|    USERNAME    |      string       | First name for each user                                     |
|      ISBN      | int (foreign key) | Book ID                                                      |
|    QUANTITY    |        int        | Count of books checked out                                   |
|   ISSUED_BY    |        int        | User ID of employee who facilitated the transaction; Possible search query to find all transactions by issuer |

### DB Methods

1. ```DataTable _getAllBooks()``` Method

   <em>Description:</em> Queries DB for all books and book data stored

   <em>Return Value:</em> Either null if no books or creates loaded ```DataTable``` with all current books

   

2. ```DataTable _getAllUsers()``` Method

   <em>Description:</em> Queries DB for all user information

   <em>Return Value:</em> Either null if no users or creates loaded ```DataTable``` with all current users

   

3. ```DataTable _getAllTransactions()``` Method

   <em>Description:</em> Queries DB for all transactions

   <em>Return Value:</em> Either null if none or creates loaded ```DataTable``` with all current transactions

   

4. ```Book _getBook(string searchQuery)``` Method

   <em>Description:</em> API cannot do bulk data. Searching the API asynchronously can mimic a full library and we can create/remove an item on adding to cart (```_saveBook(Book bookObj)```)/purchase 

   <em>Return Value:</em> A Book object with requested book data for display. User can select preferred book and it can be added to temporary ```DataTable``` and pushed to DB for checkout. 

   <em>Parameters</em>: Will need a search query as defined in ```utils.cs``` 

   

5. ```Book _getBookFromTable(string searchQuery)``` Method:
   <em>Description:</em> Searches through Book ```DataTable``` by whatever query.

   <em>Return Value:</em> An object with requested Book info

   <em>Parameters</em>: Will need a search query as defined in ```utils.cs``` 

   

6. ```User _getUserFromTable(string searchQuery)``` Method:
   <em>Description:</em> Searches through User ```DataTable``` by whatever query.

   <em>Return Value:</em> An object with requested User's info

   <em>Parameters</em>: Will need a search query as defined in ```utils.cs```

   

7. ```Array _getTransactionFromTable(string id)``` Method:
   <em>Description:</em> Searches through users table by whatever query.

   <em>Return Value:</em> An ```ArrayList``` with all matching transaction by id

   <em>Parameters</em>: Will need a search query as defined in ```utils.cs```

   

8. ```User _filterUserFromTable(string designation)``` Method:
   <em>Description:</em> filters saved users and updates ```User DataGridView```; Admin only query

   <em>Parameters</em>: Search by requested designation; employee, patron, admin.

   

9. ```void _saveBook(Book bookObj)``` Method:

   <em>Description:</em> Pushes book info to table to later be filtered by users for transactions; helps crystal reports

   

10. ```_saveUser(User userObj)``` Method:

   <em>Description:</em> Pushes user info to table to later be filtered by employees and admin; Admin may modify/update any info

   

11. ```_saveTransaction(Transaction userObj)``` Method:

    <em>Description:</em> Pushes transaction info for each to table to later be filtered by employees and admin