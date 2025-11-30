USE master;
GO

-- ============================================================
-- CREATE DATABASE 
-- ============================================================
IF DB_ID('ProtectionPlusInsurance') IS NULL
BEGIN
    PRINT 'Creating database ProtectionPlusInsurance...';
    CREATE DATABASE ProtectionPlusInsurance;
END
ELSE
BEGIN
    PRINT 'Database already exists.';
	RETURN; 
END
GO

USE ProtectionPlusInsurance;
GO

-- ============================================================
-- CREATE TABLES
-- ============================================================

CREATE TABLE PolicyHolder (
	PolicyHolderId INT Identity(1,1) PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	Email NVARCHAR(255) NOT NULL,
	Phone NVARCHAR(50) NOT NULL,
	CreatedDate DATETIME NOT NULL DEFAULT GETDATE()
);

CREATE TABLE PropertyType (
	PropertyTypeId INT IDENTITY(1,1) PRIMARY KEY,
	TypeName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Property (
	PropertyId INT IDENTITY(1,1) PRIMARY KEY,
	PolicyHolderId INT NOT NULL,
	Address NVARCHAR(255) NOT NULL,
	City NVARCHAR(100) NOT NULL,
	State NVARCHAR(50) NOT NULL,
	Zip NVARCHAR(20) NOT NULL,
	PropertyTypeId INT NOT NULL,
	YearBuilt INT NULL,

	CONSTRAINT FK_Property_PolicyHolder
		FOREIGN KEY (PolicyHolderId)
		REFERENCES PolicyHolder(PolicyHolderId),

	CONSTRAINT FK_Property_PropertyType
		FOREIGN KEY (PropertyTypeId)
		REFERENCES PropertyType(PropertyTypeId)
);

CREATE TABLE PolicyStatus (
	PolicyStatusId INT IDENTITY (1,1) PRIMARY KEY,
	StatusName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Policy (
	PolicyId INT IDENTITY(1,1) PRIMARY KEY,
	PolicyHolderId INT NOT NULL,
	PolicyStatusId INT NOT NULL,
	PropertyId INT NOT NULL,
	PolicyNumber NVARCHAR(50) NOT NULL UNIQUE,
	CoverageAmount DECIMAL(18, 2) NOT NULL,
	Deductible DECIMAL(18, 2) NOT NULL,
	EffectiveDate DATE NOT NULL,
	ExpirationDate DATE NOT NULL,

	CONSTRAINT FK_Policy_PolicyHolder
		FOREIGN KEY (PolicyHolderId)
		REFERENCES PolicyHolder(PolicyHolderId),

	CONSTRAINT FK_Policy_Property
		FOREIGN KEY (PropertyId)
		REFERENCES Property(PropertyId),

	CONSTRAINT FK_POLICY_POLICYSTATUS
		FOREIGN KEY (PolicyStatusId)
		REFERENCES PolicyStatus(PolicyStatusId)
);

CREATE TABLE IncidentType (
	IncidentTypeId INT IDENTITY(1,1) PRIMARY KEY,
	IncidentName NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Incident (
	IncidentId INT IDENTITY(1,1) PRIMARY KEY,
	PolicyId INT NOT NULL,
	IncidentTypeId INT NOT NULL,
	DateOfIncident DATE NOT NULL,
	Description NVARCHAR(MAX),
	ReportedDate DATETIME NOT NULL DEFAULT GETDATE(),

	CONSTRAINT FK_Incident_Policy
		FOREIGN KEY (PolicyId)
		REFERENCES Policy(PolicyId),

	CONSTRAINT FK_Incident_IncidentType
		FOREIGN KEY (IncidentTypeId)
		REFERENCES IncidentType(IncidentTypeId)
);

CREATE TABLE ClaimStatus (
	ClaimStatusId INT IDENTITY(1,1) PRIMARY KEY,
	StatusName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Claim (
	ClaimId INT IDENTITY(1,1) PRIMARY KEY,
	IncidentId INT NOT NULL,
	ClaimStatusId INT NOT NULL,
	ClaimNumber NVARCHAR(50) NOT NULL UNIQUE,
	EstimatedLossAmount DECIMAL(18, 2),
	ApprovedPayoutAmount DECIMAL(18, 2),
	CreatedDate DATETIME NOT NULL DEFAULT GETDATE(),
	LastUpdated DATETIME NOT NULL DEFAULT GETDATE(),

	CONSTRAINT FK_Claim_Incident
		FOREIGN KEY (IncidentId)
		REFERENCES Incident(IncidentId),

	CONSTRAINT FK_Claim_ClaimStatus
		FOREIGN KEY (ClaimStatusId)
		REFERENCES ClaimStatus(ClaimStatusId)
);

CREATE TABLE Adjuster (
	AdjusterId INT IDENTITY(1,1) PRIMARY KEY,
	FirstName NVARCHAR(100) NOT NULL,
	LastName NVARCHAR(100) NOT NULL,
	Email NVARCHAR(255) NOT NULL,
	Phone NVARCHAR(50) NOT NULL
);

CREATE TABLE ClaimAdjuster (
	ClaimAdjusterId INT IDENTITY(1,1) PRIMARY KEY,
	ClaimId INT NOT NULL,
	AdjusterId INT NOT NULL,
	AssignedDate DATETIME NOT NULL DEFAULT GETDATE(),

	CONSTRAINT FK_ClaimAdjuster_Claim
		FOREIGN KEY (ClaimId)
		REFERENCES Claim(ClaimId),

	CONSTRAINT FK_ClaimAdjuster_Adjuster
		FOREIGN KEY (AdjusterId)
		REFERENCES Adjuster(AdjusterId)
);

CREATE TABLE ClaimPaymentMethod (
	ClaimPaymentMethodId INT IDENTITY(1,1) PRIMARY KEY,
	PaymentMethodName NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE ClaimPayment (
	ClaimPaymentId INT IDENTITY(1,1) PRIMARY KEY,
	ClaimId INT NOT NULL,
	ClaimPaymentMethodId INT NOT NULL,
	Amount DECIMAL(18, 2) NOT NULL,
	PaymentDate DATETIME NOT NULL DEFAULT GETDATE(),
	ReferenceNumber NVARCHAR(100),

	CONSTRAINT FK_ClaimPayment_Claim
		FOREIGN KEY (ClaimId)
		REFERENCES Claim(ClaimId),

	CONSTRAINT FK_ClaimPayment_ClaimPaymentMethod
		FOREIGN KEY (ClaimPaymentMethodId)
		REFERENCES ClaimPaymentMethod(ClaimPaymentMethodId)
);

INSERT INTO IncidentType (IncidentName)
VALUES 
('Wind Damage'),
('Hail Damage'),
('Lightning Strike'),
('Tornado'),
('Hurricane'),
('Earthquake'),
('Flood'),
('Wildfire'),
('Freeze Damage'),
('Roof Leak'),
('Burst Pipe'),
('Plumbing Leak'),
('Sewer Backup'),
('Electrical Fire'),
('Kitchen Fire'),
('Smoke Damage'),
('Burglary'),
('Theft'),
('Vandalism'),
('Vehicle Impact'),
('Falling Tree'),
('Falling Object');

INSERT INTO PropertyType (TypeName)
VALUES
('Single-Family Home'),
('Townhouse'),
('Condo'),
('Apartment'),
('Duplex'),
('Mobile Home'),
('Vacation Home'),
('Rental Property'),
('Commercial Building'),
('Office Building'),
('Retail Store'),
('Warehouse');

INSERT INTO PolicyStatus (StatusName)
VALUES
('Active'),
('Pending'),
('Expired'),
('Lapsed'),
('Cancelled'),
('Under Review');

INSERT INTO ClaimStatus (StatusName)
VALUES
('Open'),
('Under Review'),
('Inspection Scheduled'),
('In Investigation'),
('Approved'),
('Partially Approved'),
('Denied'),
('Pending Payment'),
('Closed'),
('Reopened');

INSERT INTO ClaimPaymentMethod (PaymentMethodName)
VALUES
('EFT'),
('Direct Deposit'),
('ACH Transfer'),
('Check'),
('Wire Transfer');