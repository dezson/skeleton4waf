CREATE TABLE [dbo].[student]
(
	[student_id] INT NOT NULL IDENTITY (1, 1),
	[student_name] NVARCHAR(50) NOT NULL,
	[password] NVARCHAR(128) NOT NULL
	CONSTRAINT [pk_student] PRIMARY KEY ([student_id])
)
