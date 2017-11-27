using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.DocCore.BusinessObjects
{
    public class Share : BusinessObject
    {
        private int did;
        public int Did
        {
            get { return did; }
            set { did = value; }
        }

        private List<User> users;
        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }

    }
}
