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

        private byte[] fileData;
        [DataMember]
        public byte[] FileData
        {
            get { return fileData; }
            set { fileData = value; }
        }

        private int uploadedBy;
        [DataMember]
        public int UploadedBy
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

        #endregion
    }
}
