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

            ProjectDao userDao = new ProjectDao();
            return userDao.CreateProjectByEmailID(CoreObjectMapper.ProjectDtoToDao(project));
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
    }
}
