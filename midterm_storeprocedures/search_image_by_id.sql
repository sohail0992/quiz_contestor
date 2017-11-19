create procedure search_image_by_id(
@id int
)
AS
Begin
select * from questions where question_id=@id;
End