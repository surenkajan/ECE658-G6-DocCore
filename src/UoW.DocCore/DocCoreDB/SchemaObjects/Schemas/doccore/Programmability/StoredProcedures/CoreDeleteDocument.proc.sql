USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[DeleteDocument]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[DeleteDocument]
END
GO


CREATE PROCEDURE [doccore].[DeleteDocument]
	@DocID int
AS
	DELETE FROM [doccore].[Documents]
	WHERE DocID = @DocID;
RETURN 0


--EXEC [doccore].[CoreDeleteUserByEmailID] @EmailAddress= 'user1@gmail.com'
	
	