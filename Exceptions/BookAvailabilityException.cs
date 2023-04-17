using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FinalProject.Exceptions
{
    //This is exception is thrown when the book is not available
    public class BookAvailabilityException : Exception
    {
        public BookAvailabilityException() :  base("Sorry, Looks like this book is unavilable at the moment") { }
    }
}
