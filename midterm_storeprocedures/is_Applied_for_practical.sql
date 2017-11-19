CREATE PROCEDURE is_Applied_for_practical(
@user_id int,
@isApplied bit
)
AS
BEGIN
UPDATE users 
  SET user_isAppliedForPractical=@isApplied
  WHERE user_id=@user_id;
END