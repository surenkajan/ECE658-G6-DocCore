USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[UpdateDocumentMetaData]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[UpdateDocumentMetaData]
END

GO


CREATE PROCEDURE [doccore].[UpdateDocumentMetaData]
	@DocID				int,
	@FileName				VARCHAR(100),
	@FileType				VARCHAR(10),
	@FileSummary			VARCHAR(MAX),
	@FileSizeInKB			bigint ,
	@UploadedBy				VARCHAR(240),
	@UploadedTime			datetime,
	@IsCheckedIn			int,
	@Modified				datetime,
	@ModifiedBy				VARCHAR(240),
	@SharedWith				VARCHAR(MAX)
AS
			
			DELETE FROM [DocCoreDB].[doccore].[SharedWith] WHERE DocID = @DocID;

			INSERT INTO [doccore].[SharedWith] (DocID,sharedTo) select  @DocID,(Select TOP 1 u.ID from [doccore].[User] u  where u.FullName = Items)
		    from [doccore].[Split](@SharedWith, ';');

            UPDATE  [doccore].[Documents]
			SET
			FileName = @FileName,
			FileSummary = @FileSummary,
			UploadedBy = (SELECT TOP 1 ID FROM [doccore].[User] WHERE EmailAddress = @UploadedBy), 
			UploadedTime = @UploadedTime,
			ModifiedBy = (SELECT TOP 1 ID FROM [doccore].[User] WHERE EmailAddress = @ModifiedBy), 
			Modified = @Modified,
			IsCheckedIn = @IsCheckedIn
			Output Inserted.DocID
			WHERE DocID = @DocID;
	
RETURN 0


--EXEC [doccore].[CoreUpdateUserByEmailID] @UserName = "FooBooFoo1", @FirstName = "Foo1",@LastName = "Boo1", @FullName = "Foo Boo1", @EmailAddress= 'fooboo1@gmail.com', @DateOfBirth = '1993-11-18 10:34:09.000'  , @Sex="Male";