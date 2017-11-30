USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[GetAllSharedDocumentsForEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[GetAllSharedDocumentsForEmailID]
END

GO

CREATE PROCEDURE [doccore].[GetAllSharedDocumentsForEmailID]
	@EmailID VARCHAR(240),
	@UserTablePreFix varchar(10)
AS
SELECT 
[DocID],[Id],[FileName],[FileType],[FileSummary],[FileData] = Null,
(SELECT TOP 1 EmailAddress from [doccore].[User] where  ID = [UploadedBy]) as [UploadedBy] ,
[UploadedTime],[FileSizeInKB],[IsCheckedIn],[Modified],
(SELECT TOP 1 EmailAddress from [doccore].[User] where  ID = [ModifiedBy]) as [ModifiedBy]  
FROM [doccore].[Documents]
WHERE   IsCheckedIn = 1 AND DocID in 
	(SELECT DocID FROM [doccore].[SharedWith] 
		WHERE sharedTo = (SELECT TOP 1 ID from [doccore].[User] where EmailAddress = @EmailID))
GO

--EXEC [doccore].[CoreAllUsers] @UserTablePreFix= 'AU'