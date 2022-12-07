CREATE PROCEDURE dbo.spMembers_Insert
	@Name nvarchar(450),
	@Email nvarchar(50),
	@PhoneNumber nvarchar(20),
	@id int = 0 OUTPUT
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO dbo.Members (Name, Email, PhoneNumber)
	VALUES (@Name, @Email, @PhoneNumber);

	SELECT @id = SCOPE_IDENTITY();
END