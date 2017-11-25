using System;
using System.Collections.Generic;
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
                    "ProjectManager	", project.ProjectManager,
                    "ProjectName", project.ProjectName,
                    "TeamMember	", project.TeamMember

                });
            }
            else
            {
                return -1;
            }
        }
    }
}
