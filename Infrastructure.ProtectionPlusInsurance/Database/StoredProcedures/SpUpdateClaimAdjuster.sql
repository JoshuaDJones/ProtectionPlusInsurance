USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11/28/2025
-- Description:	Updates claim adjuster
-- EXEC UpdateClaimAdjuster 1,1,1,'2024-05-05'
-- =============================================
CREATE PROCEDURE [dbo].[UpdateClaimAdjuster]
	@ClaimAdjusterId INT,
	@ClaimId INT,
	@AdjusterId INT,
	@AssignedDate DATETIME
AS
BEGIN
	SET NOCOUNT ON;
	
	UPDATE ClaimAdjuster
	SET ClaimId = @ClaimId,
		AdjusterId = @AdjusterId,
		AssignedDate = @AssignedDate
	WHERE ClaimAdjusterId = @ClaimAdjusterId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO


