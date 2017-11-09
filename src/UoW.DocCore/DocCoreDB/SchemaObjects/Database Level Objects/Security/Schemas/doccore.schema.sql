USE [DocCore]
GO

IF NOT EXISTS (
SELECT  schema_name
FROM    information_schema.schemata
WHERE   schema_name = 'doccore' ) 

BEGIN
EXEC sp_executesql N'CREATE SCHEMA doccore'
END

GO