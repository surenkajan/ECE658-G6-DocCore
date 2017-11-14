USE DocCore
GO

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'User'
                          AND TABLE_SCHEMA = 'DocCore')

BEGIN

CREATE TABLE [DocCore].[User]
(
	ID						int IDENTITY(1,1),
	UserName				VARCHAR(50),
	FirstName				VARCHAR(150) NOT NULL,
	LastName				VARCHAR(150),
	EmailAddress			VARCHAR(240) NOT NULL,
	ProfilePhoto    image,
CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

END



IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Permission'
                          AND TABLE_SCHEMA = 'DocCore')

BEGIN

CREATE TABLE [DocCore].[Permission]
(
	pID						int IDENTITY(1,1),
	projectRole				varchar(30)
	
CONSTRAINT PK_PERMISSION_ID PRIMARY KEY CLUSTERED (pID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Access'
                          AND TABLE_SCHEMA = 'DocCore')

BEGIN

CREATE TABLE [DocCore].[Access]
(
	aID						int,
	pID				int
	
CONSTRAINT FK_USERACCESS_ID FOREIGN KEY (aID) REFERENCES [DocCore].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_PERMISSION_ID FOREIGN KEY (pID) REFERENCES [DocCore].[Permission] (pID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Documents'
                          AND TABLE_SCHEMA = 'DocCore')

BEGIN

CREATE TABLE [DocCore].[Documents]
(
	dID						int IDENTITY(1,1),
	title				varchar(100),
  fileType              varchar(10),
  uploadedBy            int,
  uploadedTime            datetime,
  document                BLOB
	
CONSTRAINT FK_USER_ID FOREIGN KEY (uploadedBy) REFERENCES [DocCore].[User] (ID) ON DELETE CASCADE,
CONSTRAINT PK_DOCUMENT_ID PRIMARY KEY CLUSTERED (dID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Comments'
                          AND TABLE_SCHEMA = 'DocCore')

BEGIN

CREATE TABLE [DocCore].[Comments]
(
	cID						int ,
	comments				text,
  commentedBy              int,
  CommentedTime            datetime
	
CONSTRAINT FK_COMMENT_ID FOREIGN KEY (cID) REFERENCES [DocCore].[Documents] (dID) ON DELETE CASCADE,
CONSTRAINT FK_USERCOMMENTS_ID FOREIGN KEY (commentedBy) REFERENCES [DocCore].[User] (ID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'SharedWith'
                          AND TABLE_SCHEMA = 'DocCore')

BEGIN

CREATE TABLE [DocCore].[SharedWith]
(
	dID						int ,
	sharedTo			   int
	
CONSTRAINT FK_DOCUMENT_SHARED_ID FOREIGN KEY (dID) REFERENCES [DocCore].[Documents] (dID) ON DELETE CASCADE,
CONSTRAINT FK_USER_SHARED_ID FOREIGN KEY (sharedTo) REFERENCES [DocCore].[User] (ID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Project'
                          AND TABLE_SCHEMA = 'DocCore')

BEGIN

CREATE TABLE [DocCore].[Project]
(
	projectID						int IDENTITY(1,1),
	projectName				   varchar(50)
	
CONSTRAINT PK_PROJECT_ID PRIMARY KEY CLUSTERED (projectID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'ProjectManager'
                          AND TABLE_SCHEMA = 'DocCore')

BEGIN

CREATE TABLE [DocCore].[ProjectManager]
(
	ManagerID						int ,
	pID				     int
	
CONSTRAINT FK_MANAGER_ID FOREIGN KEY (ManagerID) REFERENCES [DocCore].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_PROJECT_ID FOREIGN KEY (pID) REFERENCES [DocCore].[Project] (projectID)
)

END

IF NOT EXISTS (SELECT 'X'
                   FROM   INFORMATION_SCHEMA.TABLES
                   WHERE  TABLE_NAME = 'Members'
                          AND TABLE_SCHEMA = 'DocCore')

BEGIN

CREATE TABLE [DocCore].[Members]
(
	memberID						int ,
	pID				     int
	
CONSTRAINT FK_MANAGER_ID FOREIGN KEY (memberID) REFERENCES [DocCore].[User] (ID) ON DELETE CASCADE,
CONSTRAINT FK_PROJECT_ID FOREIGN KEY (pID) REFERENCES [DocCore].[Project] (projectID)
)

END
