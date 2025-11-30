USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Delete property
-- EXEC DeleteProperty 2
-- =============================================
CREATE PROCEDURE [dbo].[DeleteProperty]
(
	@PropertyId INT
)	
AS
BEGIN
	SET NOCOUNT ON;

    DELETE FROM Property
	WHERE PropertyId = @PropertyId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO


