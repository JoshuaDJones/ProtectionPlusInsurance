USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Deletes a incident
-- EXEC DeleteIncident 1
-- =============================================
CREATE PROCEDURE [dbo].[DeleteIncident]
(
	@IncidentId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    DELETE FROM Incident
	WHERE IncidentId = @IncidentId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO


