namespace UoW.DocCore.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Text;
    using UoW.DocCore.BusinessObjects;
    using UoW.DocCore.DataObjects.ADO.NET;
    using UoW.DocCore.DocCoreUtilities;

    public class UserDao
    {
        /// <summary>
        /// Gets the Deatils of the user by Email ID.
        /// </summary>
        /// <param name="loginName">Name of the login.</param>
        /// <returns></returns>
        public User GetUserByEmailID(string emailID)
        {
            try
            {
                return Db.Read(Db.QueryType.StoredProcedure, "[doccore].[CoreGetUserByEmailID]", GetUserFromReader, "DocCoreMSSQLConnection",
                    new object[] { "EmailAddress", emailID, "UserTablePreFix", "AU" });
                //return new User() { FirstName = "User1FN", LastName = "User1LN", EmailAddress = "user1@gmail.com   ", DateOfBirth = DateTime.Now, FullName = "User1 User 1", Sex = "Male" };
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }
        public User GetUserRoleByEmailID(string emailID)
        {
            try
            {
                return Db.Read(Db.QueryType.StoredProcedure, "[doccore].[CoreGetUserRoleByEmailID]", GetUserFromReader, "DocCoreMSSQLConnection",
                    new object[] { "EmailAddress", emailID });
                //return new User() { FirstName = "User1FN", LastName = "User1LN", EmailAddress = "user1@gmail.com   ", DateOfBirth = DateTime.Now, FullName = "User1 User 1", Sex = "Male" };
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }
        public List<User> GetUserByFullName(string fullName)
        {
            try
            {
                return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[CoreGetUserByFullName]", GetUserFromReader, "DocCoreMSSQLConnection",
                    new object[] { "Fullname", fullName });
                //return new User() { FirstName = "User1FN", LastName = "User1LN", EmailAddress = "user1@gmail.com   ", DateOfBirth = DateTime.Now, FullName = "User1 User 1", Sex = "Male" };
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        /// Gets the Deatils of the user by Email ID.
        /// </summary>
        /// <param name="loginName">Name of the login.</param>
        /// <returns></returns>
        public User GetUserByUid(int uid)
        {
            try
            {
                return Db.Read(Db.QueryType.StoredProcedure, "[doccore].[CoreGetUserByUid]", GetUserFromReader, "DocCoreMSSQLConnection",
                    new object[] { "Uid", uid });
                //return new User() { FirstName = "User1FN", LastName = "User1LN", EmailAddress = "user1@gmail.com   ", DateOfBirth = DateTime.Now, FullName = "User1 User 1", Sex = "Male" };
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        /// <summary>

        /// <summary>
        /// Add New user the DB once the ASP.Net Auth registration completes
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddNewUserByEmailID(User user)
        {
            if (user != null && user.EmailAddress != null && user.FirstName != null && user.DateOfBirth != null && user.Sex != null)
            {
                return Db.Insert(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[CoreAddUserByEmailID]",
                    "DocCoreMSSQLConnection",
                    new object[]
                {
                    "UserName", user.UserName,
                    "FirstName", user.FirstName,
                    "LastName", user.LastName,
                    "FullName", user.FullName,
                    "EmailAddress", user.EmailAddress,
                    "DateOfBirth", user.DateOfBirth,
                    "Sex", user.Sex,
                    "ProfilePhoto", Convert.FromBase64String(user.ProfilePhoto)
                });
            }
            else
            {
                return -1;
            }
        }

        //UpdateUserByEmailID
        /// <summary>
        /// Add New user the DB once the ASP.Net Auth registration completes
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateUserByEmailID(User user)
        {
            if (user != null && user.EmailAddress != null && user.FirstName != null && user.DateOfBirth != null && user.Sex != null)
            {
                return Db.Update(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[CoreUpdateUserByEmailID]",
                    "DocCoreMSSQLConnection",
                    new object[]
                {
                    "UserName", user.UserName,
                    "FirstName", user.FirstName,
                    "LastName", user.LastName,
                    "FullName", user.FullName,
                    "EmailAddress", user.EmailAddress,
                    "DateOfBirth", user.DateOfBirth,
                    "Sex", user.Sex,
                    "ProfilePhoto", Convert.FromBase64String(user.ProfilePhoto)
                });
            }
            else
            {
                return -1;
            }
        }


        /// <summary>
        /// Delete User By EmailID
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int DeleteUserByEmailID(string emailID)
        {
            if (emailID != null)
            {
                return Db.Delete(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[CoreDeleteUserByEmailID]",
                    "DocCoreMSSQLConnection",
                   new object[] { "EmailAddress", emailID });
            }
            else
            {
                return -1;
            }
        }

        //

        public List<User> GetAllUsers()
        {
            return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[CoreAllUsers]",
                GetAllUserFromReader, "DocCoreMSSQLConnection",
                new object[] { "UserTablePreFix", "AU" });
        }
        public List<User> GetAllUserDetails()
        {
            return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[CoreGetAllUserDetails]",
                GetAllUserFromReader, "DocCoreMSSQLConnection",
                new object[] {});
        }
        public List<User> GetAllManagers()
        {
            return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[CoreGetAllManagers]",
                GetMemberFromReader, "DocCoreMSSQLConnection",
                new object[] { "UserTablePreFix", "AU" });
        }
        public List<User> GetAllTeamMembers()
        {
            return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[CoreGetAllTeamMembers]",
                GetMemberFromReader, "DocCoreMSSQLConnection",
                new object[] { "UserTablePreFix", "AU" });
        }
        public List<User> GetAllManagersByProjectID(int ID)
        {
            return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[CoreGetAllManagersByID]",
                GetMemberFromReader, "DocCoreMSSQLConnection",
                new object[] { "ProjectID", ID });
        }
        public List<User> GetAllTeamMembersByProjectID(int ID)
        {
            return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[CoreGetAllTeamMembersByID]",
                GetMemberFromReader, "DocCoreMSSQLConnection",
                new object[] { "ProjectID", ID });
        }
        private User GetMemberFromReader(IDataReader reader)
        {
            return GetMemberFromReader(reader, "AU");
        }

        private User GetAllUserFromReader(IDataReader reader)
        {
            return GetAllUserFromReader(reader, "AU");
        }
        public static User GetAllUserFromReader(IDataReader reader, string namePreFix)
        {
            User user = new User();

            user.UserID = Db.GetValue(reader, "ID", 0);
            user.UserName = Db.GetValue(reader, "UserName", "");
            user.FirstName = Db.GetValue(reader, "FirstName", "");
            user.LastName = Db.GetValue(reader, "LastName", "");
            user.FullName = Db.GetValue(reader, "FullName", "");
            user.EmailAddress = Db.GetValue(reader, "EmailAddress", "");
            user.DateOfBirth = Db.GetValue(reader, "DateOfBirth", DateTime.Now);
            user.Sex = Db.GetValue(reader, "Sex", "");
            user.Uid = Db.GetValue(reader, "ID", 0);
            user.ProjectRole = Db.GetValue(reader, "projectRole", "");
            if (!DBNull.Value.Equals(reader["ProfilePhoto"]))
            {
                byte[] imgBytes = (byte[])reader["ProfilePhoto"];
                string imgString = Convert.ToBase64String(imgBytes);
                user.ProfilePhoto = String.Format("data:image/jpg;base64,{1}", "jpg", imgString);
            }
            else
            {
                //Image image = Image.FromFile(@"\images\avator.png");
                //user.ProfilePhoto = Common.ImageToBase64(image);
                user.ProfilePhoto = null;
            }
            return user;
        }
        public static User GetMemberFromReader(IDataReader reader, string namePreFix)
        {
            User user = new User();

            user.UserID = Db.GetValue(reader, "ID", 0);
            user.FullName = Db.GetValue(reader, "FullName", "");
            user.EmailAddress = Db.GetValue(reader, "EmailAddress", "");
            //user.UserName = Db.GetValue(reader, "UserName", "");
            //user.FirstName = Db.GetValue(reader, "FirstName", "");
            //user.LastName = Db.GetValue(reader, "LastName", "");

            //user.DateOfBirth = Db.GetValue(reader, "DateOfBirth", DateTime.Now);
            //user.Sex = Db.GetValue(reader, "Sex", "");
            //user.Uid = Db.GetValue(reader, "ID", 0);
            //user.ProjectRole = Db.GetValue(reader, "projectRole", "");
           
            return user;
        }
        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private User GetUserFromReader(IDataReader reader)
        {
            return GetUserFromReader(reader, "AU");
        }

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="namePreFix">The name pre fix.</param>
        /// <returns></returns>
        public static User GetUserFromReader(IDataReader reader, string namePreFix)
        {
            User user = new User();

            user.UserID = Db.GetValue(reader, "ID", 0);
            user.UserName = Db.GetValue(reader, "UserName", "");
            user.FirstName = Db.GetValue(reader, "FirstName", "");
            user.LastName = Db.GetValue(reader, "LastName", "");
            user.FullName = Db.GetValue(reader, "FullName", "");
            user.EmailAddress = Db.GetValue(reader, "EmailAddress", "");
            user.DateOfBirth = Db.GetValue(reader, "DateOfBirth", DateTime.Now);
            user.Sex = Db.GetValue(reader, "Sex", "");
            user.Uid = Db.GetValue(reader, "ID", 0);
            //user.ProjectRole = Db.GetValue(reader, "projectRole", "");
            if (!DBNull.Value.Equals(reader["ProfilePhoto"]))
            {
                byte[] imgBytes = (byte[])reader["ProfilePhoto"];
                string imgString = Convert.ToBase64String(imgBytes);
                user.ProfilePhoto = String.Format("data:image/jpg;base64,{1}", "jpg", imgString);
            }
            else
            {
                //Image image = Image.FromFile(@"\images\avator.png");
                //user.ProfilePhoto = Common.ImageToBase64(image);
                user.ProfilePhoto = null;
            }
            return user;
        }
    }
}
