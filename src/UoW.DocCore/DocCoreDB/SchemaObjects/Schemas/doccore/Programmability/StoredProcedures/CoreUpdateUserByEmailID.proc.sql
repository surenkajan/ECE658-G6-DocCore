USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreUpdateUserByEmailID]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreUpdateUserByEmailID]
END

GO


CREATE PROCEDURE [doccore].[CoreUpdateUserByEmailID]
	@UserName				VARCHAR(50),
	@FirstName				VARCHAR(150),
	@LastName				VARCHAR(150),
	@FullName				VARCHAR(240),
	@EmailAddress			VARCHAR(240),
	@DateOfBirth			DATETIME,
	@Sex					VARCHAR(30),
	@ProfilePhoto			image
AS
	UPDATE  [doccore].[User]
	SET
	UserName = @UserName, 
	FirstName = @FirstName, 
	LastName = @LastName, 
	FullName = @FullName, 
	DateOfBirth = @DateOfBirth, 
	Sex = @Sex,
	ProfilePhoto = @ProfilePhoto
	WHERE EmailAddress = @EmailAddress;
RETURN 0


--EXEC [doccore].[CoreUpdateUserByEmailID] @UserName = "FooBooFoo1", @FirstName = "Foo1",@LastName = "Boo1", @FullName = "Foo Boo1", @EmailAddress= 'fooboo1@gmail.com', @DateOfBirth = '1993-11-18 10:34:09.000'  , @Sex="Male";