USE [midterm]
GO
/****** Object:  StoredProcedure [dbo].[create_account]    Script Date: 11/18/2017 11:09:24 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[create_account](
@cnic bigint,
@email varchar(300),
@pass varchar(250),
@islocked bit
)
AS
BEGIN
INSERT INTO users (user_cnic,user_email,user_pass,user_isLocked) VALUES (@cnic,@email,@pass,@islocked);
END