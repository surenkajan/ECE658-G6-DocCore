USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetAllManagers]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetAllManagers]
END

GO

CREATE PROCEDURE [doccore].[CoreGetAllManagers]
@UserTablePreFix varchar(10)
AS
SELECT FullName,EmailAddress,ID FROM [doccore].[User] e ,  (select a.projectRole,b.aID from [doccore].[Permission] a,
[doccore].[Access] b where a.pID=b.pID and a.projectRole ='Manager' ) d where d.aID=e.ID

GO

--EXEC [doccore].[CoreGetAllManagers] @UserTablePreFix= 'AU'