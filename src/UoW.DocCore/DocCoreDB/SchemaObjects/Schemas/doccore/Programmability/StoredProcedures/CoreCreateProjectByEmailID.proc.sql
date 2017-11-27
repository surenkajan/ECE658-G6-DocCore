USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreCreateProjectByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreCreateProjectByEmailID]
END
GO


CREATE PROCEDURE [doccore].[CoreCreateProjectByEmailID]
	@ProjectManager				VARCHAR(400),
	@ProjectName				VARCHAR(400),
	@TeamMember				varchar(400)
	
AS
DECLARE @err_message int
if (@ProjectName not in (select projectName from [doccore].[Project]) )
Begin

	INSERT INTO [doccore].[Project]
	(projectName) VALUES
	(
		@ProjectName
	)   ;
	insert into [doccore].[ProjectManager] (ManagerID,pID) select  (Select TOP 1 u.ID from [doccore].[User] u  where u.FullName = Items) ,
	(select TOP 1 projectID from [doccore].[Project] ORDER BY projectID DESC)  from [doccore].[Split](@ProjectManager, ',')  ;
	
	insert into [doccore].[Members] (memberID,pID) select  (Select TOP 1 u.ID from [doccore].[User] u  where u.FullName = Items) ,
	(select TOP 1 projectID from [doccore].[Project] ORDER BY projectID DESC)  from [doccore].[Split](@TeamMember, ',') ;
	
RETURN 0
end


else
begin
SET @err_message = 'Existing project'
RAISERROR (@err_message,10,1)
end



--select * from [doccore].[User]
--select * from [doccore].[Project]
--delete from [doccore].[Project]
--select * from [doccore].[ProjectManager]
--delete from [doccore].[ProjectManager]
--select * from  [doccore].[Members] 
--delete from [doccore].[Members]
--exec [doccore].[CoreCreateProjectByEmailID]  @ProjectManager='Kajaruban Surendran,Enlil TOm',
--@ProjectName ='test project' , @TeamMember ='Brindha G,Shitij V'





	
	