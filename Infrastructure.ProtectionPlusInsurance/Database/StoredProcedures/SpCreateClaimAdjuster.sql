USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Create claim adjuster
-- EXEC CreateClaimAdjuster 1, 1
-- =============================================
CREATE PROCEDURE [dbo].[CreateClaimAdjuster]
(
	@ClaimId INT,
	@AdjusterId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO ClaimAdjuster
	(
		ClaimId,
		AdjusterId
	)
	VALUES
	(
		@ClaimId,
		@AdjusterId
	)
END
GO


