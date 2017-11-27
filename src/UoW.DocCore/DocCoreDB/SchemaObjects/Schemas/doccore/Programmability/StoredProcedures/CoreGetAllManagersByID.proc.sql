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
	select b.FullName,b.EmailAddress,b.ID  from [doccore].[ProjectManager] a, [doccore].[User] b where a.ManagerID=b.ID and a.pID=@projectID
GO


--EXEC [doccore].[CoreGetAllManagersByID] @projectID= 18
--select * from [doccore].[User]
--select * from [doccore].[Project]
--select * from [doccore].[ProjectManager]