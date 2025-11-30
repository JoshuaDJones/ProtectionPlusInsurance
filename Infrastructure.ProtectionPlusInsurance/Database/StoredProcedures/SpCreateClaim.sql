USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Creates a claim
-- EXEC CreateClaim 1, 1, '651651651', null, null
-- =============================================
CREATE PROCEDURE [dbo].[CreateClaim]
(
	@IncidentId INT,
	@ClaimStatusId INT,
	@ClaimNumber NVARCHAR(50),
	@EstimatedLossAmount DECIMAL(18, 2) = NULL,
	@ApprovedPayoutAmount DECIMAL(18, 2) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

	INSERT INTO Claim
	(
		IncidentId, 
		ClaimStatusId, 
		ClaimNumber, 
		EstimatedLossAmount, 
		ApprovedPayoutAmount
	)
	VALUES
	(
		@IncidentId,
		@ClaimStatusId,
		@ClaimNumber,
		@EstimatedLossAmount,
		@ApprovedPayoutAmount
	);

	SELECT SCOPE_IDENTITY() AS ClaimId;
END
GO


