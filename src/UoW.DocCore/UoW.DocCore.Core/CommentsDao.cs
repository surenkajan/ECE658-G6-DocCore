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

    public class CommentsDao
    {

        public List<Comments> GetCommentsByID(int DocID)
        {
            try
            {
                return Db.ReadList(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[CoreGetCommentsByID]",
                    GetCommentsFromReader,
                    "DocCoreMSSQLConnection",
                    new object[] { "@DocId", DocID });
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        private Comments GetCommentsFromReader(IDataReader reader)
        {
            return GetCommentsFromReader(reader, "AU");
        }

        public static Comments GetCommentsFromReader(IDataReader reader, string namePreFix)
        {
            Comments comment = new Comments();

            //TODO : Enable the Prefix later here and Stored Procedure
            comment.Comment = Db.GetValue(reader, "comments", "0");
            comment.FirstName = Db.GetValue(reader, "FirstName", "");
            comment.CommentsTime = Db.GetValue(reader, "CommentedTime", DateTime.Now);
            comment.LastName = Db.GetValue(reader, "LastName", "");
            comment.FullName = Db.GetValue(reader, "FullName", "");
            comment.UserID = Db.GetValue(reader, "commentedBy", 0);
            comment.DocID = Db.GetValue(reader, "cID", 0);
            if (!DBNull.Value.Equals(reader["ProfilePhoto"]))
            {
                byte[] imgBytes = (byte[])reader["ProfilePhoto"];
                string imgString = Convert.ToBase64String(imgBytes);
                comment.ProfilePhoto = String.Format("data:image/jpg;base64,{1}", "jpg", imgString);
            }
            else
            {
                comment.ProfilePhoto = null;
            }
            return comment;
        }

        public int AddCommentsByEmailID(Comments comment)
        {
            if (comment != null)
            {
                return Db.Insert(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[CoreAddCommentsByEmailID]",
                    "DocCoreMSSQLConnection",
                    new object[]
                {
                    "DocId", comment.DocID,
                    "currentUserEmailID", comment.EmailAddress,
                    "Comment", comment.Comment ,
                    "CommentsTime", DateTime.Now
                });
            }
            else
            {
                return -1;
            }
        }

    }
}
