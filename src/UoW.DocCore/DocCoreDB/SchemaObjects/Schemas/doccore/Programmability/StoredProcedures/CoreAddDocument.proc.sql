﻿USE [DocCoreDB]
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
	@FileSummary			VARCHAR(MAX),
	@FileSizeInKB			bigint ,
	@FileData				varbinary(MAX),
	@UploadedBy				VARCHAR(240),
	@UploadedTime			datetime,
	@IsCheckedIn			int,
	@Modified				datetime,
	@ModifiedBy				VARCHAR(240)
AS

	INSERT INTO [doccore].[Documents]
	(FileName, FileType, FileSummary, FileSizeInKB, FileData, UploadedBy, UploadedTime, IsCheckedIn, Modified, ModifiedBy) 
	Output Inserted.DocID
	VALUES
	(
		@FileName,@FileType, @FileSummary, @FileSizeInKB, @FileData, 
		(SELECT TOP 1 ID FROM [doccore].[User] WHERE EmailAddress = @UploadedBy) , 
		@UploadedTime, @IsCheckedIn, @Modified, (SELECT TOP 1 ID FROM [doccore].[User] WHERE EmailAddress = @ModifiedBy) 
	);

	RETURN -1;
	

--exec [doccore].[CoreAddDocument] @FileName = 'Test', @FileType = 'Testext', @FileSummary = 'TestDes',@FileSizeInKB = 123456, @FileData = 0x255044462D312E340A25E2E3CFD30A322030206F626A0A3C3C2F4C656E6774682034392F46696C7465722F466C6174654465636F64653E3E73747265616D0A789C2BE4720AE1323653B03030530849E1720DE10AE42A54305430004208999CABA01F9166A8E092AF10C80500EAA209F20A656E6473747265616D0A656E646F626A0A342030206F626A0A3C3C2F5265736F75726365733C3C2F584F626A6563743C3C2F586631203120 , @UploadedBy = 'surenkajan@gmail.com', @UploadedTime = '2011-12-24 13:00:00'

	
--exec [doccore].[CoreAddDocument] @FileName = 'Test', @FileType = 'Testext', @FileSummary = 'TestDes',@FileSizeInKB = 123456, 
--@FileData = 0x255044462D312E340A25E2E3CFD30A322030206F626A0A3C3C2F4C656E6774682034392F46696C7465722F466C6174654465636F64653E3E73747265616D0A789C2BE4720AE1323653B03030530849E1720DE10AE42A54305430004208999CABA01F9166A8E092AF10C80500EAA209F20A656E6473747265616D0A656E646F626A0A342030206F626A0A3C3C2F5265736F75726365733C3C2F584F626A6563743C3C2F586631203120 , 
--@UploadedBy = 'surenkajan@gmail.com', @UploadedTime = '2011-12-24 13:00:00',
--@IsCheckedIn = 0,
--@Modified = '2011-12-24 13:00:00',
--@ModifiedBy = 'user4@gmail.com'