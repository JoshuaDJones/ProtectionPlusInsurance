USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Gets a claim by id
-- EXEC GetClaimById 1
-- =============================================
CREATE PROCEDURE [dbo].[GetClaimById]
(
	@ClaimId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP 1
		ClaimId,
		IncidentId,
		ClaimStatusId,
		EstimatedLossAmount,
		ApprovedPayoutAmount,
		CreatedDate,
		LastUpdated
	FROM Claim
	WHERE ClaimId = @ClaimId
END
GO


