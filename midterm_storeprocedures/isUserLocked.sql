USE [midterm]
GO
/****** Object:  StoredProcedure [dbo].[is_locked]    Script Date: 11/19/2017 4:17:51 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[is_locked](
@cnic bigint,
@pass nchar(250)
)
AS
BEGIN
declare @is_lock int
if exists(Select * from users where user_cnic=@cnic and user_pass=@pass)
      set @is_lock=1
else
      set @is_lock=0
select @is_lock
END
