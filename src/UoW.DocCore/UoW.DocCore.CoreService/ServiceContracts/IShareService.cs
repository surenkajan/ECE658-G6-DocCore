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
    public interface IShareService
    {
        [OperationContract]
        [Description("Get ShareWith By DocID")]
        [WebGet(BodyStyle = WebMessageBodyStyle.Bare,
        RequestFormat = WebMessageFormat.Json,
        ResponseFormat = WebMessageFormat.Json,
        UriTemplate = "GetShareWithByDocID?DocID={DocID}")]
        ShareDto GetShareWithByDocID(int DocID);
    }
}
