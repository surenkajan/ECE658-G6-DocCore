USE DocCoreDB
GO

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'User'
                          AND TABLE_SCHEMA = 'doccore')

BEGIN

CREATE TABLE [doccore].[User]
(
	ID						int IDENTITY(1,1),
	UserName				VARCHAR(50),
	FirstName				VARCHAR(150) NOT NULL,
	LastName				VARCHAR(150),
	FullName				VARCHAR(240),
	EmailAddress			VARCHAR(240) NOT NULL,
	DateOfBirth				DATETIME NOT NULL,
	Sex						VARCHAR(30) NOT NULL,
	ProfilePhoto    image

CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

END



IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Permission'
                          AND TABLE_SCHEMA = 'doccore')

BEGIN

CREATE TABLE [doccore].[Permission]
(
	pID						int IDENTITY(1,1),
	projectRole				varchar(30)
	
CONSTRAINT PK_PERMISSION_ID PRIMARY KEY CLUSTERED (pID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Access'
                          AND TABLE_SCHEMA = 'doccore')

BEGIN

CREATE TABLE [doccore].[Access]
(
	aID						int,
	pID				int
	
CONSTRAINT FK_USERACCESS_ID FOREIGN KEY (aID) REFERENCES [doccore].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_PERMISSION_ID FOREIGN KEY (pID) REFERENCES [doccore].[Permission] (pID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Documents'
                          AND TABLE_SCHEMA = 'doccore')

BEGIN

--CREATE TABLE [doccore].[Documents]
--(
--	dID						int IDENTITY(1,1),
--	title				varchar(100),
--  fileType              varchar(10),
--  uploadedBy            int,
--  uploadedTime            datetime,
--  document                BLOB
	
--CONSTRAINT FK_USER_ID FOREIGN KEY (uploadedBy) REFERENCES [doccore].[User] (ID) ON DELETE CASCADE,
--CONSTRAINT PK_DOCUMENT_ID PRIMARY KEY CLUSTERED (dID)
--)

CREATE TABLE [doccore].[Documents]
(
DocID			int Primary Key IDENTITY (1, 1),
Id				uniqueidentifier NOT NULL Unique ROWGUIDCOL Default newid(),
FileName		varchar(100),
FileType        varchar(10),
FileSummary		varchar(MAX),
FileData		varbinary(MAX) FileStream NULL,
UploadedBy      int,
UploadedTime    datetime

CONSTRAINT FK_USER_ID FOREIGN KEY (UploadedBy) REFERENCES [doccore].[User] (ID) ON DELETE CASCADE,
CONSTRAINT PK_DOCUMENT_ID PRIMARY KEY CLUSTERED (DocID)
)

END

--ALTER TABLE [doccore].[Documents]
--ALTER COLUMN FileSummary varchar(MAX);

-- To Test the File Stream...

--Insert Into [doccore].[Documents]
--([FileName],[FileData])
--Values
--('TestDoc', Cast('Hello World' As varbinary(max)))


--SELECT [DocID],[Id],[FileName],[FileData],CAST([FileData] As varchar(Max)) FROM [doccore].[Documents] 

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Comments'
                          AND TABLE_SCHEMA = 'doccore')

BEGIN

CREATE TABLE [doccore].[Comments]
(
	cID						int ,
	comments				text,
  commentedBy              int,
  CommentedTime            datetime
	
CONSTRAINT FK_COMMENT_ID FOREIGN KEY (cID) REFERENCES [doccore].[Documents] (DocID) ON DELETE CASCADE,
CONSTRAINT FK_USERCOMMENTS_ID FOREIGN KEY (commentedBy) REFERENCES [doccore].[User] (ID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'SharedWith'
                          AND TABLE_SCHEMA = 'doccore')

BEGIN

CREATE TABLE [doccore].[SharedWith]
(
	DocID						int ,
	sharedTo			   int
	
CONSTRAINT FK_DOCUMENT_SHARED_ID FOREIGN KEY (DocID) REFERENCES [doccore].[Documents] (DocID) ON DELETE CASCADE,
CONSTRAINT FK_USER_SHARED_ID FOREIGN KEY (sharedTo) REFERENCES [doccore].[User] (ID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Project'
                          AND TABLE_SCHEMA = 'doccore')

BEGIN

CREATE TABLE [doccore].[Project]
(
	projectID						int IDENTITY(1,1),
	projectName				   varchar(50)
	
CONSTRAINT PK_PROJECT_ID PRIMARY KEY CLUSTERED (projectID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'ProjectManager'
                          AND TABLE_SCHEMA = 'doccore')

BEGIN

CREATE TABLE [doccore].[ProjectManager]
(
	ManagerID						int ,
	pID				     int
	
CONSTRAINT FK_MANAGER_ID FOREIGN KEY (ManagerID) REFERENCES [doccore].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_PROJECT_ID FOREIGN KEY (pID) REFERENCES [doccore].[Project] (projectID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Members'
                          AND TABLE_SCHEMA = 'doccore')

BEGIN

CREATE TABLE [doccore].[Members]
(
	memberID						int ,
	pID				     int
	
CONSTRAINT FK_MEMBER_MANAGER_ID FOREIGN KEY (memberID) REFERENCES [doccore].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_MEMBER_PROJECT_ID FOREIGN KEY (pID) REFERENCES [doccore].[Project] (projectID)
)

END


IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'SecurityQuestion'
                          AND TABLE_SCHEMA = 'doccore')

BEGIN

CREATE TABLE [doccore].[SecurityQuestion]
(
	ID						int IDENTITY(1,1),
	Question				VARCHAR(45),
	
CONSTRAINT PK_QUESTION_ID PRIMARY KEY CLUSTERED (ID)

)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'UserSecurity'
                          AND TABLE_SCHEMA = 'doccore')

BEGIN

CREATE TABLE [doccore].[UserSecurity]
(
	UserID						int,
	QuestionID				int,
	Answer					text,
	
CONSTRAINT FK_USER_USERSECURITY FOREIGN KEY (UserID) REFERENCES [doccore].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_SECURITYQUESTION_USERSECURITY FOREIGN KEY (QuestionID) REFERENCES [doccore].[SecurityQuestion] (ID)
)

END