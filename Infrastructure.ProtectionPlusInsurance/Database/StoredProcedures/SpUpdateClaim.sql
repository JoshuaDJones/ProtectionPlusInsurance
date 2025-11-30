USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Updates a claim
-- EXEC UpdateClaim 1, 1, 1, 1000.00, 1000.00
-- =============================================
CREATE PROCEDURE [dbo].[UpdateClaim]
(
	@ClaimId INT,
	@IncidentId INT,
	@ClaimStatusId INT,
	@ClaimNumber NVARCHAR(50),
	@EstimatedLossAmount DECIMAL(18, 2) = NULL,
	@ApprovedPayoutAmount DECIMAL(18, 2) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Claim
	SET IncidentId = @IncidentId,
		ClaimStatusId = @ClaimStatusId,
		ClaimNumber = @ClaimNumber,
		EstimatedLossAmount = @EstimatedLossAmount,
		ApprovedPayoutAmount = @ApprovedPayoutAmount,
		LastUpdated = GETDATE()
	WHERE ClaimId = @ClaimId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO


