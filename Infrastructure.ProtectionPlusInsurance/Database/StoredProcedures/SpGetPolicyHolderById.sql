USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Get policy holder by id
-- EXEC GetPolicyHolderById 1
-- =============================================
CREATE PROCEDURE [dbo].[GetPolicyHolderById]
(
	@PolicyHolderId INT
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
		PolicyHolderId, 
		FirstName, 
		LastName, 
		Email, 
		Phone, 
		CreatedDate
	FROM PolicyHolder
	WHERE PolicyHolderId = @PolicyHolderId;
END
GO


