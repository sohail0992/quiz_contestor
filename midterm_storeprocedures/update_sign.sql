CREATE PROCEDURE update_sign(
@question_id int,
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
UPDATE questions
     SET quetstion_option1=@option1,quetstion_option2=@option2,quetstion_option3=@option3,
	 quetstion_option4=@option4,quetstion_correct=@correct,question_pic=@pictures,quetion_text=@question_text 
	 WHERE question_id=@question_id
END