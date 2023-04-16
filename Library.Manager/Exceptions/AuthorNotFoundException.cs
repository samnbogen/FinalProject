using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Manager.Exceptions
{
    //This exception is throws when it cannot find the author
    public class AuthorNotFoundException : Exception
    {
        public AuthorNotFoundException() : base("Sorry we canno find the author you're looking for") { }
    }
}
