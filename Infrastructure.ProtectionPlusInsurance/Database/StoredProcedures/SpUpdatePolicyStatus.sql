USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-29-2025
-- Description:	Updates a policy status
-- =============================================
CREATE PROCEDURE UpdatePolicyStatus
(
	@PolicyStatusId INT,
	@StatusName NVARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE PolicyStatus
	SET StatusName = @StatusName
	WHERE PolicyStatusId = @PolicyStatusId;
END
GO
