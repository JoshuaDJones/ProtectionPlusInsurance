USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Gets incident type by id
-- =============================================
CREATE PROCEDURE GetIncidentTypeById
(
	@IncidentTypeId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP 1
		IncidentTypeId,
		IncidentName
	FROM IncidentType
	WHERE IncidentTypeId = @IncidentTypeId;
END
GO
