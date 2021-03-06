USE [midterm]
GO
/****** Object:  StoredProcedure [dbo].[alter_users_lock]    Script Date: 11/18/2017 11:55:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[alter_users_lock]
(
@cnic bigint,
@pass varchar(250),
@islocked bit
)
AS
BEGIN
UPDATE users 
  SET user_cnic=@cnic,user_pass=@pass,user_isLocked=@islocked
  WHERE user_cnic=@cnic and user_pass=@pass;
END