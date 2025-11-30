USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Gets policy statuses
-- =============================================
CREATE PROCEDURE GetPolicyStatuses
(
	@PageNumber INT = 1,
	@PageSize INT = 10
)
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT PolicyStatusId,
		StatusName
	FROM PolicyStatus
	ORDER BY PolicyStatusId
	OFFSET(@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY;
END
GO
