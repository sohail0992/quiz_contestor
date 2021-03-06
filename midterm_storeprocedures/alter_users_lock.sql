USE [midterm]
GO
/****** Object:  StoredProcedure [dbo].[alter_users_lock]    Script Date: 11/19/2017 1:57:10 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[alter_users_lock]
(
@cnic bigint,
@pass nvarchar(250),
@newpass nvarchar(250),
@islocked bit
)
AS
BEGIN
UPDATE users 
  SET user_cnic=@cnic,user_pass=@newpass,user_isLocked=@islocked
  WHERE user_cnic=@cnic and user_pass=@pass;
END