USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Gets claim status by id
-- =============================================
CREATE PROCEDURE GetClaimStatusById
(
	@ClaimStatusId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP 1
		ClaimStatusId,
		StatusName
	FROM ClaimStatus
	WHERE ClaimStatusId = @ClaimStatusId;
END
GO
