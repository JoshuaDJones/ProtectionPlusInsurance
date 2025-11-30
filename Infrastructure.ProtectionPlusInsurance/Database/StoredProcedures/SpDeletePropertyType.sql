USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Deletes a property type
-- =============================================
CREATE PROCEDURE DeletePropertyType
(
	@PropertyTypeId INT
)
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM PropertyType
	WHERE PropertyTypeId = @PropertyTypeId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO
