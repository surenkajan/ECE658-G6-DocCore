using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UoW.DocCore.BusinessObjects;
using UoW.DocCore.CoreService.DataTransferObjects;

namespace UoW.DocCore.CoreService.DataTransferObjectMapper
{
    public class CoreObjectMapper
    {
        public static UserDto EmployeeDaoToDto(User userDao)
        {
            if (userDao == null) return null;
            UserDto dto = new UserDto();
            dto.UserName = userDao.UserName;
            dto.FirstName = userDao.FirstName;
            dto.LastName = userDao.LastName;
            dto.FullName = userDao.FullName;
            dto.EmailAddress = userDao.EmailAddress;
            dto.DateOfBirth = userDao.DateOfBirth;
            dto.Sex = userDao.Sex;
			 dto.ProfilePhoto = userDao.ProfilePhoto;

            return dto;

        }
        public static UserDto UserDaoToDto(User userDao)
        {
            if (userDao == null) return null;
            UserDto dto = new UserDto();
            dto.UserName = userDao.UserName;
            dto.FirstName = userDao.FirstName;
            dto.LastName = userDao.LastName;
            dto.FullName = userDao.FullName;
            dto.EmailAddress = userDao.EmailAddress;
            dto.DateOfBirth = userDao.DateOfBirth;
            dto.Sex = userDao.Sex;
			    dto.ProfilePhoto = userDao.ProfilePhoto;
            dto.UserID = userDao.UserID;

            return dto;

        }
        
        public static User UserDtoToDao(UserDto userDto)
        {
            if (userDto == null) return null;
            return new User()
            {
                UserName = userDto.UserName,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                FullName = userDto.FullName,
                EmailAddress = userDto.EmailAddress,
                DateOfBirth = userDto.DateOfBirth,
                Sex = userDto.Sex,
				 ProfilePhoto = userDto.ProfilePhoto,
                 UserID = userDto.UserID

            };
        }

        public static List<UserDto> UserDaoToDto(List<User> userDaoList)
        {
            if (userDaoList == null) return null;
            var userList = (from userObj in userDaoList
                            select UserDaoToDto(userObj)).ToList();
            return userList;
        }


        
        public static User EmployeeDtoToDao(UserDto userDto)
        {
            if (userDto == null) return null;
            return new User()
            {
                UserName = userDto.UserName,
                FirstName = userDto.FirstName,
                LastName = userDto.LastName,
                FullName = userDto.FullName,
                EmailAddress = userDto.EmailAddress,
                DateOfBirth = userDto.DateOfBirth,
                Sex = userDto.Sex
            };
        }
    }
}
