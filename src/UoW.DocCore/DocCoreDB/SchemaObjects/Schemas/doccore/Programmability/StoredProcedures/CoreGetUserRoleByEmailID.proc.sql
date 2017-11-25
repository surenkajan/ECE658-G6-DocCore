USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetUserRoleByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetUserRoleByEmailID]
END

GO

CREATE PROCEDURE [doccore].[CoreGetUserRoleByEmailID] 
	@EmailAddress VARCHAR(240)
	
AS
SELECT a.UserName,a.FirstName,a.LastName,a.FullName,a.EmailAddress,b.projectRole,a.ID,a.DateOfBirth,a.sex,a.ProfilePhoto FROM (select * from  [doccore].[User] WHERE EmailAddress = @EmailAddress) a,
(select c.projectRole,d.aID from [doccore].[Permission] c, [doccore].[Access] d where  c.pID=d.pID) b where b.aID=a.ID

EXEC [doccore].[CoreGetUserRoleByEmailID] @EmailAddress= 'surenkajan@gmail.com'
--select * from [doccore].[User]
--insert into [doccore].[Access] (aID,pID) values (6,2)
--delete from  [doccore].[Permission]
--select * from  [doccore].[Access]