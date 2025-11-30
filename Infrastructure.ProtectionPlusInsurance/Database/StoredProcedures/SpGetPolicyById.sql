USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Gets a policy by id
-- EXEC GetPolicyById 1
-- =============================================
CREATE PROCEDURE [dbo].[GetPolicyById]
(
	@PolicyId INT
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
	WHERE PolicyId = @PolicyId
END
GO

