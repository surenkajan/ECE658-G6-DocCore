using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.DocCore.BusinessObjects
{
    public class Document : BusinessObject
    {
        #region Database properties
        private int docID;
        public int DocID
        {
            get { return docID; }
            set { docID = value; }
        }

        private string fileName;
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private string fileType;
        public string FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }

        private string fileSummary;
        public string FileSummary
        {
            get { return fileSummary; }
            set { fileSummary = value; }
        }

        private byte[] fileData;
        public byte[] FileData
        {
            get { return fileData; }
            set { fileData = value; }
        }

        private int uploadedBy;
        public int UploadedBy
        {
            get { return uploadedBy; }
            set { uploadedBy = value; }
        }

        private DateTime uploadedTime;
        public DateTime UploadedTime
        {
            get { return uploadedTime; }
            set { uploadedTime = value; }
        }

        #endregion
    }
}
