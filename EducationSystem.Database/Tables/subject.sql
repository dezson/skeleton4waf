CREATE TABLE [dbo].[subject]
(
	[subject_id] INT NOT NULL IDENTITY (1, 1),
	[subject_name] NVARCHAR(50) NOT NULL,
	[program_id] INT NOT NULL,
	CONSTRAINT [pk_subject] PRIMARY KEY ([subject_id]),
	CONSTRAINT [fk_subject_program] FOREIGN KEY ([program_id]) REFERENCES [dbo].[program] ([program_id])
)
