USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Deletes an adjuster
-- EXEC DeleteAdjuster 2
-- =============================================
CREATE PROCEDURE [dbo].[DeleteAdjuster]
(
	@AdjusterId INT
)
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM Adjuster
	WHERE AdjusterId = @AdjusterId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO


