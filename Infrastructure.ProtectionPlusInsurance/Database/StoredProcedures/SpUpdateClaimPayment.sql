USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Updates claim payment
-- EXEC UpdateClaimPayment 1, 1, 2, 1000.00, '2025-11-28', '4569872'
-- =============================================
CREATE PROCEDURE [dbo].[UpdateClaimPayment]
(
	@ClaimPaymentId INT,
	@ClaimId INT,
	@ClaimPaymentMethodId INT,
	@Amount DECIMAL(18, 2),
	@PaymentDate DATE,
	@ReferenceNumber NVARCHAR(100) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE ClaimPayment
	SET ClaimId = @ClaimId,
		ClaimPaymentMethodId = @ClaimPaymentMethodId,
		Amount = @Amount,
		PaymentDate = @PaymentDate,
		ReferenceNumber = @ReferenceNumber;
END
GO


