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

    public partial class Service : IAdminService
    {
        public int CreateProjectByEmailID(ProjectDto project)
        //public int AddUserByEmailID()
        {

            ProjectDao projectDao = new ProjectDao();
            return projectDao.CreateProjectByEmailID(CoreObjectMapper.ProjectDtoToDao(project));
        }
        public UserDto GetUserRoleByEmailID(string EmailID)
        {

            UserDao userDao = new UserDao();
            return CoreObjectMapper.UserDaoToDto(userDao.GetUserRoleByEmailID(EmailID));
        }

        public List<UserDto> GetAllManagers()
        {

            UserDao userDao = new UserDao();
            return CoreObjectMapper.UserDaoToDto(userDao.GetAllManagers());
        }

        public List<UserDto> GetAllTeamMembers()
        {

            UserDao userDao = new UserDao();
            return CoreObjectMapper.UserDaoToDto(userDao.GetAllTeamMembers());
        }
        public List<UserDto> GetAllTeamMembersByProjectID(int ID)
        {

            UserDao userDao = new UserDao();
            return CoreObjectMapper.UserDaoToDto(userDao.GetAllTeamMembersByProjectID(ID));
        }

        public List<UserDto> GetAllManagersByProjectID(int ID)
        {

            UserDao userDao = new UserDao();
            return CoreObjectMapper.UserDaoToDto(userDao.GetAllManagersByProjectID(ID));
        }
        public ProjectDto GetProjectDetailsByID(int ID)
        {
            ProjectDao projectDao = new ProjectDao();
            return CoreObjectMapper.ProjectDaoToDto(projectDao.GetProjectDetailsByID(ID));
        }
        public int DeleteProjectByProjectID(int ID)
        {
            ProjectDao projectDao = new ProjectDao();
            return projectDao.DeleteProjectByProjectID(ID);
        }

        public int UpdateProjectByID(ProjectDto project)
        {
            ProjectDao projectDao = new ProjectDao();
            return projectDao.UpdateProjectByID(CoreObjectMapper.ProjectDtoToDao(project));

        }
        public List<ProjectDto> GetAllProject()
        {
            ProjectDao projectDao = new ProjectDao();
            return CoreObjectMapper.ProjectDaoToDto(projectDao.GetAllProject());
        }
    }
}
