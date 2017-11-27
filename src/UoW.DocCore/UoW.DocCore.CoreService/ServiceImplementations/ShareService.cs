using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Threading.Tasks;
using UoW.DocCore.Core;
using UoW.DocCore.CoreService.DataTransferObjectMapper;
using UoW.DocCore.CoreService.DataTransferObjects;

namespace UoW.DocCore.CoreService
{
    public partial class Service : IShareService
    {
        public ShareDto GetShareWithByDocID(int DocID)
        {
            throw new NotImplementedException();
        }
    }
}
