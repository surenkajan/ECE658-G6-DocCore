USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetAllProject]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetAllProject]
END

GO

CREATE PROCEDURE [doccore].[CoreGetAllProject]
	@UserTablePreFix varchar(10)
AS
SELECT * FROM [doccore].[Project]
GO
