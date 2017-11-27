USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreAddCommentsByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreAddCommentsByEmailID]
END
GO


CREATE PROCEDURE [doccore].[CoreAddCommentsByEmailID]
	@DocId							int,
	@currentUserEmailID				VARCHAR(240),
	@Comment						text,
	@CommentsTime					datetime
	
AS
	INSERT INTO [doccore].[Comments]
	(cID, comments,commentedBy,CommentedTime) VALUES
	(
		@DocId, @Comment, (Select us.ID from [doccore].[User] as us where us.EmailAddress = @currentUserEmailID), @CommentsTime
	);
RETURN 0