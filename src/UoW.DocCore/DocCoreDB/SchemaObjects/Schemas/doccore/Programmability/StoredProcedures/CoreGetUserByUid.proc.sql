USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetUserByUid]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetUserByUid]
END

GO


CREATE PROCEDURE [doccore].[CoreGetUserByUid] 
	@Uid int
AS
SELECT * FROM [doccore].[User] WHERE ID = @Uid
GO

--EXEC [doccore].[CoreGetUserByEmailIDtemp] @EmailAddress= 'surenkajan@gmail.com'