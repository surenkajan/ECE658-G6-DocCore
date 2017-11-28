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
    public partial class Service : IDocumentService
    {
        public int AddDocuments(DocumentDto document)
        {
            DocumentDao docDao = new DocumentDao();
            return docDao.AddDocument(CoreObjectMapper.DocumentDtoToDao(document));
        }

        public int DeleteDocumentsByDocID(string DocID)
        {
            DocumentDao docDao = new DocumentDao();
            return docDao.DeleteDocument(DocID);
        }

        public List<DocumentDto> GetAllDocuments()
        {
            DocumentDao docDao = new DocumentDao();
            return CoreObjectMapper.DocumentDaoToDto(docDao.GetAllDocuments());
        }

        public List<DocumentDto> GetAllDocumentsUploadedByEmailID(string EmailID)
        {
            DocumentDao docDao = new DocumentDao();
            return CoreObjectMapper.DocumentDaoToDto(docDao.GetAllDocumentsUploadedByEmailID(EmailID));
        }

        public List<DocumentDto> GetAllSharedDocumentsForEmailID(string EmailID)
        {
            DocumentDao docDao = new DocumentDao();
            return CoreObjectMapper.DocumentDaoToDto(docDao.GetAllSharedDocumentsForEmailID(EmailID));
        }

        public DocumentDto GetDocumentByDocID(string DocID)
        {
            DocumentDao docDao = new DocumentDao();
            return CoreObjectMapper.DocumentDaoToDto(docDao.GetDocumentByDocID(DocID));
        }

        public int UpdateDocuments(DocumentDto document)
        {
            DocumentDao docDao = new DocumentDao();
            return docDao.UpdateDocument(CoreObjectMapper.DocumentDtoToDao(document));
        }

        public List<CommentsDto> GetCommentsByID(int DocID)
        {
            CommentsDao commentdao = new CommentsDao();
            return CoreObjectMapper.CommentDaoToDto(commentdao.GetCommentsByID(DocID));
        }

        public int AddCommentsByEmailID(CommentsDto comments)
        {
            CommentsDao commentdao = new CommentsDao();
            return commentdao.AddCommentsByEmailID(CoreObjectMapper.CommentsDtoToDao(comments));
        }

        public List<UserDto> GetAllSharedUsersForDocID(int DocID)
        {
            DocumentDao docDao = new DocumentDao();
            List<UserDto> usrList =  CoreObjectMapper.UserDaoToDto(docDao.GetAllSharedUsersForDocID(DocID));

            return usrList;
        }

        public List<DocumentDto> GetUploadedAndSharedWithMeByEmailID(string U_User, string L_User)
        {
            DocumentDao docDao = new DocumentDao();
            return CoreObjectMapper.DocumentDaoToDto(docDao.GetUploadedAndSharedWithMeByEmailID(U_User, L_User));
        }
    }
}
