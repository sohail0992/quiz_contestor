CREATE PROCEDURE search_user_by_cnic(
@cnic bigint
)
AS
BEGIN
SELECT * FROM users WHERE user_cnic=@cnic;
END