CREATE TABLE [dbo].[Table]
(
	[Login] VARCHAR(50) NOT NULL , 
    [Fname] VARCHAR(50) NOT NULL, 
    [LName] VARCHAR(50) NOT NULL, 
    [Password] VARCHAR(50) NOT NULL, 
    CONSTRAINT [PK_Table] PRIMARY KEY ([Login])
)
