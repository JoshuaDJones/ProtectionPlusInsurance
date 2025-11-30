USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Gets claim statuses
-- =============================================
CREATE PROCEDURE GetClaimStatuses
(
	@PageNumber INT = 1,
	@PageSize INT = 10
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT ClaimStatusId,
		StatusName
	FROM ClaimStatus
	ORDER BY ClaimStatusId
	OFFSET(@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY;
END
GO
