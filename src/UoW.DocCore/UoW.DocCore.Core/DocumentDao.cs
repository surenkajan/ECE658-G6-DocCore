namespace UoW.DocCore.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using UoW.DocCore.BusinessObjects;
    using UoW.DocCore.DataObjects.ADO.NET;
    using UoW.DocCore.DocCoreUtilities;

    public class DocumentDao
    {
        public List<Document> GetAllDocuments()
        {
            return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[GetAllDocuments]",
                GetDocumentFromReader, "DocCoreMSSQLConnection",
                new object[] { "UserTablePreFix", "AU" });
        }

        public Document GetDocumentByDocID(string DocID)
        {
            try
            {
                return Db.Read(Db.QueryType.StoredProcedure, "[doccore].[GetDocumentByDocID]",
                    GetDocumentFromReader, "DocCoreMSSQLConnection",
                    new object[] { "DocID", DocID, "UserTablePreFix", "AU" });
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }
        
        public Document GetDocumentWithContentByDocID(string DocID)
        {
            try
            {
                return Db.Read(Db.QueryType.StoredProcedure, "[doccore].[GetDocumentByDocIDWithFileContent]",
                    GetDocumentFromReader, "DocCoreMSSQLConnection",
                    new object[] { "DocID", DocID, "UserTablePreFix", "AU" });
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        public List<Document> GetAllDocumentsUploadedByEmailID(string EmailID)
        {
            try
            {
                return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[GetAllDocumentsUploadedByEmailID]",
                GetDocumentFromReader, "DocCoreMSSQLConnection",
                new object[] { "EmailID", EmailID, "UserTablePreFix", "AU" });
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        public List<Document> GetAllSharedDocumentsForEmailID(string EmailID)
        {
            try
            {
                return Db.ReadList(
                    Db.QueryType.StoredProcedure, 
                    "[doccore].[GetAllSharedDocumentsForEmailID]",
                    GetDocumentFromReader, 
                    "DocCoreMSSQLConnection",
                    new object[] 
                    {
                        "EmailID", EmailID,
                        "UserTablePreFix", "AU"
                    });
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        public List<Document> GetUploadedAndSharedWithMeByEmailID(string U_User, string L_User)
        {
            try
            {
                return Db.ReadList(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[GetUploadedAndSharedWithMeByEmailID]",
                    GetDocumentFromReader,
                    "DocCoreMSSQLConnection",
                    new object[]
                    {
                        "U_User", U_User,
                        "L_User", L_User,
                        "UserTablePreFix", "AU"
                    });
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        public List<User> GetAllSharedUsersForDocID(int DocID)
        {
            try
            {
                List<User> userList =  Db.ReadList(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[GetAllSharedUsersForDocID]",
                    GetUserFromReader,
                    "DocCoreMSSQLConnection",
                    new object[]
                    {
                        "DocID", DocID
                    });

                return userList;
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        public int AddDocument(Document Doc)
        {
            int DocID = -1;
            if (Doc != null && Doc.FileName != null && Doc.FileData != null)
            {
                DocID = Db.Insert(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[CoreAddDocument]",
                    "DocCoreMSSQLConnection",
                    new object[]
                {
                    "FileName", Doc.FileName,
                    "FileType", Doc.FileType,
                    "FileData", Doc.FileData,
                    "FileSummary", Doc.FileSummary,
                    "FileSizeInKB", Doc.FileSizeInKB,
                    "UploadedBy", Doc.UploadedBy,
                    "UploadedTime", Doc.UploadedTime,
                    "IsCheckedIn", Doc.IsCheckedIn,
                    "ModifiedBy", Doc.ModifiedBy,
                    "Modified", Doc.Modified
                });
            }
            else
            {
                DocID = -1;
            }
            return DocID;
        }

        public int UpdateDocument(Document Doc)
        {
            if (Doc != null && Doc.DocID > 0 && Doc.FileName != null)
            {
                if (Doc.FileData != null)
                {
                    return Db.Update(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[UpdateDocument]",
                    "DocCoreMSSQLConnection",
                    new object[]
                    {
                        "DocID", Doc.DocID,
                        "FileName", Doc.FileName,
                        "FileType", Doc.FileType,
                        "FileData", Doc.FileData,
                        "FileSummary", Doc.FileSummary,
                        "FileSizeInKB", Doc.FileSizeInKB,
                        "UploadedBy", Doc.UploadedBy,
                        "UploadedTime", Doc.UploadedTime,
                        "IsCheckedIn", Doc.IsCheckedIn,
                        "ModifiedBy", Doc.ModifiedBy,
                        "Modified", Doc.Modified,
                        "SharedWith", string.Join(";", Doc.SharedWith.Select(x => x.FullName))
                    });
                }
                else
                {
                    return Db.Update(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[UpdateDocumentMetaData]",
                    "DocCoreMSSQLConnection",
                    new object[]
                    {
                        "DocID", Doc.DocID,
                        "FileName", Doc.FileName,
                        "FileType", Doc.FileType,
                        "FileSummary", Doc.FileSummary,
                        "FileSizeInKB", Doc.FileSizeInKB,
                        "UploadedBy", Doc.UploadedBy,
                        "UploadedTime", Doc.UploadedTime,
                        "IsCheckedIn", Doc.IsCheckedIn,
                        "ModifiedBy", Doc.ModifiedBy,
                        "Modified", Doc.Modified,
                        "SharedWith", string.Join(";", Doc.SharedWith.Select(x => x.FullName))
                    });
                }
            }
            else
            {
                return -1;
            }
        }

        public int DeleteDocument(string DocID)
        {
            if (DocID != null)
            {
                return Db.Delete(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[DeleteDocument]",
                    "DocCoreMSSQLConnection",
                   new object[] { "DocID", DocID });
            }
            else
            {
                return -1;
            }
        }


        /// <summary>
        /// Gets the Document from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private Document GetDocumentFromReader(IDataReader reader)
        {
            return GetDocumentFromReader(reader, "AU");
        }

        /// <summary>
        /// Gets the Document from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="namePreFix">The name pre fix.</param>
        /// <returns></returns>
        public static Document GetDocumentFromReader(IDataReader reader, string namePreFix)
        {
            UserDao userDao = new UserDao();
            DocumentDao docDao = new DocumentDao();

            Document document = new Document();
            document.DocID = Db.GetValue(reader, "DocID", 0);
            document.FileName = Db.GetValue(reader, "FileName", "");
            document.FileType = Db.GetValue(reader, "FileType", "");
            document.FileSummary = Db.GetValue(reader, "FileSummary", "");
            document.FileSizeInKB = Db.GetValue(reader, "FileSizeInKB", 0);
            //document.FileData = (reader["FileData"] != null || !DBNull.Value.Equals(reader["FileData"])) ? (byte[])reader["FileData"] : null;

            if (!DBNull.Value.Equals(reader["FileData"]))
            {
                document.FileData = (byte[])reader["FileData"];
            }
            else
            {
                document.FileData = null;
            }

            document.UploadedBy = Db.GetValue(reader, "UploadedBy", "");
            document.UploadedTime = Db.GetValue(reader, "UploadedTime", DateTime.Now);
            document.IsCheckedIn = Db.GetValue(reader, "IsCheckedIn", 0);
            document.ModifiedBy = Db.GetValue(reader, "ModifiedBy", "");
            document.Modified = Db.GetValue(reader, "Modified", DateTime.Now);
            //TODO: Do not do like this since it will reduce the perfomance by introducing more SQL Queries. Handle this in Stored Procedures with Nested Joins
            document.CreatedUser = userDao.GetUserByEmailID(document.UploadedBy);
            document.ModifiedUser = userDao.GetUserByEmailID(document.ModifiedBy);
            document.SharedWith = docDao.GetAllSharedUsersForDocID(document.DocID);
            return document;
        }

        public User GetUserFromReader(IDataReader reader)
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
