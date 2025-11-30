USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Deletes incident type
-- =============================================
CREATE PROCEDURE DeleteIncidentType
(
	@IncidentTypeId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    DELETE FROM IncidentType
	WHERE IncidentTypeId = @IncidentTypeId;
END
GO
