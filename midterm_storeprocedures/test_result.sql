CREATE PROCEDURE test_result(
@user_id int,
@test_count int,
@test_status varchar(10),
@test_marks int

)
AS
BEGIN
INSERT INTO tests (user_id,test_count,test_status,test_marks) VALUES (@user_id,@test_count,@test_status,@test_marks);
END