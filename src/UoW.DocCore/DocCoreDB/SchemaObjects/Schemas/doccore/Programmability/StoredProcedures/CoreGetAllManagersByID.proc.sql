USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetAllManagersByID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetAllManagersByID]
END

GO

CREATE PROCEDURE [doccore].[CoreGetAllManagersByID]
@projectID int
AS
SELECT FullName,EmailAddress,ID FROM [doccore].[User] e ,  (select a.projectRole,b.aID from [doccore].[Permission] a,
[doccore].[Access] b,[doccore].[Project] f where a.pID=b.pID and a.projectRole ='Manager' and f.projectID=@projectID ) d where d.aID=e.ID

GO

--EXEC [doccore].[CoreGetAllManagersByID] @projectID= 18
--select * from [doccore].[User]
--select * from [doccore].[Project]
--select * from [doccore].[ProjectManager]