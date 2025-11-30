USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Updates a incident
-- EXEC UpdateIncident 1, 1, 11, '2025-11-28', 'There was a bursted pipe', '2025-11-28'
-- =============================================
CREATE PROCEDURE [dbo].[UpdateIncident]
(
	@IncidentId INT,
	@PolicyId INT,
	@IncidentTypeId INT,
	@DateOfIncident DATE,
	@Description NVARCHAR(max)
)
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE Incident 
	SET PolicyId = @PolicyId,
		IncidentTypeId = @IncidentTypeId,
		DateOfIncident = @DateOfIncident,
		Description = @Description
	WHERE IncidentId = @IncidentId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO


