USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Get policies
-- EXEC GetPolicies 1, 10
-- =============================================
CREATE PROCEDURE [dbo].[GetPolicies]
(
	@PageNumber INT = 1,
	@PageSize INT = 10
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT PolicyId, 
		PolicyHolderId, 
		PolicyStatusId, 
		PropertyId, 
		PolicyNumber, 
		CoverageAmount, 
		Deductible, 
		EffectiveDate, 
		ExpirationDate
	FROM Policy
	ORDER BY PolicyId
	OFFSET(@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
GO


