USE [midterm]
GO
/****** Object:  StoredProcedure [dbo].[is_locked]    Script Date: 11/19/2017 4:36:40 PM ******/
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
Select * from users where user_cnic=@cnic and user_pass=@pass
END
