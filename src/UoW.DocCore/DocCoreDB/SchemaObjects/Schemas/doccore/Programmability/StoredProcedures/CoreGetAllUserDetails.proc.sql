USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetAllUserDetails]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetAllUserDetails]
END

GO

CREATE PROCEDURE [doccore].[CoreGetAllUserDetails] 
	
	
AS
SELECT a.UserName,a.FirstName,a.LastName,a.FullName,a.EmailAddress,b.projectRole,a.ID ,a.DateOfBirth,a.sex,a.ProfilePhoto FROM (select * from  [doccore].[User] ) a,
(select c.projectRole,d.aID from [doccore].[Permission] c, [doccore].[Access] d where  c.pID=d.pID) b where b.aID=a.ID



--exec [doccore].[CoreGetAllUserDetails] 