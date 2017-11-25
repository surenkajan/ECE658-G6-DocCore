USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetAllTeamMembersByID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetAllTeamMembersByID]
END

GO

CREATE PROCEDURE [doccore].[CoreGetAllTeamMembersByID]
@projectID int
AS
SELECT FullName,EmailAddress,ID FROM [doccore].[User] e ,  (select a.projectRole,b.aID from [doccore].[Permission] a,
[doccore].[Access] b,[doccore].[Project] f where a.pID=b.pID and a.projectRole ='TeamMember' and f.projectID=@projectID ) d where d.aID=e.ID

GO

--EXEC [doccore].[CoreGetAllTeamMembersByID] @projectID= 18
--select * from [doccore].[User]
--select * from [doccore].[Project]
--select * from [doccore].[ProjectManager]