USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[GetUploadedAndSharedWithMeByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[GetUploadedAndSharedWithMeByEmailID]
END

GO

CREATE PROCEDURE [doccore].[GetUploadedAndSharedWithMeByEmailID]
	@U_User VARCHAR(240),
	@L_User VARCHAR(240),
	@UserTablePreFix varchar(10)
AS
SELECT 
[DocID],[Id],[FileName],[FileType],[FileSummary],[FileData] = Null,
(SELECT TOP 1 EmailAddress from [doccore].[User] where  ID = [UploadedBy]) as [UploadedBy] ,
[UploadedTime],[FileSizeInKB],[IsCheckedIn],[Modified],
(SELECT TOP 1 EmailAddress from [doccore].[User] where  ID = [ModifiedBy]) as [ModifiedBy]  
FROM [doccore].[Documents]
WHERE (DocID in 
			(SELECT DocID FROM [doccore].[SharedWith] 
			WHERE sharedTo = (SELECT TOP 1 ID from [doccore].[User] where EmailAddress = @L_User))
	  )
	  AND(
		UploadedBy = (SELECT TOP 1 ID from [doccore].[User] where  EmailAddress = @U_User)
	  )
	  AND  IsCheckedIn = 1

GO


--exec [doccore].[GetUploadedAndSharedWithMeByEmailID]
--@U_User = 'surenkajan@gmail.com',
--@L_User = 'user4@gmail.com',
--@UserTablePreFix = 'AU'