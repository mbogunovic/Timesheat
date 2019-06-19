CREATE PROCEDURE [dbo].[RoleInsert]
(	
	@Id int OUTPUT,
	@Name nvarchar(50),
	@Version timestamp OUTPUT
)
AS
BEGIN

	INSERT INTO Roles(Name)
		VALUES(@Name)

	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Meals WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[RoleUpdate]
(
    @Id int,
	@Name nvarchar(50),
	@Version timestamp OUTPUT
)
AS
BEGIN


	UPDATE Roles
		SET Name = @Name
		WHERE Id = @Id AND [Version] = @Version

		SELECT @Version = [Version] FROM Roles WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[RoleDelete]
(
	@Id int,
	@Version timestamp
)
AS
BEGIN
	DELETE FROM Roles WHERE Id = @Id AND [Version] = @Version	
END
GO