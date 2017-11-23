USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetUserTableColumns]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetUserTableColumns]
END

GO

CREATE PROCEDURE [doccore].[CoreGetUserTableColumns]
	@TablePreFix varchar(10), 
	@UserTableColumns varchar(MAX) OUTPUT
AS
	  
	SELECT @UserTableColumns = REPLACE(REPLACE('
	  ,[TableNamePrefix]ID					  AS ''[NamePrefix]ID''
	  ,[TableNamePrefix]UserName              AS ''[NamePrefix]UserName''
	  ,[TableNamePrefix]FirstName              AS ''[NamePrefix]FirstName''
      ,[TableNamePrefix]LastName			  AS ''[NamePrefix]LastName''
      ,[TableNamePrefix]FullName			  AS ''[NamePrefix]FullName''
      ,[TableNamePrefix]EmailAddress          AS ''[NamePrefix]EmailAddress''
      ,[TableNamePrefix]DateOfBirth           AS ''[NamePrefix]DateOfBirth''
      ,[TableNamePrefix]Sex                   AS ''[NamePrefix]Sex''', '[NamePrefix]', @TablePreFix), '[TableNamePrefix]', @TablePreFix + '.')