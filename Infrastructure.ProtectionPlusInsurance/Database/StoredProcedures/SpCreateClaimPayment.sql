USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Creates a claim payment
-- EXEC CreateClaimPayment 1, 2, 1000.00, '2025-11-28', '4569872'
-- =============================================
CREATE PROCEDURE [dbo].[CreateClaimPayment]
(
	@ClaimId INT,
	@ClaimPaymentMethodId INT,
	@Amount DECIMAL(18, 2),
	@PaymentDate DATE,
	@ReferenceNumber NVARCHAR(100) = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO ClaimPayment
	(
		ClaimId,
		ClaimPaymentMethodId,
		Amount, 
		PaymentDate,
		ReferenceNumber
	)
	VALUES
	(
		@ClaimId,
		@ClaimPaymentMethodId,
		@Amount,
		@PaymentDate,
		@ReferenceNumber
	);

	SELECT SCOPE_IDENTITY() AS ClaimPaymentId;
END
GO


