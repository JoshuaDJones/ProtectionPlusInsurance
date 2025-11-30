USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Creates adjuster
-- EXEC CreateAdjuster 'John', 'Smith', 'john_smith@gmail.com', '570-980-6209'
-- =============================================
CREATE PROCEDURE [dbo].[CreateAdjuster]
(
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Email NVARCHAR(255),
	@Phone NVARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Adjuster
	(
		FirstName, 
		LastName, 
		Email, 
		Phone
	)
	VALUES
	(
		@FirstName,
		@LastName,
		@Email,
		@Phone
	)
END
GO


