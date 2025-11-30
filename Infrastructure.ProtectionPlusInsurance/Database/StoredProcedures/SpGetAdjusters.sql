USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Gets adjusters
-- EXEC GetAdjusters 1, 10
-- =============================================
CREATE PROCEDURE [dbo].[GetAdjusters]
(
	@PageNumber INT = 1,
	@PageSize INT = 10
)
AS
BEGIN
	SET NOCOUNT ON;
	
	SELECT AdjusterId, 
		FirstName, 
		LastName, 
		Email, 
		Phone
	FROM Adjuster
	ORDER BY AdjusterId
	OFFSET(@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY
END
GO


