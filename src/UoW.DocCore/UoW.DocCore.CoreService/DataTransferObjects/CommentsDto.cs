using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UoW.DocCore.CoreService.DataTransferObjects
{
    [Serializable]
    [DataContract]
    public class CommentsDto
    {
        #region Database properties
        private int userID;
        [DataMember]
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        private String Firstname;
        [DataMember]
        public string FirstName
        {
            get { return Firstname; }
            set { Firstname = value; }
        }

        private String Lastname;
        [DataMember]
        public string LastName
        {
            get { return Lastname; }
            set { Lastname = value; }
        }

        private String Fullname;
        [DataMember]
        public string FullName
        {
            get { return Fullname; }
            set { Fullname = value; }
        }

        private String emailAddress;
        [DataMember]
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private DateTime? uploadTimeStamp;
        [DataMember]
        public DateTime? UploadTimeStamp
        {
            get { return uploadTimeStamp; }
            set { uploadTimeStamp = value; }
        }

        private String comments;
        [DataMember]
        public string Comments
        {
            get { return comments; }
            set { comments = value; }
        }

        private int docID;
        [DataMember]
        public int DocID
        {
            get { return docID; }
            set { docID = value; }
        }
        private string Profilephoto;
        [DataMember]
        public string ProfilePhoto
        {
            get { return Profilephoto; }
            set { Profilephoto = value; }
        }
        #endregion


    }
}
