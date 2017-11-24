USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[AddSecurityAnswersEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[AddSecurityAnswersEmailID]
END
GO


CREATE PROCEDURE [doccore].[AddSecurityAnswersEmailID]
	@EmailAddress			VARCHAR(240),
	--@QuestionAndAnswers	    VARCHAR(max),
	@Question1			VARCHAR(max),
	@Question1Answer    VARCHAR(max),
	@Question2			VARCHAR(max),
	@Question2Answer    VARCHAR(max)

AS
	-- Answers to the 1st Questions
	INSERT INTO [doccore].[UserSecurity]
	(UserID, QuestionID, Answer) VALUES
	(
		(SELECT ID FROM [DocCoreDB].[doccore].[User] where EmailAddress = @EmailAddress),
		(SELECT ID FROM [DocCoreDB].[doccore].[SecurityQuestion] where Question = @Question1),
		@Question1Answer
	);
	-- Answers to the 2nd Questions
	INSERT INTO [doccore].[UserSecurity]
	(UserID, QuestionID, Answer) VALUES
	(
		(SELECT ID FROM [DocCoreDB].[doccore].[User] where EmailAddress = @EmailAddress),
		(SELECT ID FROM [DocCoreDB].[doccore].[SecurityQuestion] where Question = @Question2),
		@Question2Answer
	);
RETURN 0
	
	