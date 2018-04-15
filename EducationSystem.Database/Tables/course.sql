CREATE TABLE [dbo].[course]
(
	[course_id] INT NOT NULL IDENTITY (1, 1),
	[course_code] NVARCHAR(30) NOT NULL UNIQUE,
	[subject_id] INT NOT NULL,
	[teacher_id] INT NOT NULL,
	[start_day] INT NOT NULL CHECK(start_day BETWEEN 1 AND 7),
	[start_time] TIME NOT NULL,
	[seats] INT NOT NULL CHECK(seats > 0),
	CONSTRAINT [pk_course] PRIMARY KEY ([course_id]),
	CONSTRAINT [fk_course_subject] FOREIGN KEY ([subject_id]) REFERENCES [dbo].[subject] ([subject_id]),
	CONSTRAINT [fk_course_teacher] FOREIGN KEY ([teacher_id]) REFERENCES [dbo].[teacher] ([teacher_id])
)
