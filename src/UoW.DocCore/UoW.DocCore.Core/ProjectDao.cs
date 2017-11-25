using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW.DocCore.BusinessObjects;
using UoW.DocCore.DataObjects.ADO.NET;

namespace UoW.DocCore.Core
{
    public class ProjectDao
    {

        public int CreateProjectByEmailID(Project project)
        {
            if (project != null && project.ProjectManager != null && project.ProjectName != null && project.TeamMember != null)
            {
                return Db.Insert(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[CoreCreateProjectByEmailID]",
                    "DocCoreMSSQLConnection",
                    new object[]
                {
                    "ProjectManager", project.ProjectManager,
                    "ProjectName", project.ProjectName,
                    "TeamMember", project.TeamMember

                });
            }
            else
            {
                return -1;
            }
        }
        public Project GetProjectDetailsByID(int ID)
        {
            return Db.Read(Db.QueryType.StoredProcedure, "[doccore].[CoreGetProjectDetailsById]",
             GetMemberFromReader, "DocCoreMSSQLConnection",
             new object[] { "ProjectID", ID });
        }
        private Project GetMemberFromReader(IDataReader reader)
        {
            return GetMemberFromReader(reader, "AU");
        }
        public static Project GetMemberFromReader(IDataReader reader, string namePreFix)
        {
            Project project = new Project();

            project.ProjectName = Db.GetValue(reader, "projectName", "");
            project.ProjectManager = Db.GetValue(reader, "ProjectManagers", "");
            project.TeamMember = Db.GetValue(reader, "ProjectMembers", "");
        
            return project;
        }


    }
}
