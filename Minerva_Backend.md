<h1 align="center">Minerva Backend</h1>

## Data

The database will contain 3 objects

- Users_Details
- Books_Details
- Transaction_Details



### Books_Details

|    Attribute    |       Type        | Description                                                  |
| :-------------: | :---------------: | ------------------------------------------------------------ |
|      ISBN       | int (primary key) | Unique identifier for each book                              |
|      TITLE      |      string       | Provides the name of the book.                               |
|  PUBLISH_DATE   |       date        | (JSON data may need conversion function) Contains the year of publication |
|    LANGUAGE     |      string       | Contains the language in which this book was published. (obj. may contain multiple) |
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

| Attribute |       Type        | Description                                         |
| :-------: | :---------------: | --------------------------------------------------- |
|  USER_ID  | int (foreign key) | Unique ID given to each User                        |
| USERNAME  |      string       | First name for each user                            |
|   ISBN    | int (foreign key) | Book ID                                             |
| QUANTITY  |        int        | Count of books checked out                          |
| ISSUED_BY |        int        | User ID of employee who facilitated the transaction |

### DB Methods

1. ```_getBook(string searchQuery)``` Method

   <em>Description:</em> API cannot do bulk data. Searching the API asynchronously can mimic a full library and we can create/remove an item on adding to cart (```_saveBook(Book bookObj)```)/purchase 

   <em>Return Value:</em> A large object with requested book data for display. User can select preferred book and it can be added to temporary ```DataTable``` and pushed to DB for purchases. 

   <em>Parameters</em>: Will need a search query as defined in ```utils.cs``` 

   

2. ```_getUser(string searchQuery)``` Method:
   <em>Description:</em> Searches through users table by whatever query.

   <em>Return Value:</em> An object with requested user's info

   <em>Parameters</em>: Can be filtered through ```DataTable```

   

3. ```_saveBook(Book bookObj)``` Method:

   <em>Description:</em> Pushes book info to table to later be filtered by users for transactions; helps crystal reports

   

4. ```_saveUser(User userObj)``` Method:

   <em>Description:</em> Pushes user info to table to later be filtered by employees and admin; Admin may modify/update any info

   

5.  ```_getTransactionsByUserID(int userID)``` Method:

   <em>Description:</em> Pulls all transactions by ```USER_ID``` to create receipt or search user history

    <em>Parameters</em>: Will need a SQL query to filter 

   

6. ```_getTransactionsByIssuer(int userID)``` Method:

   <em>Description:</em> Admin function that pulls the employee transactions

   <em>Parameters</em>: Will need a SQL query to filter 