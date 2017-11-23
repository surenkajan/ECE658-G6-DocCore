USE [DocCoreDB]
GO

IF EXISTS ( SELECT * 
            FROM   sysobjects 
            WHERE  id = object_id(N'[doccore].[CoreGetUserByFullName]') 
                   and OBJECTPROPERTY(id, N'IsProcedure') = 1 )
BEGIN
    DROP PROCEDURE [doccore].[CoreGetUserByFullName]
END

GO


CREATE PROCEDURE [doccore].[CoreGetUserByFullName] 
	@Fullname varchar(240)
AS
SELECT * FROM [doccore].[User] u WHERE u.FullName = @Fullname
GO

--EXEC [doccore].[CoreGetUserByEmailIDtemp] @EmailAddress= 'surenkajan@gmail.com'