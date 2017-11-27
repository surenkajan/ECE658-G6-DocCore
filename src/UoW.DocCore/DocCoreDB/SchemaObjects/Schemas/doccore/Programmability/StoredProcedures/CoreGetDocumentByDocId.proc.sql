USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[GetDocumentByDocID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[GetDocumentByDocID]
END

GO

CREATE PROCEDURE [doccore].[GetDocumentByDocID] 
	@DocID int, 
	@UserTablePreFix varchar(10)
AS
SELECT [DocID],[Id],[FileName],[FileType],[FileSummary],[FileData] = Null,[UploadedBy],[UploadedTime],[FileSizeInKB],[IsCheckedIn],[Modified],[ModifiedBy] 
FROM [doccore].[Documents] WHERE DocID = @DocID
GO

--EXEC [doccore].[CoreGetUserByEmailIDtemp] @EmailAddress= 'surenkajan@gmail.com'