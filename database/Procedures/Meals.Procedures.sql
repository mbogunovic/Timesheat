CREATE PROCEDURE [dbo].[MealInsert]
(	
	@Id int OUTPUT,
	@Name nvarchar(100),
	@Price int,
	@CategoryId int,
	@Version timestamp OUTPUT
)
AS
BEGIN

	INSERT INTO Meals(Name, Price, CategoryId)
		VALUES(@Name, @Price, @CategoryId)

	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Meals WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[MealUpdate]
(
    @Id int,
    @Name nvarchar(100),
	@Price int,
	@CategoryId int,
	@Version timestamp OUTPUT
)
AS
BEGIN


	UPDATE Meals
		SET Name = @Name, Price = @Price, CategoryId = @CategoryId
		WHERE Id = @Id AND [Version] = @Version

		SELECT @Version = [Version] FROM Meals WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[MealDelete]
(
	@Id int,
	@Version timestamp
)
AS
BEGIN
	DELETE FROM Meals WHERE Id = @Id AND [Version] = @Version	
END
GO