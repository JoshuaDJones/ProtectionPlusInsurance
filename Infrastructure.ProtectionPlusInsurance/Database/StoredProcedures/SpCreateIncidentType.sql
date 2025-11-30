USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Creates a incident type
-- =============================================
CREATE PROCEDURE CreateIncidentType
(
	@IncidentName NVARCHAR(100)
)
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO IncidentType
	(
		IncidentName
	)
	VALUES
	(
		@IncidentName
	);

	SELECT SCOPE_IDENTITY() AS IncidentTypeId;
END
GO
