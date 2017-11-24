using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.DocCore.BusinessObjects
{
    public class SecurityQuestion : BusinessObject
    {
        #region Database Properties

        private int id;
        /// <summary>
        /// Gets or sets the ID.
        /// </summary>
        /// <value>
        /// The ID.
        /// </value>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        private string question;
        /// <summary>
        /// Gets or sets the question.
        /// </summary>
        /// <value>
        /// The question.
        /// </value>
        public string Question
        {
            get { return question; }
            set { question = value; }
        }

        #endregion
    }
}
