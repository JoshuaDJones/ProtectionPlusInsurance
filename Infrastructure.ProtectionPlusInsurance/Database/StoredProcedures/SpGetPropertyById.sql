USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Get property by id
-- EXEC GetPropertyById 1
-- =============================================
CREATE PROCEDURE [dbo].[GetPropertyById]
(
	@PropertyId INT
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
	PropertyId, 
	PolicyHolderId, 
	Address, 
	City, 
	State, 
	Zip, 
	PropertyTypeId, 
	YearBuilt
	FROM Property
	WHERE PropertyId = @PropertyId;
END
GO


