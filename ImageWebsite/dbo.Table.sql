CREATE TABLE [dbo].[UserData]
(
	[Id] INT NULL, 
    [Username] NCHAR(20) NULL, 
    [Email] NCHAR(50) NULL, 
    [Password] NCHAR(15) NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Password]) 
)
