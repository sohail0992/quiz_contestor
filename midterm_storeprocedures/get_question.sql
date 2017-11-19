CREATE PROCEDURE get_question(
@qid int
)
AS
BEGIN
Select * from questions where question_id=@qid
END
