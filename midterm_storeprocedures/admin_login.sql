USE [midterm]
GO
/****** Object:  StoredProcedure [dbo].[admin_login]    Script Date: 11/19/2017 2:44:34 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[admin_login](
@admin_name nvarchar(250),
@admin_pass nvarchar(250)
)
AS
BEGIN
declare @status int
if exists(Select * from admin where admin_name=@admin_name and admin_pass=@admin_pass)
      set @status=1
else
      set @status=0
select @status
END