CREATE PROCEDURE verify_old_pass(
@pass nvarchar(250)
)
AS
BEGIN
declare @status int
if exists(Select * from users where user_pass=@pass)
      set @status=1
else
      set @status=0
select @status
END
