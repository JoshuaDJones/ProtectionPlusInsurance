USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Updates a claim status
-- =============================================
CREATE PROCEDURE UpdateClaimStatus
(
	@ClaimStatusId INT,
	@StatusName NVARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE ClaimStatus
	SET StatusName = @StatusName
	WHERE ClaimStatusId = @ClaimStatusId;
END
GO
