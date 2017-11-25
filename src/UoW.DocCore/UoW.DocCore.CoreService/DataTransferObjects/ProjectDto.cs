using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace UoW.DocCore.CoreService.DataTransferObjects
{
    [Serializable]
    [DataContract]
    public class ProjectDto
    {
        #region Database Properties
        private String projectName;
        [DataMember]
        public String ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        private String projectManager;
        [DataMember]
        public String ProjectManager
        {
            get { return projectManager; }
            set { projectManager = value; }
        }
        private String teamMember;
        [DataMember]
        public String TeamMember
        {
            get { return teamMember; }
            set { teamMember = value; }
        }
        #endregion
    }
}
