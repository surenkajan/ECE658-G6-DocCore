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
        public int DeleteProjectByProjectID(int ID)
        {
            if (ID != null)
            {
                return Db.Delete(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[CoreDeleteProjectByID]",
                    "DocCoreMSSQLConnection",
                   new object[] { "ProjectID", ID });
            }
            else
            {
                return -1;
            }
        }
        public int UpdateProjectByID(Project proj)
        {
            if (proj != null && proj.ProjectManager != null && proj.pID != null && proj.TeamMember != null)
            {
                return Db.Update(
                    Db.QueryType.StoredProcedure,
                    "[doccore].[CoreUpdateProjectByID]",
                    "DocCoreMSSQLConnection",
                    new object[]
                {
                    "ProjectID",proj.pID ,
                    "ProjectManagers", proj.ProjectManager,
                    "TeamMembers", proj.TeamMember
                   
                });
            }
            else
            {
                return -1;
            }
        }
        public List<Project> GetAllProject()
        {
            return Db.ReadList(Db.QueryType.StoredProcedure, "[doccore].[CoreGetAllProject]",
            GetProjectFromReader, "DocCoreMSSQLConnection",
            new object[] { "UserTablePreFix", "AU" });
        }
        private Project GetProjectFromReader(IDataReader reader)
        {
            return GetProjectFromReader(reader, "AU");
        }
        public static Project GetProjectFromReader(IDataReader reader, string namePreFix)
        {
            Project project = new Project();

            project.ProjectName = Db.GetValue(reader, "projectName", "");
            project.pID = Db.GetValue(reader, "projectID", 0);
            

            return project;
        }


    }
}
