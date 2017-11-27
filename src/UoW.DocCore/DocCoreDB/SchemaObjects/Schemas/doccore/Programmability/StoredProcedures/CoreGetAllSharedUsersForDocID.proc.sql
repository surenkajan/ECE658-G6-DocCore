USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[GetAllSharedUsersForDocID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[GetAllSharedUsersForDocID]
END
GO


CREATE PROCEDURE [doccore].[GetAllSharedUsersForDocID] 
	@DocId int
As
Begin

	SELECT 
	usr.ID as ID,
	usr.UserName as UserName,
	usr.FirstName as FirstName,
	usr.LastName as LastName,
	usr.FullName as FullName,
	usr.EmailAddress as EmailAddress,
	usr.DateOfBirth as DateOfBirth,
	usr.Sex as Sex,
	usr.ProfilePhoto as ProfilePhoto
	FROM [doccore].[SharedWith] as shared
	INNER JOIN [doccore].[User] as usr
	ON shared.[sharedTo] = usr.[ID]
	WHERE shared.[DocID] = @DocId
	order by usr.FirstName   
END
GO
--exec  [doccore].[CoreGetCommentsByID] @DocId =3