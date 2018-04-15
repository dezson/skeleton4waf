CREATE TABLE [dbo].[course_record]
(
	[course_record_id] INT NOT NULL IDENTITY (1, 1),
	[course_id] INT NOT NULL,
	[student_id] INT NOT NULL,
	[apply_time] DATETIME NULL DEFAULT (getdate()),
	[grade] INT NULL,
	CONSTRAINT [pk_course_record] PRIMARY KEY ([course_record_id]),
	CONSTRAINT [fk_course_record_student] FOREIGN KEY ([student_id]) REFERENCES [dbo].[student] ([student_id]),
	CONSTRAINT [fk_course_record_course] FOREIGN KEY ([course_id]) REFERENCES [dbo].[course] ([course_id])
)
