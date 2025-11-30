USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Gets an incident by id
-- EXEC GetIncidentById 1
-- =============================================
CREATE PROCEDURE [dbo].[GetIncidentById]
(
	@IncidentId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP 1
		IncidentId, 
		PolicyId, 
		IncidentTypeId, 
		DateOfIncident, 
		Description, 
		ReportedDate
	FROM Incident
	WHERE IncidentId = @IncidentId;
END
GO


