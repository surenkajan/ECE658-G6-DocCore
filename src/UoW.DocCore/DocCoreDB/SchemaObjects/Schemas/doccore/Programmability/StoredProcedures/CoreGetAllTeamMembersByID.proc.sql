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
		select b.FullName,b.EmailAddress,b.ID  from [doccore].[Members] a, [doccore].[User] b where a.memberID=b.ID and a.pID=@projectID
GO



--EXEC [doccore].[CoreGetAllTeamMembersByID] @projectID= 18
--select * from [doccore].[User]
--select * from [doccore].[Project]
--select * from [doccore].[ProjectManager]