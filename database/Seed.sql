USE [TimesheatDB]
GO

DECLARE	@return_value int,
		@Id int,
		@Version timestamp

EXEC	@return_value = [dbo].[PortionInsert]
		@Id = @Id OUTPUT,
		@Name = N'Mala',
		@Version = @Version OUTPUT

SELECT	@Id as N'@Id',
		@Version as N'@Version'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int,
		@Id int,
		@Version timestamp

EXEC	@return_value = [dbo].[PortionInsert]
		@Id = @Id OUTPUT,
		@Name = N'Velika',
		@Version = @Version OUTPUT

SELECT	@Id as N'@Id',
		@Version as N'@Version'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int,
		@Id int,
		@Version timestamp

EXEC	@return_value = [dbo].[PortionInsert]
		@Id = @Id OUTPUT,
		@Name = N'Porcija',
		@Version = @Version OUTPUT

SELECT	@Id as N'@Id',
		@Version as N'@Version'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int,
		@Id int,
		@Version timestamp

EXEC	@return_value = [dbo].[RoleInsert]
		@Id = @Id OUTPUT,
		@Name = N'Administrator',
		@Version = @Version OUTPUT

SELECT	@Id as N'@Id',
		@Version as N'@Version'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int,
		@Id int,
		@Version timestamp

EXEC	@return_value = [dbo].[RoleInsert]
		@Id = @Id OUTPUT,
		@Name = N'User',
		@Version = @Version OUTPUT

SELECT	@Id as N'@Id',
		@Version as N'@Version'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int,
		@Id int,
		@Version timestamp

EXEC	@return_value = [dbo].[RoleInsert]
		@Id = @Id OUTPUT,
		@Name = N'Manager',
		@Version = @Version OUTPUT

SELECT	@Id as N'@Id',
		@Version as N'@Version'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int,
		@Id int,
		@Version timestamp

EXEC	@return_value = [dbo].[CompanyInsert]
		@Id = @Id OUTPUT,
		@Name = N'Timesheat',
		@Email = N'timesheat@outlook.com',
		@DailyDiscount = 0,
		@Version = @Version OUTPUT

SELECT	@Id as N'@Id',
		@Version as N'@Version'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int,
		@Id int,
		@Version timestamp

EXEC	@return_value = [dbo].[UserInsert]
		@Id = @Id OUTPUT,
		@FullName = N'Administrator',
		@Email = N'timesheat@gmail.com',
		@Password = N'e585a8ac152af83f570860a3290ad690',
		@IsActive = 1,
		@CompanyId = 1,
		@Version = @Version OUTPUT

SELECT	@Id as N'@Id',
		@Version as N'@Version'

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[UserRoleInsert]
		@UserId = 1,
		@RoleId = 1

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[UserRoleInsert]
		@UserId = 1,
		@RoleId = 2

SELECT	'Return Value' = @return_value

GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[UserRoleInsert]
		@UserId = 1,
		@RoleId = 3

SELECT	'Return Value' = @return_value

GO
