USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Updates incident type
-- =============================================
CREATE PROCEDURE UpdateIncidentType
(
	@IncidentTypeId INT,
	@IncidentName NVARCHAR(100)
)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE IncidentType
	Set IncidentName = @IncidentName
	WHERE IncidentTypeId = @IncidentTypeId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO
