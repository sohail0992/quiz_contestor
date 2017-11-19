CREATE PROCEDURE alter_users
(
@cnic bigint,
@email varchar(300),
@pass varchar(250),
@islocked bit
)
AS
BEGIN
UPDATE users 
  SET user_cnic=@cnic,user_email=@email,user_pass=@pass,user_isLocked=@islocked
  WHERE user_cnic=@cnic and user_pass=@pass;
END