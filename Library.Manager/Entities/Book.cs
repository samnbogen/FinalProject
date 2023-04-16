using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Manager.Entities
{
    public class Book
    {
        public string Title { get; set; }
        public long Isbn { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public bool Status { get; set; }

        public Book() 
        {
        
        }
        public Book(string title, string author, string publisher, string genre, long isbn, bool status) 
        {
            this.Title = title;
            this.Author = author;
            this.Publisher = publisher;
            this.Genre = genre;
            this.Isbn = isbn;
            this.Status = status;
        }

        public string CheckOut()
        {
            DateTime currentDate = DateTime.Now;
            DateTime checkoutDate = currentDate.AddDays(21);

            return checkoutDate.ToString("D");
        }

        public void Returned()
        {
            //Not sure how to make this function

        }

    }
}
