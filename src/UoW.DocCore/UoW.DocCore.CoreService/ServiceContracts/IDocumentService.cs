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
    public interface IDocumentService
    {
        [OperationContract]
        [Description("Get Document By DocID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetDocumentWithContentByDocID?DocID={DocID}")]
        DocumentDto GetDocumentWithContentByDocID(string DocID);

        [OperationContract]
        [Description("Get Document By DocID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetDocumentByDocID?DocID={DocID}")]
        DocumentDto GetDocumentByDocID(string DocID);

        [OperationContract(Name = "Get All Documents")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllDocuments")]
        List<DocumentDto> GetAllDocuments();

        [OperationContract(Name = "Get All Documents Uploaded By EmailID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllDocumentsUploadedByEmailID?Email={EmailID}")]
        List<DocumentDto> GetAllDocumentsUploadedByEmailID(string EmailID);

        [OperationContract(Name = "Get Uploaded By Others And Shared With Me ByEmailID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetUploadedAndSharedWithMeByEmailID?Up_User={U_User}&Lo_User={L_User}")]
        List<DocumentDto> GetUploadedAndSharedWithMeByEmailID(string U_User, string L_User);

        [OperationContract(Name = "GetAllSharedDocumentsForEmailID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllSharedDocumentsForEmailID?Email={EmailID}")]
        List<DocumentDto> GetAllSharedDocumentsForEmailID(string EmailID);

        [OperationContract]
        [Description("Add Documents to the System")]
        [WebInvoke(Method = "POST",
            BodyStyle = WebMessageBodyStyle.Bare,
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/AddDocuments")]
        int AddDocuments(DocumentDto document);

        [OperationContract(Name = "Update Document")]
        [WebInvoke(Method = "PUT",
           BodyStyle = WebMessageBodyStyle.Bare,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "UpdateDocuments")]
        int UpdateDocuments(DocumentDto document);

        [OperationContract]
        [Description("Delete Documents By DocID")]
        [WebInvoke(Method = "DELETE",
           BodyStyle = WebMessageBodyStyle.Bare,
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           UriTemplate = "DeleteDocuments?DocID={DocID}")]
        int DeleteDocumentsByDocID(string DocID);

        [OperationContract]
        [Description("Get Comment By docID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetCommentsByID?DocID={docID}")]
        List<CommentsDto> GetCommentsByID(int docID);

        [OperationContract]
        [Description("Add Comments By EmailID")]
        [WebInvoke(Method = "POST",
        BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "/AddCommentsByEmailID")]
        int AddCommentsByEmailID(CommentsDto comments);

        [OperationContract(Name = "GetAllSharedUsersForDocID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetAllSharedUsersForDocID?DocID={DocID}")]
        List<UserDto> GetAllSharedUsersForDocID(int DocID);
    }
}
