USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Deletes claim payment
-- EXEC DeleteClaimPayment 1
-- =============================================
CREATE PROCEDURE [dbo].[DeleteClaimPayment]
(
	@ClaimPaymentId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    DELETE FROM ClaimPayment
	WHERE ClaimPaymentId = @ClaimPaymentId;
END
GO


