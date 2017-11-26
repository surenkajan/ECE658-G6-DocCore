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

        private Int64 fileSizeInKB;
        public Int64 FileSizeInKB
        {
            get { return fileSizeInKB; }
            set { fileSizeInKB = value; }
        }

        private byte[] fileData;
        public byte[] FileData
        {
            get { return fileData; }
            set { fileData = value; }
        }

        //private int uploadedBy;
        //public int UploadedBy
        //{
        //    get { return uploadedBy; }
        //    set { uploadedBy = value; }
        //}

        private string uploadedBy;
        public string UploadedBy
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

        private int isCheckedIn;
        public int IsCheckedIn
        {
            get { return isCheckedIn; }
            set { isCheckedIn = value; }
        }

        private string modifiedBy;
        public string ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }

        private DateTime modified;
        public DateTime Modified
        {
            get { return modified; }
            set { modified = value; }
        }

        #endregion
    }
}
