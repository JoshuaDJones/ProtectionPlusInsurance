USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Gets claim adjuster by id
-- EXEC GetClaimAdjusterById 1
-- =============================================
CREATE PROCEDURE [dbo].[GetClaimAdjusterById]
(
	@ClaimAdjusterId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP 1
		ClaimAdjusterId, 
		ClaimId, 
		AdjusterId, 
		AssignedDate
	FROM ClaimAdjuster
	WHERE ClaimAdjusterId = @ClaimAdjusterId
END
GO


