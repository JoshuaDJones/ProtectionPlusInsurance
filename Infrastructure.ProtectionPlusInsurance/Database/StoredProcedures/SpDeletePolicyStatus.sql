USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Deletes policy status
-- =============================================
CREATE PROCEDURE DeletePolicyStatus
(
	@PolicyStatusId INT
)
AS
BEGIN
	SET NOCOUNT ON;

    DELETE FROM PolicyStatus
	WHERE PolicyStatusId = @PolicyStatusId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO
