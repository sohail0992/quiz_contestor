USE [midterm]
GO
/****** Object:  StoredProcedure [dbo].[add_sign]    Script Date: 11/19/2017 12:16:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[add_sign](
@option1 nchar(10),
@option2 nchar(10),
@option3 nchar(10),
@option4 nchar(10),
@correct nchar(10),
@pictures image,
@question_text nchar(300)
)
AS
BEGIN
INSERT INTO questions(quetstion_option1,quetstion_option2,quetstion_option3,quetstion_option4,quetstion_correct,question_pic,quetion_text ) 
VALUES (@option1,@option2,@option3,@option4,@correct,@pictures,@question_text);
END