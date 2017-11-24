namespace UoW.DocCore.Core
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Diagnostics;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using UoW.DocCore.BusinessObjects;
    using UoW.DocCore.DataObjects.ADO.NET;
    using UoW.DocCore.DocCoreUtilities;

    public class SecurityDao
    {
        /// <summary>
        /// Get Security Questions.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public List<SecurityQuestion> GetSecurityQuestions()
        {
            return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[CoreGetSecurityQuestions]",
                GetSecurityFromReader, "DocCoreMSSQLConnection",
                new object[] { "UserTablePreFix", "AU" });
        }

        /// <summary>
        /// <summary>
        /// Add Security Answers once the ASP.Net Auth registration completes
        /// </summary>
        /// <param name="secAns"></param>
        /// <returns></returns>
        public int AddSecurityAnswersEmailID(SecurityAnswers secAns)
        {
            if (secAns != null && secAns.UserEmailID != null && secAns.QuestionsAnswers != null)
            {
                //string QuestionAndAnswers = string.Join(";", secAns.QuestionAnswer.Select(x => x.Key + "=" + x.Value));
                string QuestionAndAnswers = null;
                //StringBuilder sb = new StringBuilder();
                //foreach (SecurityAnswerPair pair in secAns.QuestionsAnswers)
                //{
                //    sb.Append(pair.Question.Question + ":" + pair.Answer + ";");
                //}

                //QuestionAndAnswers = sb.ToString();

                //TODO : Make More Generic Later - Number of Questions are dynamic
                return Db.Insert(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[AddSecurityAnswersEmailID]",
                    "DocCoreMSSQLConnection",
                    new object[]
                    {
                        "EmailAddress", secAns.UserEmailID,
                        "Question1", secAns.QuestionsAnswers[0].Question.Question,
                        "Question1Answer", secAns.QuestionsAnswers[0].Answer,
                        "Question2", secAns.QuestionsAnswers[1].Question.Question,
                        "Question2Answer", secAns.QuestionsAnswers[1].Answer
                    });
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// UpdateSecurityAnswersByEmailID
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int UpdateSecurityAnswersByEmailID(SecurityAnswers secAns)
        {
            if (secAns != null && secAns.UserEmailID != null && secAns.QuestionsAnswers != null)
            {
                return Db.Update(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[CoreUpdateSecurityAnswersEmailID]",
                    "DocCoreMSSQLConnection",
                    new object[]
                    {
                        "EmailAddress", secAns.UserEmailID,
                        "Question1", secAns.QuestionsAnswers[0].Question.Question,
                        "Question1Answer", secAns.QuestionsAnswers[0].Answer,
                        "Question2", secAns.QuestionsAnswers[1].Question.Question,
                        "Question2Answer", secAns.QuestionsAnswers[1].Answer
                    });
            }
            else
            {
                return -1;
            }
        }



        ///// <summary>
        ///// Get Security Questions.
        ///// </summary>
        ///// <param></param>
        ///// <returns></returns>
        //public List<SecurityAnswers> GetSecurityAnswersListsByEmailID(string EmailID)
        //{
        //    return Db.ReadList(Db.QueryType.StoredProcedure, "[pictre].[GetSecurityAnswersByEmailID]",
        //        GetSecurityAnswerFromReader, "PictreMSSQLConnection",
        //        new object[] { "EmailAddress", EmailID });
        //}

        /// <summary>
        /// Get Security Questions.
        /// </summary>
        /// <param></param>
        /// <returns></returns>
        public SecurityAnswers GetSecurityAnswersByEmailID(string EmailID)
        {
            List<SecurityQuestion> questions = GetSecurityQuestions();
            SecurityAnswers answers = new SecurityAnswers();
            answers.UserEmailID = EmailID;
            SecurityAnswerPair pair = null;
            answers.QuestionsAnswers = new List<SecurityAnswerPair>();
            foreach (SecurityQuestion ques in questions)
            {
                SecurityAnswerPair answer = Db.Read(Db.QueryType.StoredProcedure, "[doccore].[GetCoreSecurityAnswersEmailID]",
                                         GetSecurityAnswerFromReader, "DocCoreMSSQLConnection",
                                         new object[]
                                         {
                                                "EmailAddress", EmailID,
                                                "Question", ques.Question
                                         });
                SecurityQuestion question = new SecurityQuestion();
                question.ID = answer.Question.ID;
                question.Question = ques.Question;
                pair = new SecurityAnswerPair() { Question = question, Answer = answer.Answer };
                answers.QuestionsAnswers.Add(pair);
            }

            return answers;
        }

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private SecurityQuestion GetSecurityFromReader(IDataReader reader)
        {
            return GetUserFromReader(reader, "AU");
        }

        /// <summary>
        /// Gets the SecurityQuestion from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="namePreFix">The name pre fix.</param>
        /// <returns></returns>
        public static SecurityQuestion GetUserFromReader(IDataReader reader, string namePreFix)
        {
            SecurityQuestion question = new SecurityQuestion();

            //TODO : Enable the Prefix later here and Stored Procedure
            question.ID = Db.GetValue(reader, "ID", 0);
            question.Question = Db.GetValue(reader, "Question", "");

            return question;
        }

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <returns></returns>
        private SecurityAnswerPair GetSecurityAnswerFromReader(IDataReader reader)
        {
            return GetSecurityAnswerFromReader(reader, "AU");
        }

        /// <summary>
        /// Gets the employee from reader.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="namePreFix">The name pre fix.</param>
        /// <returns></returns>
        public static SecurityAnswerPair GetSecurityAnswerFromReader(IDataReader reader, string namePreFix)
        {
            SecurityAnswerPair answer = new SecurityAnswerPair();

            //TODO : Enable the Prefix later here and Stored Procedure
            answer.Question = new SecurityQuestion() {ID = Db.GetValue(reader, "QuestionID", 0) };
            answer.Answer = Db.GetValue(reader, "Answer", "");

            return answer;
        }
    }
}
