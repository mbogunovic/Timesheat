CREATE PROCEDURE [dbo].[UserInsert]
(	
	@Id int OUTPUT,
	@FullName nvarchar(80),
	@Email nvarchar(254),
	@Password nvarchar(64),
	@IsActive bit,
	@CompanyId int,
	@Version timestamp OUTPUT
)
AS
BEGIN

	INSERT INTO Users(FullName, Email, Password, IsActive, CompanyId)
		VALUES(@FullName, @Email, @Password, @IsActive, @CompanyId)

	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Meals WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[UserUpdate]
(
    @Id int,
	@FullName nvarchar(80),
	@Email nvarchar(254),
	@Password nvarchar(64),
	@IsActive bit,
	@CompanyId int,
	@Version timestamp OUTPUT
)
AS
BEGIN


	UPDATE Users
		SET FullName = @FullName, Email = @Email, Password = @Password, 
		IsActive = @IsActive, CompanyId = @CompanyId
		WHERE Id = @Id AND [Version] = @Version

		SELECT @Version = [Version] FROM Users WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[UserDelete]
(
	@Id int,
	@Version timestamp
)
AS
BEGIN
	DELETE FROM Users WHERE Id = @Id AND [Version] = @Version	
END
GO