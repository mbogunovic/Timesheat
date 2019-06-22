CREATE PROCEDURE [dbo].[CompanyInsert]
(	
	@Id int OUTPUT,
	@Name nvarchar(80),
	@Email nvarchar(254),
	@DailyDiscount int,
	@Version timestamp OUTPUT
)
AS
BEGIN

	INSERT INTO Companies(Name, Email, DailyDiscount)
		VALUES(@Name, @Email, @DailyDiscount)

	SET @Id =  SCOPE_IDENTITY()

	SELECT @Version = [Version] FROM Companies WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[CompanyUpdate]
(
    @Id int,
    @Name nvarchar(80),
	@Email nvarchar(254),
	@DailyDiscount int,
	@Version timestamp OUTPUT
)
AS
BEGIN


	UPDATE Companies
		SET Name = @Name, Email = @Email, DailyDiscount = @DailyDiscount
		WHERE Id = @Id AND [Version] = @Version

		SELECT @Version = [Version] FROM Companies WHERE Id = @Id
END
GO

CREATE PROCEDURE [dbo].[CompanyDelete]
(
	@Id int,
	@Version timestamp
)
AS
BEGIN
	DELETE FROM Companies WHERE Id = @Id AND [Version] = @Version	
END
GO