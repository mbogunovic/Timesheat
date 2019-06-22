CREATE PROCEDURE [dbo].[MealPortionInsert]
(	
	@MealId int,
	@PortionId int
)
AS
BEGIN

	INSERT INTO MealsPortions(MealId, PortionId)
		VALUES(@MealId, @PortionId)
END
GO

CREATE PROCEDURE [dbo].[MealPortionUpdate]
(
   @MealId int,
   @PortionId int
)
AS
BEGIN


	UPDATE MealsPortions
		SET PortionId = @PortionId
		WHERE MealId = @MealId
END
GO

CREATE PROCEDURE [dbo].[MealPortionDelete]
(
	@MealId int,
	@PortionId int
)
AS
BEGIN
	DELETE FROM MealsPortions WHERE MealId = @MealId AND PortionId = @PortionId	
END
GO