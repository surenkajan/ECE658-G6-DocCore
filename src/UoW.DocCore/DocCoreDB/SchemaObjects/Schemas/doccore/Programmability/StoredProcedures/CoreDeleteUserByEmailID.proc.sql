USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreDeleteUserByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreDeleteUserByEmailID]
END
GO


CREATE PROCEDURE [doccore].[CoreDeleteUserByEmailID]
	@EmailAddress VARCHAR(240)
AS
	DELETE FROM [doccore].[User]
	WHERE EmailAddress = @EmailAddress;
RETURN 0


--EXEC [doccore].[CoreDeleteUserByEmailID] @EmailAddress= 'user1@gmail.com'
	
	