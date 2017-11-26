USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreUpdateProjectByID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreUpdateProjectByID]
END

GO


CREATE PROCEDURE [doccore].[CoreUpdateProjectByID]
	@ProjectID				int,
	@ProjectManagers				VARCHAR(500),
	@TeamMembers				VARCHAR(500)
	
AS
delete from [doccore].[ProjectManager] where pID =@ProjectID;
delete from [doccore].[Members] where pID=@ProjectID;
insert into [doccore].[ProjectManager] (ManagerID,pID) select (Select TOP 1 u.ID from [doccore].[User] u  where u.FullName = Items),
 @ProjectID from [doccore].[Split](@ProjectManagers, ',') ;
 insert into [doccore].[Members] (memberID,pID) select (Select TOP 1 u.ID from [doccore].[User] u  where u.FullName = Items),
 @ProjectID from [doccore].[Split](@TeamMembers, ',') ;




--EXEC [doccore].[CoreUpdateProjectByID] @ProjectID = 14, @ProjectManagers='Jaspreet S,Sam Deepak',
--@TeamMembers= 'Enlil TOm,Shitij V,Brindha G'

	
	

--select * from [doccore].[ProjectManager]
--select * from [doccore].[Members]
--select * from [doccore].[Project]
--select * from [doccore].[User]
	
	