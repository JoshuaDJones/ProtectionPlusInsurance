USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:       Joshua Jones
-- Create date: 11-28-2025
-- Description:  Creates policy
-- EXEC CreatePolicy 1, 1, 1, '12345678', 200000.56, 2000.00, '2025-11-28', '2025-11-28';
-- =============================================
CREATE PROCEDURE [dbo].[CreatePolicy]
(
    @PolicyHolderId INT,
    @PolicyStatusId INT,
    @PropertyId INT,
    @PolicyNumber NVARCHAR(50),
    @CoverageAmount DECIMAL(18, 2), 
    @Deductible DECIMAL(18, 2), 
    @EffectiveDate DATE, 
    @ExpirationDate DATE
)
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO Policy 
    (
        PolicyHolderId,
        PolicyStatusId,
        PropertyId,
        PolicyNumber,
        CoverageAmount,
        Deductible,
        EffectiveDate,
        ExpirationDate
    )
    VALUES
    (
        @PolicyHolderId,
        @PolicyStatusId,
        @PropertyId,
        @PolicyNumber,
        @CoverageAmount,
        @Deductible,
        @EffectiveDate,
        @ExpirationDate
    );

    SELECT SCOPE_IDENTITY() AS PolicyId;
END
GO


