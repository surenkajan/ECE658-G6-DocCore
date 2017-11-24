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
    public class SecurityAnswersDto
    {
        #region Database Properties

        private string userEmailId;
        [DataMember]
        public string UserEmailID
        {
            get { return userEmailId; }
            set { userEmailId = value; }
        }

        //TODO : have to fix this Dictionary Serialize issue
        //private Dictionary<string, string> questionAnswer;
        //[DataMember]
        //public Dictionary<string, string> QuestionAnswer
        //{
        //    get { return questionAnswer; }
        //    set { questionAnswer = value; }
        //}

        private List<SecurityAnswerPair> questionsAnswers;
        [DataMember]
        public List<SecurityAnswerPair> QuestionsAnswers
        {
            get { return questionsAnswers; }
            set { questionsAnswers = value; }
        }

        //private string question1;
        //[DataMember]
        //public string Quetions1
        //{
        //    get { return question1; }
        //    set { question1 = value; }
        //}

        //private string question1Answer;
        //[DataMember]
        //public string Quetions1Answer
        //{
        //    get { return question1Answer; }
        //    set { question1Answer = value; }
        //}

        //private string question2;
        //[DataMember]
        //public string Quetions2
        //{
        //    get { return question2; }
        //    set { question2 = value; }
        //}

        //private string question2Answer;
        //[DataMember]
        //public string Quetions2Answer
        //{
        //    get { return question2Answer; }
        //    set { question2Answer = value; }
        //}


        #endregion
    }
}
