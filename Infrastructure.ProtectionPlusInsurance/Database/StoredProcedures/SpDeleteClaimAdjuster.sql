USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Deletes claim adjuster
-- EXEC DeleteClaimAdjuster 1
-- =============================================
CREATE PROCEDURE [dbo].[DeleteClaimAdjuster]
(
	@ClaimAdjusterId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    DELETE FROM ClaimAdjuster
	WHERE ClaimAdjusterId = @ClaimAdjusterId;
END
GO


