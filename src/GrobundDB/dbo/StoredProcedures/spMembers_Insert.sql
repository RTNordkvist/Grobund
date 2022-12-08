CREATE PROCEDURE dbo.spMembers_Insert
	@Name nvarchar(70),
	@Email nvarchar(50),
	@Registered nvarchar(50),
	@PhoneNumber nvarchar(20),
	@MobileNumber nvarchar(20),
	@Address1 nvarchar(100),
	@Address2 nvarchar(100),
	@City nvarchar(50),
	@PostalCode nvarchar(100),
	@Country nvarchar(50),
	@UserCertificate nvarchar(50),
	@LandCertificate nvarchar(50),
	
	@id int = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Members (Name, Email, Registered, PhoneNumber , MobileNumber, Address1, Address2, City, PostalCode, Country, UserCertificate, LandCertificate)
	VALUES (@Name, @Email, @Registered, @PhoneNumber , @MobileNumber, @Address1, @Address2, @City, @PostalCode, @Country, @UserCertificate, @LandCertificate);

	SELECT @id = SCOPE_IDENTITY();
END