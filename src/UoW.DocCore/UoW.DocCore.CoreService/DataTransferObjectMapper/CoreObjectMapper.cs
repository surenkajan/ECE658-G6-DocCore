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
            dto.ProjectRole = userDao.ProjectRole;

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

        public static Project ProjectDtoToDao(ProjectDto projectDto)
        {
            if (projectDto == null) return null;
            return new Project()
            {
                ProjectManager = projectDto.ProjectManager,
                ProjectName = projectDto.TeamMember,
                TeamMember = projectDto.TeamMember

            };
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

        public static SecurityQuestionDto SecurityQuestionDaoToDto(SecurityQuestion SecurityQuestion)
        {
            if (SecurityQuestion == null) return null;
            SecurityQuestionDto dto = new SecurityQuestionDto();
            dto.ID = SecurityQuestion.ID;
            dto.Question = SecurityQuestion.Question;


            return dto;
        }

        public static List<SecurityQuestionDto> SecurityQuestionsDaoToDto(List<SecurityQuestion> SecurityQuestionDaoList)
        {
            if (SecurityQuestionDaoList == null) return null;
            var secList = (from secObj in SecurityQuestionDaoList
                           select SecurityQuestionDaoToDto(secObj)).ToList();
            return secList;
        }

        //SecurityAnswersDaoToDto
        public static SecurityAnswersDto SecurityAnswersDaoToDto(SecurityAnswers SecurityAnswersDao)
        {
            if (SecurityAnswersDao == null) return null;
            SecurityAnswersDto dto = new SecurityAnswersDto();
            dto.UserEmailID = SecurityAnswersDao.UserEmailID;
            dto.QuestionsAnswers = SecurityAnswersDao.QuestionsAnswers;

            return dto;
        }

        public static SecurityAnswers SecurityAnswersDtoToDao(SecurityAnswersDto secAnsDto)
        {
            if (secAnsDto == null) return null;
            return new SecurityAnswers()
            {
                UserEmailID = secAnsDto.UserEmailID,
                QuestionsAnswers = new List<SecurityAnswerPair>()
                {
                    new SecurityAnswerPair(){
                            Question = new SecurityQuestion(){ Question = secAnsDto.QuestionsAnswers[0].Question.Question},
                            Answer =  secAnsDto.QuestionsAnswers[0].Answer
                        },
                        new SecurityAnswerPair(){
                            Question = new SecurityQuestion(){ Question = secAnsDto.QuestionsAnswers[1].Question.Question},
                            Answer =  secAnsDto.QuestionsAnswers[1].Answer
                        }
                }
            };
        }

        public static SecurityAnswersDto SecurityQuestionDaoToDto(SecurityAnswers SecurityQuestionAnswer)
        {
            if (SecurityQuestionAnswer == null) return null;
            return new SecurityAnswersDto()
            {
                UserEmailID = SecurityQuestionAnswer.UserEmailID,
                QuestionsAnswers = new List<SecurityAnswerPair>()
                {
                    new SecurityAnswerPair(){
                            Question = new SecurityQuestion(){ Question = SecurityQuestionAnswer.QuestionsAnswers[0].Question.Question},
                            Answer =  SecurityQuestionAnswer.QuestionsAnswers[0].Answer
                        },
                        new SecurityAnswerPair(){
                            Question = new SecurityQuestion(){ Question = SecurityQuestionAnswer.QuestionsAnswers[1].Question.Question},
                            Answer =  SecurityQuestionAnswer.QuestionsAnswers[1].Answer
                        }
                }
            };
        }

    }
}
