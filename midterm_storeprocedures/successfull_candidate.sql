USE [midterm]
GO
/****** Object:  StoredProcedure [dbo].[successfull_candidate]    Script Date: 11/20/2017 1:46:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[successfull_candidate](
@status nvarchar(10)
)
AS
BEGIN
Select * from users inner join tests on users.user_id=tests.user_id WHERE test_status=@status ORDER BY test_count  DESC
END
