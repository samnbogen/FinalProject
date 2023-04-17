using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Entities
{
    public class Member
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public long CardId { get; set; }

        public Member()
        {

        }

        public Member(string username, string password, long cardId)
        {
            Username = username;
            Password = password;
            CardId = cardId;
        }

        //Not sure if this be void or a returned fuction

        //All the books he user checkedout and not retured yet
        public void CheckedOutBooks()
        {

        }

        //All the books that the user has retured and/or checked out
        //in one list 
        public void HistoryOfBooks()
        {

        }
    }
}
