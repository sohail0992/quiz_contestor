USE [midterm]
GO
/****** Object:  StoredProcedure [dbo].[login]    Script Date: 11/18/2017 10:37:15 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[login](
@cnic bigint,
@pass nchar(250)
)
AS
BEGIN
declare @status int
if exists(Select * from users where user_cnic=@cnic and user_pass=@pass)
      set @status=1 
else
      set @status=0
select @status
END
