USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreUpdateUserAccessByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreUpdateUserAccessByEmailID]
END

GO


CREATE PROCEDURE [doccore].[CoreUpdateUserAccessByEmailID]
	
	@EmailAddress			VARCHAR(240),
	@ProjectRole           varchar(30)
AS
	UPDATE  [doccore].[Access]
	SET
	pID = (select pID from [doccore].[Permission] where projectRole = @ProjectRole)
	
	WHERE aID = (select ID from [doccore].[User] where EmailAddress=@EmailAddress);
	

	delete from [doccore].[ProjectManager] where @ProjectRole='TeamMember' and ManagerID in (select ID from [doccore].[User] where EmailAddress=@EmailAddress);
	delete from [doccore].[Members] where @ProjectRole='Manager' and memberID in (select ID from [doccore].[User] where EmailAddress=@EmailAddress);
	delete from [doccore].[ProjectManager] where @ProjectRole='Admin' and ManagerID in (select ID from [doccore].[User] where EmailAddress=@EmailAddress);
	delete from [doccore].[Members] where @ProjectRole='Admin' and memberID in (select ID from [doccore].[User] where EmailAddress=@EmailAddress);

RETURN 0


--EXEC [doccore].[CoreUpdateUserAccessByEmailID]  @EmailAddress= 'surenkajan@gmail.com',@ProjectRole='Manager'
--select * from  [doccore].[Access]
--select * from [doccore].[ProjectManager]
--select * from [doccore].[Members]
--select * from [doccore].[User]