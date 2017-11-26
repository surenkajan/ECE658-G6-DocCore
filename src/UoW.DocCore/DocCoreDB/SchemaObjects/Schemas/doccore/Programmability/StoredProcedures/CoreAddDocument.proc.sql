USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreAddDocument]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreAddDocument]
END
GO


CREATE PROCEDURE [doccore].[CoreAddDocument]
	@FileName				VARCHAR(100),
	@FileType				VARCHAR(10),
	@FileSummary			varbinary(MAX),
	@FileData				varbinary(MAX),
	@UploadedBy				int,
	@UploadedTime			datetime
AS
	INSERT INTO [doccore].[Documents]
	(FileName, FileType, FileSummary, FileData, UploadedBy, UploadedTime) VALUES
	(
		@FileName,@FileType, @FileSummary, @FileData, @UploadedBy, @UploadedTime
	);
RETURN 0
	
	