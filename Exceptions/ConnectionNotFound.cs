using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Exceptions
{
    //This exception is throws when the connection to the database is not found
    internal class ConnectionNotFoundException : Exception
    {
        public ConnectionNotFoundException() : base("Sorry, we cannot find the connection") { }
    }
}
