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
    public interface ISecurityService
    {
        [OperationContract]
        [Description("Get Security Questions")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetSecurityQuestions")]
        List<SecurityQuestionDto> GetSecurityQuestions();

        [OperationContract]
        [Description("Add Security Answers to the System")]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddSecurityAnswersEmailID")]
        int AddSecurityAnswersEmailID(SecurityAnswersDto answers);

        [OperationContract]
        [Description("Get Security Question's Answers by EmailID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetSecurityAnswersByEmailID?Email={EmailID}")]
        //List<SecurityQuestionDto> GetSecurityAnswersByEmailID(string EmailID);
        SecurityAnswersDto GetSecurityAnswersByEmailID(string EmailID);

        [OperationContract(Name = "Update Security Answers to the System")]
        [WebInvoke(Method = "PUT",
           BodyStyle = WebMessageBodyStyle.Bare,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "UpdateSecurityAnswersEmailID")]
        int UpdateSecurityAnswersEmailID(SecurityAnswersDto answers);

    }
}
