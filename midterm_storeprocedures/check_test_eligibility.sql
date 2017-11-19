USE [midterm]
GO
/****** Object:  StoredProcedure [dbo].[check_test_eligibility]    Script Date: 11/19/2017 8:39:26 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[check_test_eligibility](
@user_id int
)
AS
BEGIN
Select top 1 * from users inner join tests on users.user_id=tests.user_id WHERE users.user_id=@user_id ORDER BY test_count  DESC
END
