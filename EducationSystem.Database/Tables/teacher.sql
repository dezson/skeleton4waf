CREATE TABLE [dbo].[teacher]
(
	[teacher_id] INT NOT NULL IDENTITY (1, 1),
	[teacher_name] NVARCHAR(50) NOT NULL,
	[password] NVARCHAR(128) NOT NULL
	CONSTRAINT [pk_teacher] PRIMARY KEY ([teacher_id])
)
