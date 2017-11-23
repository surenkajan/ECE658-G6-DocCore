USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetUserByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetUserByEmailID]
END

GO

CREATE PROCEDURE [doccore].[CoreGetUserByEmailID] 
	@EmailAddress VARCHAR(240), 
	@UserTablePreFix varchar(10)
AS
SELECT * FROM [doccore].[User] WHERE EmailAddress = @EmailAddress
GO

--EXEC [doccore].[CoreGetUserByEmailIDtemp] @EmailAddress= 'surenkajan@gmail.com'