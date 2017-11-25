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
    public class UserDto
    {
        #region Database Properties

        private int uid;
        [DataMember]
        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }

        private string userName;
        [DataMember]
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private int userID;
        [DataMember]
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }


        private string lastName;
        [DataMember]
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private DateTime? dateOfBirth;
        [DataMember]
        public DateTime? DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        private string emailAddress;
        [DataMember]
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private string firstName;
        [DataMember]
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string fullName;
        [DataMember]
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private string sex;
        [DataMember]
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string projectRole;
        [DataMember]
        public string ProjectRole
        {
            get { return projectRole; }
            set { projectRole = value; }
        }

        #endregion

        #region External Properties
        private string profilePhoto;
        [DataMember]
        public string ProfilePhoto
        {
            get { return profilePhoto; }
            set { profilePhoto = value; }
        }
        #endregion
    }
}
