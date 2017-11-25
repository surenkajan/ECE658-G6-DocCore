USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetProjectDetailsById]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetProjectDetailsById]
END

GO

CREATE PROCEDURE [doccore].[CoreGetProjectDetailsById]
@projectID int
AS
SELECT projectName, stuff(
        (select ', ' +  new.FullName from (
select b.FullName  from [doccore].[ProjectManager] a, [doccore].[User] b where a.ManagerID=b.ID and pID=@projectID) new
FOR XML PATH ('')), 1, 1, ''
    )  ProjectManagers,
	stuff(
        (select ', ' +  new.FullName from (select b.FullName  from [doccore].[Members] a, [doccore].[User] b where a.memberID=b.ID and pID=@projectID) new
FOR XML PATH ('')), 1, 1, ''
    )  ProjectMembers

	
	 from [doccore].[Project] where [Project].projectID=@projectID
	
	
	


--EXEC [doccore].[CoreGetProjectDetailsById] @projectID= 11
--select * from [doccore].[Project] 
--select * from [doccore].[ProjectManager]
--select * from [doccore].[Members]