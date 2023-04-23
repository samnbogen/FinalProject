//using Android.Provider;
using FinalProject.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class Book
    {

        public string Title { get; set; }
        public string Isbn { get; set; }
        public string Author_FirstName { get; set; }

        public string Author_LastName { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public bool Is_Available { get; set; }

        /// <summary>
        /// Book constructor with no inputs
        /// </summary>
        public Book()
        {

        }

        /// <summary>
        /// Book class constructor, takes in the following parameters
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isbn"></param>
        /// <param name="f_name"></param>
        /// <param name="l_name"></param>
        /// <param name="publisher"></param>
        /// <param name="genre"></param>
        public Book(string title, string isbn, string f_name, string l_name, string publisher, string genre)
        {
            this.Title = title;
            this.Isbn = isbn;
            this.Author_FirstName = f_name;
            this.Author_LastName = l_name;
            this.Publisher = publisher;
            this.Genre = genre;
            this.Is_Available = true;
        }

        /// <summary>
        /// Book class constructor, has additional parameter than the previous one.
        /// </summary>
        /// <param name="title"></param>
        /// <param name="isbn"></param>
        /// <param name="f_name"></param>
        /// <param name="l_name"></param>
        /// <param name="publisher"></param>
        /// <param name="genre"></param>
        /// <param name="is_available"></param>
        public Book(string title, string isbn, string f_name, string l_name, string publisher, string genre, bool is_available)
        {
            this.Title = title;
            this.Isbn = isbn;
            this.Author_FirstName = f_name;
            this.Author_LastName = l_name;
            this.Publisher = publisher;
            this.Genre = genre;
            this.Is_Available = is_available;
        }

        /// <summary>
        /// Reserves the book by computing the due date it's to be returned
        /// </summary>
        /// <returns> a string of the book's due date</returns>
        public string ReserveBook()
        {
            DateTime currentDate = DateTime.Now;
            DateTime dueDate = currentDate.AddDays(2);

            return dueDate.ToString("D");
        }

        /// <summary>
        /// turns back the book to be available
        /// </summary>
        public void Returned()
        {
            //Not sure how to make this function

        }

        public string Display()
        {
            string status = "In Use";
            if (this.Is_Available)
            {
                status = "Available";
            }
            return $"{Isbn} {Title} {Genre} {Author_FirstName} {Author_FirstName} {status}";
        }

        public void placeHold()
        {
            if (this.Is_Available == true) 
            {
                this.Is_Available = false;
            }
            else
            {
                throw new BookAvailabilityException();
            }
            
        }

        public void cancelHold()
        {
            if (this.Is_Available == false)
            {
                this.Is_Available = true;
            }
            else
            {
                throw new BookAvailabilityException();
            }
        }


        public string OnReserveDisplay()
        {
            string status = "In Use";
            if (this.Is_Available)
            {
                status = "Available";
            }
            return $"{Isbn} {Title} {Genre} {Author_FirstName} {Author_LastName} ";
        }


    }
}
