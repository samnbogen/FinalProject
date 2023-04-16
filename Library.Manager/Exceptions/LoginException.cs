using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Manager.Exceptions
{
    //if the username or passwors is invalid this exception is thrown
    public class LoginException : Exception
    {
        public LoginException() : base("Invalid username or password"){ }
    }
}
