USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Updates a property type
-- =============================================
CREATE PROCEDURE UpdatePropertyType
(
	@PropertyTypeId INT,
	@TypeName VARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE PropertyType
	SET TypeName = @TypeName
	WHERE PropertyTypeId = @PropertyTypeId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO
