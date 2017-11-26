USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[UpdateDocument]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[UpdateDocument]
END

GO


CREATE PROCEDURE [doccore].[UpdateDocument]
	@DocID				int,
	@FileName				VARCHAR(100),
	@FileType				VARCHAR(10),
	@FileSummary			varbinary(MAX),
	@FileData				varbinary(MAX),
	@UploadedBy				int,
	@UploadedTime			datetime
AS
	UPDATE  [doccore].[Documents]
	SET
	FileName = @FileName, 
	FileType = @FileType, 
	FileSummary = @FileSummary, 
	FileData = @FileData, 
	UploadedBy = @UploadedBy, 
	UploadedTime = @UploadedTime
	WHERE DocID = @DocID;
RETURN 0


--EXEC [doccore].[CoreUpdateUserByEmailID] @UserName = "FooBooFoo1", @FirstName = "Foo1",@LastName = "Boo1", @FullName = "Foo Boo1", @EmailAddress= 'fooboo1@gmail.com', @DateOfBirth = '1993-11-18 10:34:09.000'  , @Sex="Male";