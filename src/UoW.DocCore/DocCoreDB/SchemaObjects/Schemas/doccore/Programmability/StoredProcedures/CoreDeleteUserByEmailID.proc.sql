USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreDeleteUserByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreDeleteUserByEmailID]
END
GO


CREATE PROCEDURE [doccore].[CoreDeleteUserByEmailID]
	@EmailAddress VARCHAR(240)
AS
Declare @ID  int
Set @ID =  (select ID from [doccore].[User] WHERE EmailAddress = @EmailAddress)
Begin
delete from  [doccore].[Access] where aID =@ID  ;
delete from  [doccore].[Documents] where UploadedBy =@ID ;
delete from [doccore].[Comments] where commentedBy=@ID ;
delete from [doccore].[SharedWith] where sharedTo =@ID
delete from [doccore].[ProjectManager] where ManagerID =@ID;
delete from [doccore].[Members] where memberID =@ID;

	DELETE FROM [doccore].[User]
	WHERE EmailAddress = @EmailAddress;


RETURN 0
End


--EXEC [doccore].[CoreDeleteUserByEmailID] @EmailAddress= 'user1@gmail.com'
	
	