/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2016 (13.0.1742)
    Source Database Engine Edition : Microsoft SQL Server Enterprise Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [DocCoreDB]
GO
/****** Object:  StoredProcedure [doccore].[GetAllTeamMembersByEmailID]    Script Date: 11/30/2017 1:01:36 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

--Team members, Project Managers , Admin
ALTER PROCEDURE [doccore].[GetAllTeamMembersByEmailID]
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
		UNION

		SELECT [FullName], [EmailAddress],[ID]  FROM [doccore].[User]
		WHERE [ID] in 
			(SELECT [memberID] FROM [doccore].[Members] 
				WHERE [pID] in 
				(SELECT [pID] FROM [doccore].[ProjectManager] 
				  WHERE [ManagerID] = (SELECT [ID]  FROM [doccore].[User] WHERE [EmailAddress] = @EmailID)))
--Admin
