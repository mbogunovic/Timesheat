CREATE PROCEDURE [dbo].[OrderInsert]
(	
	@Id int OUTPUT,
	@Comment nvarchar(120),
	@Quantity int,
	@LunchTime time(7),
	@OrderDate date,
	@UserId int,
	@MealId int,
	@PortionId int,
	@Version timestamp OUTPUT
)
AS
BEGIN

	INSERT INTO Orders(Comment, Quantity, LunchTime, OrderDate, UserId, MealId, PortionId)
		VALUES(@Comment, @Quantity, @LunchTime, @OrderDate, @UserId, @MealId, @PortionId)

	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Meals WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[OrderUpdate]
(
    @Id int,
    @Comment nvarchar(120),
	@Quantity int,
	@LunchTime time(7),
	@OrderDate date,
	@UserId int,
	@MealId int,
	@PortionId int,
	@Version timestamp OUTPUT
)
AS
BEGIN


	UPDATE Orders
		SET Comment = @Comment, Quantity = @Quantity, 
		LunchTime = @LunchTime, OrderDate = @OrderDate, 
		UserId = @UserId, MealId = @MealId, PortionId = @PortionId
		WHERE Id = @Id AND [Version] = @Version

		SELECT @Version = [Version] FROM Orders WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[OrderDelete]
(
	@Id int,
	@Version timestamp
)
AS
BEGIN
	DELETE FROM Orders WHERE Id = @Id AND [Version] = @Version	
END
GO