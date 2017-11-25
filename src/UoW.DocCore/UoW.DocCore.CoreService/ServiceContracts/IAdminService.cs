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

    }
}
