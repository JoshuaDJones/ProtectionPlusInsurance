USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Creates claim status
-- =============================================
CREATE PROCEDURE CreateClaimStatus
(
	@StatusName NVARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO ClaimStatus
	(
		StatusName
	)
	VALUES
	(
		@StatusName
	);

	SELECT SCOPE_IDENTITY() AS ClaimStatusId;
END
GO
