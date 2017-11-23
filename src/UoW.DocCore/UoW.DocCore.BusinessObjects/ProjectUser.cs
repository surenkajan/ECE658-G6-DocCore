using System;
using System.Collections.Generic;
using System.Text;

namespace UoW.DocCore.BusinessObjects
{
    public class ProjectUser : User
    {
        #region Database properties
        private string reportingManager;
        public string ReportingManager
        {
            get { return reportingManager; }
            set { reportingManager = value; }
        }

        //Current working Projects - Users as Team Members and PM as Managers
        private List<string> currentProjects;
        public List<string> CurrentProjects
        {
            get { return currentProjects; }
            set { currentProjects = value; }
        }
        

        #endregion
    }
}
