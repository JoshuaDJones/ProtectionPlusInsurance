USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Gets adjuster by id
-- EXEC GetAdjusterById 1
-- =============================================
CREATE PROCEDURE [dbo].[GetAdjusterById]
(
	@AdjusterId INT
)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TOP 1
		AdjusterId, 
		FirstName, 
		LastName, 
		Email, 
		Phone
	FROM Adjuster
	WHERE AdjusterId = @AdjusterId;
END
GO


