USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Creates a new policy holder
-- EXEC CreatePolicyHolder 'John', 'Doe', 'john.doe@example.com', '555-123-4567';
-- =============================================
CREATE PROCEDURE [dbo].[CreatePolicyHolder]
(
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Email NVARCHAR(255),
	@Phone NVARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO PolicyHolder 
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
	);
END
GO


