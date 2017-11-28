using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using UoW.DocCore.CoreService.DataTransferObjects;

namespace UoW.DocCore.CoreService
{
    [ServiceContract]
    public interface IUserService
    {
        [OperationContract]
        [Description("Get User By EmailID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetUserByEmailID?Email={EmailID}")]
        UserDto GetUserByEmailID(string EmailID);

        [OperationContract]
        [Description("Get User By Full Name")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetUserByFullName?FullName={FullName}")]
        List<UserDto> GetUserByFullName(string FullName);

        [OperationContract]
        [Description("Add User to the System")]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddUserByEmailID")]
        int AddUserByEmailID(UserDto user);

        [OperationContract(Name = "Get All Users")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllUsers")]
        List<UserDto> GetAllUsers();

        [OperationContract(Name = "Update User Details")]
        [WebInvoke(Method = "PUT",
           BodyStyle = WebMessageBodyStyle.Bare,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "UpdateUserByEmailID")]
        int UpdateUserByEmailID(UserDto user);

        [OperationContract]
        [Description("Delete User By EmailID")]
        [WebInvoke(Method = "DELETE",
           BodyStyle = WebMessageBodyStyle.Bare,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "DeleteUserByEmailID?Email={EmailID}")]
        int DeleteUserByEmailID(string EmailID);



        [OperationContract]
        [Description("Get User By Uid")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
      RequestFormat = WebMessageFormat.Json,
      ResponseFormat = WebMessageFormat.Json,
      UriTemplate = "GetUserByUid?Uid={Uid}")]
        UserDto GetUserByUid(int Uid);

        [OperationContract(Name = "Get All Users details")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
     RequestFormat = WebMessageFormat.Json,
     ResponseFormat = WebMessageFormat.Json,
     UriTemplate = "GetAllUserDetails")]
        List<UserDto> GetAllUserDetails();

        [OperationContract(Name = "Get All Users details by Uid")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
   RequestFormat = WebMessageFormat.Json,
   ResponseFormat = WebMessageFormat.Json,
   UriTemplate = "GetAllUserDetailsByUid?Uid={Uid}")]
        UserDto GetAllUserDetailsByUid(int Uid);

        [OperationContract]
        [Description("Add Access level to user")]
        [WebInvoke(Method = "POST",
           BodyStyle = WebMessageBodyStyle.Bare,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "/CreateUserAccess")]
        int CreateUserAccess(UserDto user);
    }
}
