USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Deletes a policy
-- EXEC DeletePolicy 5
-- =============================================
CREATE PROCEDURE [dbo].[DeletePolicy]
(
	@PolicyId INT
)
AS
BEGIN
	SET NOCOUNT ON;

	DELETE FROM Policy 
	WHERE PolicyId = @PolicyId;
END
GO


