CREATE PROCEDURE [dbo].[UserRoleInsert]
(	
	@UserId int,
	@RoleId int
)
AS
BEGIN

	INSERT INTO UsersRoles(UserId, RoleId)
		VALUES(@UserId, @RoleId)
END
GO

CREATE PROCEDURE [dbo].[UserRoleUpdate]
(
    @UserId int,
	@RoleId int
)
AS
BEGIN


	UPDATE UsersRoles
		SET RoleId = @RoleId
		WHERE UserId = @UserId
END
GO

CREATE PROCEDURE [dbo].[UserRoleDelete]
(
	@UserId int,
	@RoleId int
)
AS
BEGIN
	DELETE FROM UsersRoles WHERE UserId = @UserId
END
GO