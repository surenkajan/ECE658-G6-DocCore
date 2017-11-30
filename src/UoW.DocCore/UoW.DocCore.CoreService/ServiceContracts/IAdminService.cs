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
    public interface IAdminService
    {

        [OperationContract]
        [Description("Create Project to the System")]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/CreateProjectByEmailID")]
        int CreateProjectByEmailID(ProjectDto project);

        [OperationContract]
        [Description("Get Role By EmailID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
       UriTemplate = "GetUserRoleByEmailID?Email={EmailID}")]
        UserDto GetUserRoleByEmailID(string EmailID);

        [OperationContract]
        [Description("Get All Managers")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
      RequestFormat = WebMessageFormat.Json,
      ResponseFormat = WebMessageFormat.Json,
      UriTemplate = "GetAllManagers")]
        List<UserDto> GetAllManagers();

        [OperationContract]
        [Description("Get All team Members")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
     RequestFormat = WebMessageFormat.Json,
     ResponseFormat = WebMessageFormat.Json,
     UriTemplate = "GetAllTeamMembers")]
        List<UserDto> GetAllTeamMembers();

        [OperationContract]
        [Description("Get All Managers by project")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
     RequestFormat = WebMessageFormat.Json,
     ResponseFormat = WebMessageFormat.Json,
     UriTemplate = "GetAllManagersByProjectID?projectID={ID}")]
        List<UserDto> GetAllManagersByProjectID(int ID);

        [OperationContract]
        [Description("Get All Team Members by project")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "GetAllTeamMembersByProjectID?projectId={ID}")]
        List<UserDto> GetAllTeamMembersByProjectID(int ID);

        [OperationContract]
        [Description("Get Project Details By ID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetProjectDetailsByID?projectId={ID}")]
        ProjectDto GetProjectDetailsByID(int ID);

        [OperationContract]
        [Description("Delete Project By ID")]
        [WebInvoke(Method = "DELETE",
          BodyStyle = WebMessageBodyStyle.Bare,
          RequestFormat = WebMessageFormat.Json,
          ResponseFormat = WebMessageFormat.Json,
          UriTemplate = "DeleteProjectByProjectID?ProjectID={ID}")]
        int DeleteProjectByProjectID(int ID);


        [OperationContract(Name = "Update User Details")]
        [WebInvoke(Method = "PUT",
           BodyStyle = WebMessageBodyStyle.Bare,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "UpdateProjectByID")]
        int UpdateProjectByID(ProjectDto project);

        [OperationContract]
        [Description("Get all Project")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
       UriTemplate = "GetAllProject")]
      List<ProjectDto> GetAllProject();

        [OperationContract]
        [Description("Get  Project details of user")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
       RequestFormat = WebMessageFormat.Json,
       ResponseFormat = WebMessageFormat.Json,
       UriTemplate = "GetProjectDetailsByUid?Uid={ID}")]
        List<ProjectDto> GetProjectDetailsByUid( int ID);

        [OperationContract]
        [Description("Get All Team Members from all projects of Email ID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
    RequestFormat = WebMessageFormat.Json,
    ResponseFormat = WebMessageFormat.Json,
    UriTemplate = "GetAllTeamMembersByEmailID?EmailID={EmailID}")]
        List<UserDto> GetAllTeamMembersByEmailID(string EmailID);

    }
}
