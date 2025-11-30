USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2028
-- Description:	Delete a claim
-- EXEC DeleteClaim 1
-- =============================================
CREATE PROCEDURE [dbo].[DeleteClaim]
(
	@ClaimId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    DELETE FROM Claim
	WHERE ClaimId = @ClaimId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO


