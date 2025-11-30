USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Gets a property type by id
-- =============================================
CREATE PROCEDURE GetPropertyTypeById
(
	@PropertyTypeId INT
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
		PropertyTypeId,
		TypeName
	FROM PropertyType
	WHERE PropertyTypeId = @PropertyTypeId
END
GO
