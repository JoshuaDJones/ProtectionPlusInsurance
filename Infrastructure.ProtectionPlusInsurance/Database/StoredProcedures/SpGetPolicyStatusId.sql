USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Gets policy status by id
-- =============================================
CREATE PROCEDURE GetPolicyStatusById
(
	@PolicyStatusId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    SELECT TOP 1
		PolicyStatusId,
		StatusName
	FROM PolicyStatus
	WHERE PolicyStatusId = @PolicyStatusId;
END
GO
