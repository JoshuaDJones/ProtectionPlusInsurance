USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Creates a property
-- EXEC CreateProperty 1, '128 Patriot Cir', 'Mountain Top', 'PA', '18707', 2, 1999
-- =============================================
CREATE PROCEDURE [dbo].[CreateProperty]
(
	@PolicyHolderId INT,
	@Address NVARCHAR(255),
	@City NVARCHAR(100),
	@State NVARCHAR(50),
	@Zip NVARCHAR(20),
	@PropertyTypeId INT,
	@YearBuilt INT = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Property
	(
		PolicyHolderId,
		Address,
		City,
		State,
		Zip,
		PropertyTypeId,
		YearBuilt
	) 
	VALUES
	(
		@PolicyHolderId,
		@Address,
		@City,
		@State,
		@Zip,
		@PropertyTypeId,
		@YearBuilt
	);

	SELECT SCOPE_IDENTITY() AS PropertId;
END
GO


