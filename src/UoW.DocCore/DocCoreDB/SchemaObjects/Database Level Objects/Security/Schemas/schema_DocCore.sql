

--https://www.codeproject.com/Articles/128657/How-Do-I-Use-SQL-File-Stream
EXEC sp_configure filestream_access_level, 2
GO
RECONFIGURE
GO

CREATE DATABASE DocCoreDB 
ON
PRIMARY ( NAME = DocCoreDB,
    FILENAME = 'c:\DocCoreDocuments\DocCoreDB.mdf'),
FILEGROUP FileStream CONTAINS FILESTREAM( NAME = DocCoreDB_FileStream,
    FILENAME = 'c:\DocCoreDocuments\DocCoreDB_FileStream')
LOG ON  ( NAME = DocCoreDB_log,
    FILENAME = 'c:\DocCoreDocuments\DocCoreDB_log.ldf')
GO
