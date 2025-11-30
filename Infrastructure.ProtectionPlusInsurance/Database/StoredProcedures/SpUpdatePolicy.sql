USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Updates a policy
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePolicy]
(
	@PolicyId INT,
    @PolicyHolderId INT,
    @PolicyStatusId INT,
    @PropertyId INT,
    @PolicyNumber NVARCHAR(50),
    @CoverageAmount DECIMAL(18, 2), 
    @Deductible DECIMAL(18, 2), 
    @EffectiveDate DATE, 
    @ExpirationDate DATE)
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE Policy 
	SET PolicyHolderId = @PolicyHolderId,
		PolicyStatusId = @PolicyStatusId, 
		PropertyId = @PropertyId,
		PolicyNumber = @PolicyNumber,
		CoverageAmount = @CoverageAmount,
		Deductible = @Deductible,
		EffectiveDate = @EffectiveDate,
		ExpirationDate = @ExpirationDate
	WHERE PolicyId = @PolicyId
END
GO


