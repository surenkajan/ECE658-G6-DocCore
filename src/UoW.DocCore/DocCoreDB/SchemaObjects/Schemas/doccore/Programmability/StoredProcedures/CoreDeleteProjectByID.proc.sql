USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreDeleteProjectByID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreDeleteProjectByID]
END
GO


CREATE PROCEDURE [doccore].[CoreDeleteProjectByID]
	@ProjectID int
AS
	Delete from [doccore].[ProjectManager] where pID =@ProjectID;
	Delete from [doccore].[Members] where pID =@ProjectID;
	DELETE FROM [doccore].[Project]
	WHERE projectID = @ProjectID;

RETURN 0
	
	
	
--EXEC [doccore].[CoreDeleteProjectByID] @ProjectID= 18
--select * from [doccore].[ProjectManager]
--select * from [doccore].[Members]
--select * from [doccore].[Project]
	
	