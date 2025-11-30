USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Deletes claim status
-- =============================================
CREATE PROCEDURE DeleteClaimStatus
(
	@ClaimStatusId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    DELETE FROM ClaimStatus
	WHERE ClaimStatusId = @ClaimStatusId;
END
GO
