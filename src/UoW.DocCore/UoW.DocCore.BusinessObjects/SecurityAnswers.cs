using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.DocCore.BusinessObjects
{
    public class SecurityAnswers : BusinessObject
    {
        #region Database Properties

        private string userEmailId;
        /// <summary>
        /// Gets or sets the user Email Id.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        public string UserEmailID
        {
            get { return userEmailId; }
            set { userEmailId = value; }
        }

        //TODO : have to fix this Dictionary Serialize issue
        //private Dictionary<string, string> questionAnswer;
        ///// <summary>
        ///// Gets or sets the question.
        ///// </summary>
        ///// <value>
        ///// The question.
        ///// </value>
        //public Dictionary<string, string> QuestionAnswer
        //{
        //    get { return questionAnswer; }
        //    set { questionAnswer = value; }
        //}

        //private string question1;
        //public string Quetions1
        //{
        //    get { return question1; }
        //    set { question1 = value; }
        //}

        //private string question1Answer;
        //public string Quetions1Answer
        //{
        //    get { return question1Answer; }
        //    set { question1Answer = value; }
        //}

        //private string question2;
        //public string Quetions2
        //{
        //    get { return question2; }
        //    set { question2 = value; }
        //}

        //private string question2Answer;
        //public string Quetions2Answer
        //{
        //    get { return question2Answer; }
        //    set { question2Answer = value; }
        //}

        private List<SecurityAnswerPair> questionsAnswers;
        public List<SecurityAnswerPair> QuestionsAnswers
        {
            get { return questionsAnswers; }
            set { questionsAnswers = value; }
        }

        #endregion
    }
}
