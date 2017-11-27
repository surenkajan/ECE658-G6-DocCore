using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using UoW.DocCore.BusinessObjects;

namespace UoW.DocCore.CoreService.DataTransferObjects
{
    [Serializable]
    [DataContract]
    public class ShareDto
    {
        private int did;
        [DataMember]
        public int Did
        {
            get { return did; }
            set { did = value; }
        }

        private List<User> users;
        [DataMember]
        public List<User> Users
        {
            get { return users; }
            set { users = value; }
        }
    }
}
