USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[GetAllDocuments]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[GetAllDocuments]
END

GO

CREATE PROCEDURE [doccore].[GetAllDocuments]
	@UserTablePreFix varchar(10)
AS
SELECT * FROM [doccore].[Documents]
GO

--EXEC [doccore].[CoreAllUsers] @UserTablePreFix= 'AU'