USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Creates a incident
-- EXEC CreateIncident 1, 17, '2025-11-28', 'There was a burglary', '2025-11-28'
-- =============================================
CREATE PROCEDURE [dbo].[CreateIncident]
(
	@PolicyId INT,
	@IncidentTypeId INT,
	@DateOfIncident DATE,
	@Description NVARCHAR(max) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO Incident
	(
		PolicyId,
		IncidentTypeId,
		DateOfIncident,
		Description
	)
	VALUES
	(
		@PolicyId,
		@IncidentTypeId,
		@DateOfIncident,
		@Description
	)
END
GO


