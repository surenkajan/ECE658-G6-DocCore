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
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class Service : IUserService
    {

        /// <summary>
        /// Gets the Details of the User by Email ID.
        /// </summary>
        /// <param name="EmailID"></param>
        /// <returns></returns>
        public UserDto GetUserByEmailID(string EmailID)
        {
            UserDao userDao = new UserDao();
            return CoreObjectMapper.UserDaoToDto(userDao.GetUserByEmailID(EmailID));
        }

        public List<UserDto> GetUserByFullName(string FullName)
        {
            UserDao userDao = new UserDao();
            return CoreObjectMapper.UserDaoToDto(userDao.GetUserByFullName(FullName));
        }



        /// <summary>
        /// Gets the Details of the User by Email ID.
        /// </summary>
        /// <param name="EmailID"></param>
        /// <returns></returns>
        public UserDto GetUserByUid(int Uid)
        {
            UserDao userDao = new UserDao();
            return CoreObjectMapper.UserDaoToDto(userDao.GetUserByUid(Uid));
        }

        /// <summary>

        /// <summary>
        /// Add new user to the system
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int AddUserByEmailID(UserDto user)
        //public int AddUserByEmailID()
        {
            //UserDto user = new UserDto();
            //user.FirstName = "Kajaruban21";
            //user.LastName = "Surendran21";
            //user.FullName = "Kajaruban21 Surendran21";
            //user.EmailAddress = "surenkajan21@gmail.com";
            //user.DateOfBirth = DateTime.Now;
            //user.Sex = "Male";

            UserDao userDao = new UserDao();
            return userDao.AddNewUserByEmailID(CoreObjectMapper.UserDtoToDao(user));
        }

        public List<UserDto> GetAllUsers()
        {
            UserDao userDao = new UserDao();
            return CoreObjectMapper.UserDaoToDto(userDao.GetAllUsers());
        }

        public int UpdateUserByEmailID(UserDto user)
        {
            UserDao userDao = new UserDao();
            return userDao.UpdateUserByEmailID(CoreObjectMapper.UserDtoToDao(user));

        }

        public int DeleteUserByEmailID(string EmailID)
        {
            UserDao userDao = new UserDao();
            return userDao.DeleteUserByEmailID(EmailID);
        }
    }
}
