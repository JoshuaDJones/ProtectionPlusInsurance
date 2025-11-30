USE [ProtectionPlusInsurance]
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		Joshua Jones
-- Create date: 11-28-2025
-- Description:	Updates a property
-- EXEC UpdateProperty 1, 1, '120 Patriot Cir', 'Mountain Taim', 'TX', '18702', 2, 1999
-- =============================================
CREATE PROCEDURE [dbo].[UpdateProperty]
(
	@PropertyId INT,
	@PolicyHolderId INT,
	@Address NVARCHAR(255),
	@City NVARCHAR(100),
	@State NVARCHAR(50),
	@Zip NVARCHAR(20),
	@PropertyTypeId INT,
	@YearBuilt INT = NULL
)
AS
BEGIN
	SET NOCOUNT ON;

    UPDATE Property
	SET
		PolicyHolderId = @PolicyHolderId,
		Address = @Address,
		City = @City,
		State = @State,
		Zip = @Zip,
		PropertyTypeId = @PropertyTypeId,
		YearBuilt = @YearBuilt
	WHERE PropertyId = @PropertyId;
END
GO


