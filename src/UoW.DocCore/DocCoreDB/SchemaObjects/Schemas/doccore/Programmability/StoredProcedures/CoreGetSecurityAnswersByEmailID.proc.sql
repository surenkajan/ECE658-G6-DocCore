USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[GetCoreSecurityAnswersEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[GetCoreSecurityAnswersEmailID]
END
GO


CREATE PROCEDURE [doccore].[GetCoreSecurityAnswersEmailID]
	@EmailAddress			VARCHAR(240),
	@Question			VARCHAR(max)

AS
	-- Answers to the 1st Questions
	SELECT * FROM [doccore].[UserSecurity] 
	WHERE 
	UserID = (SELECT ID FROM [DocCoreDB].[doccore].[User] WHERE EmailAddress = @EmailAddress) 
	AND 
	QuestionID = (SELECT [ID] FROM [DocCoreDB].[doccore].[SecurityQuestion] WHERE Question = @Question)

	GO
	

	
	