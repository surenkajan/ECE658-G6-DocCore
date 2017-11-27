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
    public class DocumentDto
    {
        #region Database properties
        private int docID;
        [DataMember]
        public int DocID
        {
            get { return docID; }
            set { docID = value; }
        }

        private string fileName;
        [DataMember]
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        private string fileType;
        [DataMember]
        public string FileType
        {
            get { return fileType; }
            set { fileType = value; }
        }

        private string fileSummary;
        [DataMember]
        public string FileSummary
        {
            get { return fileSummary; }
            set { fileSummary = value; }
        }

        private Int64 fileSizeInKB;
        [DataMember]
        public Int64 FileSizeInKB
        {
            get { return fileSizeInKB; }
            set { fileSizeInKB = value; }
        }

        private byte[] fileData;
        [DataMember]
        public byte[] FileData
        {
            get { return fileData; }
            set { fileData = value; }
        }

        //private int uploadedBy;
        //[DataMember]
        //public int UploadedBy
        //{
        //    get { return uploadedBy; }
        //    set { uploadedBy = value; }
        //}

        private string uploadedBy;
        [DataMember]
        public string UploadedBy
        {
            get { return uploadedBy; }
            set { uploadedBy = value; }
        }

        private DateTime uploadedTime;
        [DataMember]
        public DateTime UploadedTime
        {
            get { return uploadedTime; }
            set { uploadedTime = value; }
        }

        private int isCheckedIn;
        [DataMember]
        public int IsCheckedIn
        {
            get { return isCheckedIn; }
            set { isCheckedIn = value; }
        }

        private string modifiedBy;
        [DataMember]
        public string ModifiedBy
        {
            get { return modifiedBy; }
            set { modifiedBy = value; }
        }

        private DateTime modified;
        [DataMember]
        public DateTime Modified
        {
            get { return modified; }
            set { modified = value; }
        }

        private List<User> sharedWith;
        [DataMember]
        public List<User> SharedWith
        {
            get { return sharedWith; }
            set { sharedWith = value; }
        }

        private User createdUser;
        [DataMember]
        public User CreatedUser
        {
            get { return createdUser; }
            set { createdUser = value; }
        }

        private User modifiedUser;
        [DataMember]
        public User ModifiedUser
        {
            get { return modifiedUser; }
            set { modifiedUser = value; }
        }



        #endregion



    }
}
