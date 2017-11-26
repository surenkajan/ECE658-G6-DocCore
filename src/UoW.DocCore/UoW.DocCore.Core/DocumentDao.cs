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

    public class DocumentDao
    {
        public List<Document> GetAllDocuments()
        {
            return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[GetAllDocuments]",
                GetUserFromReader, "DocCoreMSSQLConnection",
                new object[] { "UserTablePreFix", "AU" });
        }

        public Document GetDocumentByDocID(string DocID)
        {
            try
            {
                return Db.Read(Db.QueryType.StoredProcedure, "[doccore].[GetDocumentByDocID]",
                    GetUserFromReader, "DocCoreMSSQLConnection",
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
                GetUserFromReader, "DocCoreMSSQLConnection",
                new object[] { "EmailID", EmailID,  "UserTablePreFix", "AU" });
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
                return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[GetAllSharedDocumentsForEmailID]",
                GetUserFromReader, "DocCoreMSSQLConnection",
                new object[] { "EmailID", EmailID, "UserTablePreFix", "AU" });
            }
            catch (Exception ex)
            {
                EventLog.WriteEntry("Core Service", ex.Message + "\n Stack trace: " + ex.StackTrace);
                throw;
            }
        }

        public int AddDocument(Document Doc)
        {
            if (Doc != null && Doc.FileName != null && Doc.FileData != null)
            {
                return Db.Insert(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[AddDocument]",
                    "DocCoreMSSQLConnection",
                    new object[]
                {
                    "FileName", Doc.FileName,
                    "FileType", Doc.FileName,
                    "FileSummary", Doc.FileName,
                    "FileData", Doc.FileName,
                    "UploadedBy", Doc.FileName,
                    "UploadedTime", Doc.FileName
                });
            }
            else
            {
                return -1;
            }
        }

        public int UpdateDocument(Document Doc)
        {
            if (Doc != null && Doc.DocID > 0 && Doc.FileName != null && Doc.FileData != null)
            {
                return Db.Update(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[UpdateDocument]",
                    "DocCoreMSSQLConnection",
                    new object[]
                {
                    "DocID", Doc.DocID,
                    "FileName", Doc.FileName,
                    "FileType", Doc.FileName,
                    "FileSummary", Doc.FileName,
                    "FileData", Doc.FileName,
                    "UploadedBy", Doc.FileName,
                    "UploadedTime", Doc.FileName
                });
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
        private Document GetUserFromReader(IDataReader reader)
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
            Document document = new Document();
            document.DocID = Db.GetValue(reader, "DocID", 0);
            document.FileName = Db.GetValue(reader, "FileName", "");
            document.FileType = Db.GetValue(reader, "FileType", "");
            document.FileSummary = Db.GetValue(reader, "FileType", "");
            document.FileData = reader["FileData"] != null ? (byte[])reader["FileData"] : null;
            document.UploadedBy = Db.GetValue(reader, "UploadedBy", 0);
            document.UploadedTime = Db.GetValue(reader, "UploadedTime", DateTime.Now);

            return document;
        }
    }
}
