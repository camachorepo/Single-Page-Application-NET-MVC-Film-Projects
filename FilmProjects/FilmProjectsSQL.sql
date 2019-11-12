CREATE TABLE [dbo].[User](
[UserId] INT NOT NULL,
[FirstName] NVARCHAR(50) NOT NULL, 
[LastName] NVARCHAR(50) NOT NULL
CONSTRAINT [PK_dbo.User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

CREATE TABLE [dbo].[Project](
[ProjectId] INT NOT NULL, 
[StartDate] DATETIME NOT NULL, 
[EndDate] DATETIME NOT NULL, 
[Credits] INT NOT NULL, 
CONSTRAINT [PK_dbo.Project]PRIMARY KEY CLUSTERED ([ProjectId] ASC)

);

CREATE TABLE [dbo].[UserProject](
[UserProjectId] INT IDENTITY (1,1) NOT NULL,
[IsActive] BIT NOT NULL, 
[AssignedDate] DATETIME NOT NULL,
[UserId] INT NOT NULL, 
[ProjectId] INT NOT NULL,
CONSTRAINT [FK_dbo.FilmProjects_dbo.Project_ProjectId] FOREIGN KEY ([ProjectId]) REFERENCES [dbo].[Project] ([ProjectId]) ON DELETE CASCADE,
CONSTRAINT [FK_dbo.FilmProjects_dbo.User_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId]) ON DELETE CASCADE, 
CONSTRAINT [PK_dbo.UserProject]PRIMARY KEY CLUSTERED ([UserProjectId] ASC)
);

