CREATE TABLE [dbo].[program]
(
	[program_id] INT NOT NULL IDENTITY (1, 1),
	[program_name] NVARCHAR(100) NOT NULL,
	CONSTRAINT [pk_program] PRIMARY KEY ([program_id])
)
