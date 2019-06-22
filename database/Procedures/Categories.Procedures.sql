CREATE PROCEDURE [dbo].[CategoryInsert]
(	
	@Id int OUTPUT,
	@Name nvarchar(100),
	@Version timestamp OUTPUT
)
AS
BEGIN

	INSERT INTO Categories(Name)
		VALUES(@Name)

	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Categories WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[CategoryUpdate]
(
    @Id int,
    @Name nvarchar(50),
	@Version timestamp OUTPUT
)
AS
BEGIN


	UPDATE Categories
		SET Name = @Name
		WHERE Id = @Id AND [Version] = @Version

		SELECT @Version = [Version] FROM Categories WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[CategoryDelete] (@Id int, @Version timestamp)
AS
BEGIN
	DELETE FROM Categories WHERE Id = @Id AND [Version] = @Version	
END
GO