using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UoW.DocCore.BusinessObjects
{
    public class Project
    {

        #region Database properties
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
}
