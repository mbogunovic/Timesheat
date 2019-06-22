CREATE PROCEDURE [dbo].[PortionInsert]
(	
	@Id int OUTPUT,
	@Name nvarchar(80),
	@Version timestamp OUTPUT
)
AS
BEGIN

	INSERT INTO Portions(Name)
		VALUES(@Name)

	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Meals WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[PortionUpdate]
(
    @Id int,
	@Name nvarchar(80),
	@Version timestamp OUTPUT
)
AS
BEGIN


	UPDATE Portions
		SET Name = @Name
		WHERE Id = @Id AND [Version] = @Version

		SELECT @Version = [Version] FROM Portions WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[PortionDelete]
(
	@Id int,
	@Version timestamp
)
AS
BEGIN
	DELETE FROM Portions WHERE Id = @Id AND [Version] = @Version	
END
GO