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
    public class SecurityQuestionDto
    {
        #region Database Properties

        private int id;
        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        private string question;
        [DataMember]
        public string Question
        {
            get { return question; }
            set { question = value; }
        }

        #endregion
    }
}
