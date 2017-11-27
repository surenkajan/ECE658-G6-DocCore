USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[GetAllDocuments]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[GetAllDocuments]
END

GO

CREATE PROCEDURE [doccore].[GetAllDocuments]
	@UserTablePreFix varchar(10)
AS
SELECT [DocID],[Id],[FileName],[FileType],[FileSummary],[FileData] = Null,[UploadedBy],[UploadedTime],[FileSizeInKB],[IsCheckedIn],[Modified],[ModifiedBy] 
FROM [doccore].[Documents]
GO

--EXEC [doccore].[CoreAllUsers] @UserTablePreFix= 'AU'