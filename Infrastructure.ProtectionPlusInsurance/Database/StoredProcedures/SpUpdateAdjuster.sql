USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Updates a adjuster
-- EXEC UpdateAdjuster 1, 'Johnn', 'Smitthhh', 'johnn_smithh@gmail.com', '555-555-5554'
-- =============================================
CREATE PROCEDURE [dbo].[UpdateAdjuster]
(
	@AdjusterId INT,
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Email NVARCHAR(255),
	@Phone NVARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

	UPDATE Adjuster 
	SET FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		Phone = @Phone
	WHERE AdjusterId = @AdjusterId;

	SELECT @@ROWCOUNT AS RowsAffected;
END
GO


