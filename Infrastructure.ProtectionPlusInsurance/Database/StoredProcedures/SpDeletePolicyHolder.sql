USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Deletes policy holder by id
-- EXEC DeletePolicyHolder 2
-- =============================================
CREATE PROCEDURE [dbo].[DeletePolicyHolder] 
(
	@PolicyHolderId INT
)
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM PolicyHolder
	WHERE PolicyHolderId = @PolicyHolderId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO


