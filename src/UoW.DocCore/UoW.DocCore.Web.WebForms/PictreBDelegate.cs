using System;
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
    public sealed class PictreBDelegate
    {
        private static readonly object padlock = new object();
        private static PictreBDelegate instance = null;
        string Service_BaseAddress;
        string json_type;

        private PictreBDelegate()
        {
            Service_BaseAddress = ConfigurationManager.AppSettings["DocCoreServicesBaseAddress"];
            json_type = "application/json;charset=utf-8";
        }

        //Thread Safety Singleton using Double Check Locking
        public static PictreBDelegate Instance
        {
            get
            {
                if (instance == null)
                {
                    lock (padlock)
                    {
                        if (instance == null)
                        {
                            instance = new PictreBDelegate();
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

            //How to Consume this in Pictre Front End: Deserialize the object(s)
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

            //How to Consume this in Pictre Front End: Deserialize the object(s)
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

        public int DeleteUserByEmailID(string EmailID)
        {
            //DELETE the User
            string val = RestClient.Instance.MakeHttpRequest(Service_BaseAddress + "/userRest/DeleteUserByEmailID?Email=" + EmailID, "DELETE", json_type, null);
            int status = val != null ? Int32.Parse(val) : -1;
            return status;
        }
        
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
    #endregion
}