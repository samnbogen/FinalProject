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

        public Book()
        {

        }

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

        public string ReserveBook()
        {
            DateTime currentDate = DateTime.Now;
            DateTime dueDate = currentDate.AddDays(2);

            return dueDate.ToString("D");
        }

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
    }
}
