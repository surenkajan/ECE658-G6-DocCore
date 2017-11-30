USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[GetAllTeamMembersByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[GetAllTeamMembersByEmailID]
END

GO

--Team members, Project Managers , Admin
CREATE PROCEDURE [doccore].[GetAllTeamMembersByEmailID]
@EmailID VARCHAR(240)
AS
--Team members of same projects
		SELECT [FullName], [EmailAddress],[ID]  FROM [doccore].[User]
		WHERE [ID] in 
			(SELECT [memberID] FROM [doccore].[Members] 
				WHERE [pID] in 
				(SELECT [pID] FROM [doccore].[Members] 
				  WHERE [memberID] = (SELECT [ID]  FROM [doccore].[User] WHERE [EmailAddress] = @EmailID)))
		UNION
--Project Managers of same projects
		SELECT [FullName], [EmailAddress],[ID]  FROM [doccore].[User]
		WHERE [ID] in 
			(SELECT [ManagerID] FROM [doccore].[ProjectManager] 
				WHERE [pID] in 
				(SELECT [pID] FROM [doccore].[Members] 
				  WHERE [memberID] = (SELECT [ID]  FROM [doccore].[User] WHERE [EmailAddress] = @EmailID)))
--Admin
GO



--EXEC [doccore].[CoreGetAllTeamMembersByID] @projectID= 18
--select * from [doccore].[User]
--select * from [doccore].[Project]
--select * from [doccore].[ProjectManager]