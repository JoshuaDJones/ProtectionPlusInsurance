USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Gets claim payments
-- EXEC GetClaimPayments 1, 10
-- =============================================
CREATE PROCEDURE [dbo].[GetClaimPayments]
	@PageNumber INT = 1,
	@PageSize INT = 10
AS
BEGIN
	SET NOCOUNT ON;

    SELECT ClaimPaymentId, 
		ClaimId, 
		ClaimPaymentMethodId, 
		Amount, 
		PaymentDate, 
		ReferenceNumber
	FROM ClaimPayment
	ORDER BY ClaimPaymentId
	OFFSET(@PageNumber - 1) * @PageSize ROWS
	FETCH NEXT @PageSize ROWS ONLY;
END
GO


