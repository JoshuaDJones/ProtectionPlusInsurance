USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2055
-- Description:	Creates a property type
-- =============================================
CREATE PROCEDURE [dbo].[CreatePropertyType]
(
	@TypeName NVARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO PropertyType
	(
		TypeName
	)	
	VALUES
	(
		@TypeName
	);

	SELECT SCOPE_IDENTITY() AS PropertyTypeId;
END
GO


