USE [ProtectionPlusInsurance]
GO 

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Creates policy status
-- =============================================
CREATE PROCEDURE CreatePolicyStatus
(
	@StatusName NVARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

    INSERT INTO PolicyStatus
	(
		StatusName
	)
	VALUES
	(
		@StatusName
	)
END
GO
