USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Gets claim payment by id
-- EXEC GetClaimPaymentById 1
-- =============================================
CREATE PROCEDURE [dbo].[GetClaimPaymentById]
(
	@ClaimPaymentId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP 1
		ClaimPaymentId, 
		ClaimId, 
		ClaimPaymentMethodId, 
		Amount, 
		PaymentDate, 
		ReferenceNumber
	FROM ClaimPayment
	WHERE ClaimPaymentId = @ClaimPaymentId;
END
GO


