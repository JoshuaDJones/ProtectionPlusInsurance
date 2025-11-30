USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Get claims
-- EXEC GetClaims 1, 10
-- =============================================
CREATE PROCEDURE [dbo].[GetClaims] 
(
	@PageNumber INT = 1,
	@PageSize INT = 10
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ClaimId, 
		IncidentId, 
		ClaimStatusId, 
		ClaimNumber, 
		EstimatedLossAmount, 
		ApprovedPayoutAmount, 
		CreatedDate, 
		LastUpdated
	FROM Claim
	ORDER BY ClaimId
	OFFSET(@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
GO


