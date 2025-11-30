USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Gets Incidents
-- EXEC GetIncidents 1, 10
-- =============================================
CREATE PROCEDURE [dbo].[GetIncidents]
(
	@PageNumber INT = 1,
	@PageSize INT = 10
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT IncidentId, 
		PolicyId, 
		IncidentTypeId, 
		DateOfIncident, 
		Description, 
		ReportedDate
	FROM Incident
	ORDER BY IncidentId
	OFFSET(@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
GO


