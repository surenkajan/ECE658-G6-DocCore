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
        public static ProjectDto  ProjectDaoToDto(Project projectDao)
        {
            if (projectDao == null) return null;
            ProjectDto dto = new ProjectDto();
            dto.ProjectName = projectDao.ProjectName;
            dto.ProjectManager = projectDao.ProjectManager;
            dto.TeamMember = projectDao.TeamMember;
            dto.pID = projectDao.pID;
            return dto;

        }

        public static List<ProjectDto> ProjectDaoToDto(List<Project> projectDaoList)
        {
            if (projectDaoList == null) return null;
            var userList = (from userObj in projectDaoList
                            select ProjectDaoToDto(userObj)).ToList();
            return userList;
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
                ProjectName = projectDto.ProjectName,
                ProjectManager = projectDto.ProjectManager,
            
                TeamMember = projectDto.TeamMember,
                pID= projectDto.pID

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

        //Documents Mapper
        public static DocumentDto DocumentDaoToDto(Document document)
        {
            if (document == null) return null;
            DocumentDto dto = new DocumentDto();
            dto.DocID = document.DocID;
            dto.FileData = document.FileData;
            dto.FileName = document.FileName;
            dto.FileSummary = document.FileSummary;
            dto.FileSizeInKB = document.FileSizeInKB;
            dto.FileType = document.FileType;
            dto.UploadedBy = document.UploadedBy;
            dto.UploadedTime = document.UploadedTime;
            dto.Modified = document.Modified;
            dto.ModifiedBy = document.ModifiedBy;
            dto.IsCheckedIn = document.IsCheckedIn;
            return dto;

        }

        public static Document DocumentDtoToDao(DocumentDto docDto)
        {
            if (docDto == null) return null;
            return new Document()
            {
                DocID = docDto.DocID,
                FileData = docDto.FileData,
                FileName = docDto.FileName,
                FileSummary = docDto.FileSummary,
                FileSizeInKB = docDto.FileSizeInKB,
                FileType = docDto.FileType,
                UploadedBy = docDto.UploadedBy,
                UploadedTime = docDto.UploadedTime,
                Modified = docDto.Modified,
                ModifiedBy = docDto.ModifiedBy,
                IsCheckedIn = docDto.IsCheckedIn
            };
        }

        public static List<DocumentDto> DocumentDaoToDto(List<Document> DocumentList)
        {
            if (DocumentList == null) return null;
            var DocList = (from docObj in DocumentList
                           select DocumentDaoToDto(docObj)).ToList();
            return DocList;
        }

    }
}
