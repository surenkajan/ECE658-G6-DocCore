USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetSecurityQuestions]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetSecurityQuestions]
END

GO

CREATE PROCEDURE [doccore].[CoreGetSecurityQuestions]
	@UserTablePreFix varchar(10)
AS
SELECT * FROM [doccore].[SecurityQuestion]
GO

--USE Pictre

--INSERT INTO [pictre].[SecurityQuestion] (Question)
--VALUES ('What is your Dog Name?')

--INSERT INTO [pictre].[SecurityQuestion] (Question)
--VALUES ('Where you Born?')

--EXEC [pictre].[CoreGetSecurityQuestions] @UserTablePreFix= 'AU'