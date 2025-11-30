USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Gets list of properties
-- EXEC GetProperties 1, 10
-- =============================================
CREATE PROCEDURE [dbo].[GetProperties]
(
	@PageNumber INT = 1,
	@PageSize INT = 10
)
AS
BEGIN	
	SET NOCOUNT ON;

	SELECT PropertyId, 
		PolicyHolderId, 
		Address, 
		City, 
		State, 
		Zip, 
		PropertyTypeId, 
		YearBuilt
	FROM Property
	ORDER BY PropertyId
	OFFSET(@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY;
END
GO


