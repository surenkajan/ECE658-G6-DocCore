USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreAllUsers]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreAllUsers]
END

GO

CREATE PROCEDURE [doccore].[CoreAllUsers]
	@UserTablePreFix varchar(10)
AS
SELECT * FROM [doccore].[User]
GO

--EXEC [doccore].[CoreAllUsers] @UserTablePreFix= 'AU'