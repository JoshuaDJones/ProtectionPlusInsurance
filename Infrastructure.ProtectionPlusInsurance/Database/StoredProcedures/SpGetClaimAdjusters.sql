USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Gets claim adjusters
-- EXEC GetClaimsAdjusters 1, 10
-- =============================================
CREATE PROCEDURE [dbo].[GetClaimAdjusters]
(
	@PageNumber INT = 1,
	@PageSize INT = 10
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT ClaimAdjusterId, 
		ClaimId, 
		AdjusterId, 
		AssignedDate
	FROM ClaimAdjuster
	ORDER BY ClaimAdjusterId
	OFFSET(@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
GO


