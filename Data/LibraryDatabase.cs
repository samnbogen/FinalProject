using FinalProject.Entities;
using FinalProject.Exceptions;
using MySqlConnector;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

// Create connection to Book database and create search functions for it
// Created for CPRG 211 finale project
// created by Iza Lumpio, Lisa Pokam, Sohee Ryu, and Samantha Bogen
// April 25, 2023
namespace FinalProject.Data
{
    // for connecting to the database
    public class LibraryDatabase
    {
        private MySqlConnection connection;
        private string server;
        private string database;
        private string uid;
        private string password;
        public LibraryDatabase()
        {
            Initialize();
        }

        //Initialize the values needed for the connection
        private void Initialize()
        {
            server = "localhost";
            database = "finale";
            uid = "root";
            password = "password";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
            database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            connection = new MySqlConnection(connectionString);
        }

        //open connection to database
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        Console.WriteLine("Cannot connect to server.  Contact administrator");
                        break;

                    case 1045:
                        Console.WriteLine("Invalid username/password, please try again");
                        break;
                }
                return false;
            }
        }

        //Close connection
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }        

        //Select statement
        public List<Book> Select()
        {
            string query = "SELECT * FROM books";

            //Create a list to store the a book's properties/attributes


            // how to display the books?
            //1. then use this list to create a book class and then add it to another list which is gonna behe list of books?

            //2. or just just display the book's properties in one row

            // let's try 1 for now
            List<Book> books = new List<Book>();
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {

                    Book book = new Book(dataReader.GetString(0),
                                         dataReader.GetString(1),
                                         dataReader.GetString(2),
                                         dataReader.GetString(3),
                                         dataReader.GetString(4),
                                         dataReader.GetString(5));

                    // now add this book with its book properties to books
                    books.Add(book);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return books;
            }
            else
            {
                return books;
            }
        }

        ///<summary>
        /// searches the library database for a book and returns a list of related books
        ///</summary>
        public List<Book> SearchBook(string searchword)
        {
            List<Book> results = new List<Book>();

            string query = $"SELECT * FROM books where Title Like '%{searchword}%'";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Book book = new Book(dataReader.GetString(0),
                                         dataReader.GetString(1),
                                         dataReader.GetString(2),
                                         dataReader.GetString(3),
                                         dataReader.GetString(4),
                                         dataReader.GetString(5));

                    // add the book to the results if available
                    if (book.Is_Available == true)
                    {
                        results.Add(book);
                    }                    
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //return list to be displayed
                return results;
            }
            else
            {
                throw new ConnectionNotFoundException();
            }
        }

        //Searches for a book matching the genre selected
        public List<Book> SearchGenre(string searchword)
        {
            List<Book> results = new List<Book>();

            string query = $"SELECT * FROM books";
            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
               
                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    Book book = new Book(dataReader.GetString(0),
                                         dataReader.GetString(1),
                                         dataReader.GetString(2),
                                         dataReader.GetString(3),
                                         dataReader.GetString(4),
                                         dataReader.GetString(5));

                    //only getting the books that match the genre of the searchword
                    if (book.Genre == searchword)
                    // add the book to the results
                    results.Add(book);
                }

                //close Data Reader
                dataReader.Close();

                //close Connection
                this.CloseConnection();

                //check that the list has books on it
                if (results.Count <= 0)
                {
                    throw new BookNotFoundException();
                }

                //return list to be displayed
                return results;
            }
            else
            {
                throw new ConnectionNotFoundException();
            }       
        }                       
    }
}
