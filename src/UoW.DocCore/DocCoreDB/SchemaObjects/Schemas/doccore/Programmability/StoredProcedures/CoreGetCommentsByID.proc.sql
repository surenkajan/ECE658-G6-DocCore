USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetCommentsByID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetCommentsByID]
END
GO


CREATE PROCEDURE [doccore].[CoreGetCommentsByID] 
	@DocId int
As
Begin
	select c.comments ,c.CommentedTime, u.FirstName, u.LastName, c.cID, c.commentedBy, u.FullName,u.ProfilePhoto 
	from [doccore].[Comments] c inner join [doccore].[User] u on c.commentedBy = u.ID where cID = @DocId
	order by c.CommentedTime desc
   
END
GO
--exec  [doccore].[CoreGetCommentsByID] @DocId =3