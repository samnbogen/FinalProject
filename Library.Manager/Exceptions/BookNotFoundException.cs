using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Manager.Exceptions
{
    //This exception is throws when the book is not found 
    public class BookNotFoundException : Exception
    {
        public BookNotFoundException() : base("Sorry, we cannot find the book you're looking for") { }
    }
}
