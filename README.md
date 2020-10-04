# 				Minerva Design Document

## **Table of Contents**
* [Summary](Summary)
* [Architecture/Design](Architecture/Design)
* [Presentation Layer](Presentation Layer)
* [Business Layer](Business Layer)
* [Tech Stack](Tech Stack)
* [API](API)
* [Access Levels](Access Levels)

## **Summary**	

Minerva is an all-in-one library management system allowing for three levels of access: user, employee, and administrator. Users will be able to login to view the library’s catalogue as well as view their checked out books, when they’re due, and any charges they may owe to the library. With employee level access, Minerva will allow an employee to check out books for users and adopt or retire books from the library’s collection. Minerva will present to those with administrative access the ability to manage the library’s employees and adjust the access levels of other users. Minerva is aimed to be a powerful tool to professionally manage the world’s centers of knowledge.

## **Architecture/Design**

Minerva will have just three separate concerns: 

* allowing users to explore and get information from the library’s collection 
* allowing employees to do the work of cleaning all information
* allowing admin to manage employees and user’s permissions.

## **Presentation Layer**
Note: Markups subject to change

![img](https://lh6.googleusercontent.com/US8bDDV5rT-U-FE-6a_AJNWKvoO7o7ZP3R5PtBZo2-KZkdVFRXJw_6BdAe1WAnQws2vzkrgyRVCarHQCAfZoGxqSL9ucs9CbSTCXQP54_fOsEIUOVFI8GbkHjGVWQPARR-pesvje)

The log in will be the same for all users. It will be up to the admin to set access level. 

![img](https://lh3.googleusercontent.com/tnjiwOnHeyNvqlHB9JQFUkJTYP1C4bpUmVX7QN6zQHCQUoS72oUhCpUKKhKhLOcTLEOUqwqmvVgBSQa8frUXOa7cJYO3Dwz98fvgzCMPN6GrLR_4nKkebAqmg8SF2Uaz4QS0Ex0L)

After, on the landing page the user can search for any book available, add it to their cart and check out. A simple UI where you can search and find any book by any means.

 **Business Layer** :	

​	Set mostly by employees. Again, it is where you can print receipts, view and execute transactions, and perform CRUD operations on books. The **Data Layer** is the same with the addition of Admin total control.

## **Tech Stack**

* C#/.NET to build the application 	
* MS-SQLto construct the database
* Database Integration with Visual Studio
* GitHub and Postman to promote collaboration and provide version control.



## **API**

The Open Library API will allow Minerva to pull the latest up-to-date information on each book within the library database, resulting in accurate information and descriptions. It can be found here: https://www.programmableweb.com/api/open-library-books

# **Plans**![img](https://lh3.googleusercontent.com/OYdS9zidlkEFk-crNirDLkfVevzM1k0hrIL29q3LwrUGxnXQt-Rv2joq4LaxclAw6vXg4YuuSyWvV56Rbh8L1htK4rrHwyK87U361QTeMGkM76vhWNEGq5yS6zf3TTrT6HYG0zds)

Crystal Reports will be used to generate both activity reports and receipts for users after checking out/returning a booklogin sequence for privilegeCredentials and access level are tied to a UserIDAccess level is checked at log-in time, program behavior is modified by the access of the account used to log-inAdmin requires a separate password or code to promote other users to administratorsSearchingUsers may choose to search by Title, Author, Publisher, Publish Date, ISBN, or any combination of theseOnce the desired book has been found, a user may view if the library has any non-checked-out copies and an employee my check out or return copies of the book

## **Access Levels**

* **User**
  * Lowest-level access
  * May browse the library’s collection
  * Read-only access to each book’s information within the library
* **Employee**
  * A librarian or someone with similar duties within a library
  * Can check books in and out, assigning them to users
  * Capable of adding or removing (curating) to or from the library’s collection
* **Administrator**
  * Highest level of access
  * May promote access of other users
  * Can view the salaries of each employee and other administrators
  * Capable of adding and removing employees
