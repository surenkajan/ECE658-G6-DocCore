using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.DocCore.BusinessObjects
{
    public class User : BusinessObject
    {
        #region Database properties
        private int uid;
        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }
        private string lastName;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private int userID;
        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }


        private string userName;
        /// <summary>
        /// Gets or sets the userName.
        /// </summary>
        /// <value>
        /// The userName.
        /// </value>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private DateTime? dateOfBirth;
        /// <summary>
        /// Gets or sets the date of birth.
        /// </summary>
        /// <value>
        /// The date of birth.
        /// </value>
        public DateTime? DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private string middleNames;
        public string MiddleNames
        {
            get { return middleNames; }
            set { middleNames = value; }
        }

        private string sex;
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }

        private string employeeDesignation;
        /// <summary>
        /// Gets or sets the employee designation.
        /// </summary>
        /// <value>
        /// The employee designation.
        /// </value>
        public string EmployeeDesignation
        {
            get { return employeeDesignation; }
            set
            {
                employeeDesignation = value;
            }
        }

        #endregion

        #region External Properties
        /// <summary>
        /// Gets or sets the profile image.
        /// </summary>
        /// <value>
        /// The profile image.
        /// </value>
        private string profilePhoto;
        public string ProfilePhoto
        {
            get { return profilePhoto; }
            set { profilePhoto = value; }
        }


        #endregion

    }
}
