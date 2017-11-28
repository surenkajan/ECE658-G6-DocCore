USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreCreateUserAccess]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreCreateUserAccess]
END
GO


CREATE PROCEDURE [doccore].[CoreCreateUserAccess]
	
	@ProjectRole				varchar(30),
	@EmailAddress          				VARCHAR(240)
	
AS

INSERT INTO [doccore].[Access]
	(aID,pID) VALUES
	(
		(select ID from [doccore].[User] where EmailAddress =@EmailAddress) ,(select pID from  [doccore].[Permission] where projectRole =@ProjectRole)
	)   ;

	--exec [doccore].[CoreCreateUserAccess] @ProjectRole='Manager', @EmailAddress='sam@gmail.com'

	--select * from [doccore].[User]
	--select * from  [doccore].[Access]
	--select * from  [doccore].[Permission] 
