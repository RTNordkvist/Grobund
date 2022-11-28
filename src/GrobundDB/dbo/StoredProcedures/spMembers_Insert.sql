CREATE PROCEDURE dbo.spMembers_Insert
	@FirstName nvarchar(30),
	@LastName nvarchar(50),
	@Email nvarchar(50),
	@PhoneNumber nvarchar(20),
	@id int = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Members (FirstName, LastName, Email, PhoneNumber)
	VALUES (@FirstName, @LastName, @Email, @PhoneNumber);

	SELECT @id = SCOPE_IDENTITY();
END