USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Updates policy holder
-- EXEC UpdatePolicyHolder 1, 'Josh', 'Jones', 'jdj92993@gmail.com', '570-902-5045'
-- =============================================
CREATE PROCEDURE [dbo].[UpdatePolicyHolder]
(
	@PolicyHolderId INT,
	@FirstName NVARCHAR(100),
	@LastName NVARCHAR(100),
	@Email NVARCHAR(255),
	@Phone NVARCHAR(50)
)
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE PolicyHolder
	SET FirstName = @FirstName,
		LastName = @LastName,
		Email = @Email,
		Phone = @Phone
	WHERE PolicyHolderId = @PolicyHolderId;
END
GO


