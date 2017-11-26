﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Script.Serialization;
using Newtonsoft.Json;
using UoW.DocCore.ServiceUtils;

namespace UoW.DocCore.Web.WebForms
{
    public sealed class DocCoreBDelegate
    {
        private static readonly object padlock = new object();
        private static DocCoreBDelegate instance = null;
        string Service_BaseAddress;
        string json_type;

        private DocCoreBDelegate()
        {
            Service_BaseAddress = ConfigurationManager.AppSettings["DocCoreServicesBaseAddress"];
            json_type = "application/json;charset=utf-8";
        }

        //Thread Safety Singleton using Double Check Locking
        public static DocCoreBDelegate Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new DocCoreBDelegate();
                        }
                    }
                }
                return instance;
            }
        }

        public object CurrentUserEmailID { get; private set; }
        public object Uid { get; private set; }

        public UserDto GetUserByEmailID(string EmailID)
        {
            UserDto user = null;
            //TODO : Do not hard code the method name here, Move to App.Settings
            //Get the User
            string usr = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/GetUserByEmailID?Email=" + EmailID, "GET", json_type, null);

            //How to Consume this in DocCore Front End: Deserialize the object(s)
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = int.MaxValue;
            if (usr != null)
            {
                user = json_serializer.Deserialize<UserDto>(usr);
            }
            return user;
        }
        public UserDto GetUserByUid(int uid)
        {
            UserDto user = null;
            //TODO : Do not hard code the method name here, Move to App.Settings
            //Get the User
            string usr = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/GetUserByUid?Uid=" + uid, "GET", json_type, null);

            //How to Consume this in DocCore Front End: Deserialize the object(s)
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            if (usr != null)
            {
                user = json_serializer.Deserialize<UserDto>(usr);
            }
            return user;
        }


        public List<UserDto> GetAllUsers()
        {
            List<UserDto> usrList = null;
            //TODO : Do not hard code the method name here, Move to App.Settings
            string Json_usrList = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/GetAllUsers", "GET", json_type, null);
            JavaScriptSerializer json_list_serializer = new JavaScriptSerializer();

            if (Json_usrList != null)
            {
                usrList = json_list_serializer.Deserialize<List<UserDto>>(Json_usrList);
            }
            return usrList;
        }

        public int InsertUser(UserDto newUser)
        {
            int status = -1;

            if (newUser != null)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string userjson = js.Serialize(newUser);

                //Add New user
                string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/AddUserByEmailID", "POST", json_type, userjson);
                status = val != null ? Int32.Parse(val) : -1;
            }
            return status;
        }

        public int CreateProject(ProjectDto projectdto)
        {
            int status = -1;

            if (projectdto != null)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string userjson = js.Serialize(projectdto);

                //Add New user
                string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/adminRest/CreateProjectByEmailID", "POST", json_type, userjson);
                status = val != null ? Int32.Parse(val) : -1;
            }
            return status;

        }
        public UserDto GetUserRoleByEmailID(string EmailID)
        {
            UserDto user = null;
            //TODO : Do not hard code the method name here, Move to App.Settings
            //Get the User
            string usr = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/adminRest/GetUserRoleByEmailID?Email=" + EmailID, "GET", json_type, null);

            //How to Consume this in Pictre Front End: Deserialize the object(s)
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = int.MaxValue;
            if (usr != null)
            {
                user = json_serializer.Deserialize<UserDto>(usr);
            }
            return user;
        }

        public List<UserDto> GetAllTeamMembers()
        {
            List<UserDto> usrList = null;
            //TODO : Do not hard code the method name here, Move to App.Settings
            string Json_usrList = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/adminRest/GetAllTeamMembers", "GET", json_type, null);
            JavaScriptSerializer json_list_serializer = new JavaScriptSerializer();

            if (Json_usrList != null)
            {
                usrList = json_list_serializer.Deserialize<List<UserDto>>(Json_usrList);
            }
            return usrList;
        }
        public List<UserDto> GetAllManagersByProjectID(int ID)
        {
            List<UserDto> usrList = null;
            //TODO : Do not hard code the method name here, Move to App.Settings
            string Json_usrList = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/adminRest/GetAllManagersByProjectID?projectID=" + ID, "GET", json_type, null);
            JavaScriptSerializer json_list_serializer = new JavaScriptSerializer();

            if (Json_usrList != null)
            {
                usrList = json_list_serializer.Deserialize<List<UserDto>>(Json_usrList);
            }
            return usrList;
        }
        public List<UserDto> GetAllTeamMembersByProjectID(int ID)
        {
            List<UserDto> usrList = null;
            //TODO : Do not hard code the method name here, Move to App.Settings
            string Json_usrList = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/adminRest/GetAllTeamMembersByProjectID?projectId=" + ID, "GET", json_type, null);
            JavaScriptSerializer json_list_serializer = new JavaScriptSerializer();

            if (Json_usrList != null)
            {
                usrList = json_list_serializer.Deserialize<List<UserDto>>(Json_usrList);
            }
            return usrList;
        }

        public ProjectDto GetProjectDetailsByID(int ID)
        {
            ProjectDto project = null;
            //TODO : Do not hard code the method name here, Move to App.Settings
            string Proj = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/adminRest/GetProjectDetailsByID?projectId=" + ID, "GET", json_type, null);
            JavaScriptSerializer json_serializer = new JavaScriptSerializer();
            json_serializer.MaxJsonLength = int.MaxValue;
            if (Proj != null)
            {
                project = json_serializer.Deserialize<ProjectDto>(Proj);
            }
            return project;

        }
        public List<UserDto> GetAllManagers()
        {
            List<UserDto> usrList = null;
            //TODO : Do not hard code the method name here, Move to App.Settings
            string Json_usrList = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/adminRest/GetAllManagers", "GET", json_type, null);
            JavaScriptSerializer json_list_serializer = new JavaScriptSerializer();

            if (Json_usrList != null)
            {
                usrList = json_list_serializer.Deserialize<List<UserDto>>(Json_usrList);
            }
            return usrList;
        }
        public int UpdateUser(UserDto user)
        {
            int status = -1;
            if (user != null)
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string userjson = js.Serialize(user);

                //Update existing user
                string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/UpdateUserByEmailID", "PUT", json_type, userjson);
                status = val != null ? Int32.Parse(val) : -1;
            }
            return status;
        }

        public int DeleteProjectByProjectID(int ID)
        {
            //DELETE the Project
            string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/adminRest/DeleteProjectByProjectID?ProjectID=" + ID, "DELETE", json_type, null);
            int status = val != null ? Int32.Parse(val) : -1;
            return status;
        }
        public int DeleteUserByEmailID(string EmailID)
        {
            //DELETE the User
            string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/DeleteUserByEmailID?Email=" + EmailID, "DELETE", json_type, null);
            int status = val != null ? Int32.Parse(val) : -1;
            return status;
        }


        #region SecurityQuestions

        public List<SecurityQuestionDto> GetSecurityQuestions()
        {
            List<SecurityQuestionDto> questions = null;

            string Json_usrList = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/securityRest/GetSecurityQuestions", "GET", json_type, null);
            JavaScriptSerializer json_ques_serializer = new JavaScriptSerializer();

            if (Json_usrList != null)
            {
                questions = json_ques_serializer.Deserialize<List<SecurityQuestionDto>>(Json_usrList);
            }
            return questions;
        }

        public int InsertSecurityAnswers(SecurityAnswersDto Answers)
        {
            int status = -1;

            if (Answers != null)
            {
                //JavaScriptSerializer js = new JavaScriptSerializer();
                //string ansjson = js.Serialize(Answers);

                string ansjson = JsonConvert.SerializeObject(Answers);

                //Add New user
                string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/securityRest/AddSecurityAnswersEmailID", "POST", json_type, ansjson);
                status = val != null ? Int32.Parse(val) : -1;
            }
            return status;
        }

        public int UpdateSecurityAnswers(SecurityAnswersDto Answers)
        {
            int status = -1;

            if (Answers != null)
            {
                //JavaScriptSerializer js = new JavaScriptSerializer();
                //string ansjson = js.Serialize(Answers);

                string ansjson = JsonConvert.SerializeObject(Answers);

                //Add New user
                string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/securityRest/UpdateSecurityAnswersEmailID", "PUT", json_type, ansjson);
                status = val != null ? Int32.Parse(val) : -1;
            }
            return status;
        }

        //public List<SecurityAnswersDto> GetSecurityQuestionsAnswers(string EmailID)
        public SecurityAnswersDto GetSecurityQuestionsAnswers(string EmailID)
        {
            SecurityAnswersDto questionsAnswers = null;

            string Json_usrList = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/securityRest/GetSecurityAnswersByEmailID?Email=" + EmailID, "GET", json_type, null);
            JavaScriptSerializer json_ques_serializer = new JavaScriptSerializer();

            if (Json_usrList != null)
            {
                questionsAnswers = json_ques_serializer.Deserialize<SecurityAnswersDto>(Json_usrList);
            }
            return questionsAnswers;
        }

        #endregion


    }

    #region All Dto
    //TODO : handle this differently
    public class UserDto
    {
        #region Database Properties
        private int uid;
        public int Uid
        {
            get { return uid; }
            set { uid = value; }
        }
        private string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private string lastName;
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }

        private DateTime? dateOfBirth;
        public DateTime? DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        private string emailAddress;
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        private string firstName;
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }

        private string fullName;
        public string FullName
        {
            get { return fullName; }
            set { fullName = value; }
        }

        private string sex;
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        private string projectRole;

        public string ProjectRole
        {
            get { return projectRole; }
            set { projectRole = value; }
        }

        #endregion

        #region External Properties
        private string profilePhoto;
        public string ProfilePhoto
        {
            get { return profilePhoto; }
            set { profilePhoto = value; }
        }
        #endregion
    }
    public class ProjectDto
    {
        #region Database Properties
        private String projectName;

        public String ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private String projectManager;

        public String ProjectManager
        {
            get { return projectManager; }
            set { projectManager = value; }
        }
        private String teamMember;

        public String TeamMember
        {
            get { return teamMember; }
            set { teamMember = value; }
        }
        #endregion
    }
    public class SecurityQuestionDto
    {
        #region Database Properties

        private int id;
        public int ID
        {
            get { return id; }
            set { id = value; }
        }


        private string question;
        public string Question
        {
            get { return question; }
            set { question = value; }
        }

        #endregion
    }

    public class SecurityAnswersDto
    {
        #region Database Properties

        private string userEmailId;
        public string UserEmailID
        {
            get { return userEmailId; }
            set { userEmailId = value; }
        }

        private List<SecurityAnswerPair> questionsAnswers;
        public List<SecurityAnswerPair> QuestionsAnswers
        {
            get { return questionsAnswers; }
            set { questionsAnswers = value; }
        }

        #endregion
    }

    public class SecurityAnswerPair
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

    public class SecurityQuestion
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

    #endregion
}