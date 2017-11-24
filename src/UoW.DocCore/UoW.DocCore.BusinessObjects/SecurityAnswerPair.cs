using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.DocCore.BusinessObjects
{
    public class SecurityAnswerPair : BusinessObject
    {
        private SecurityQuestion question;
        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        public SecurityQuestion Question
        {
            get { return question; }
            set { question = value; }
        }

        private string answer;
        /// <summary>
        /// Gets or sets the answer.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
    }
}
