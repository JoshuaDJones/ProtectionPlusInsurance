USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Gets list of policy holders
-- EXEC GetPolicyHolders 1, 10
-- =============================================
CREATE PROCEDURE [dbo].[GetPolicyHolders]
(
	@PageNumber INT = 1,
	@PageSize INT = 10
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT 
		PolicyHolderId, 
		FirstName, 
		LastName, 
		Email, 
		Phone, 
		CreatedDate
	FROM PolicyHolder
	ORDER BY LastName, FirstName
	OFFSET(@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY;
END
GO


