USE [TimesheatDB]
GO
/****** Object:  View [dbo].[CategoriesGetAll]    Script Date: 2/25/2020 9:44:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CategoriesGetAll]
AS
SELECT Id, Name, Version, ApplicableDailyDiscount
FROM Categories
GO
/****** Object:  View [dbo].[CompaniesGetAll]    Script Date: 2/25/2020 9:44:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[CompaniesGetAll]
AS
SELECT *
FROM Companies
GO
/****** Object:  View [dbo].[MealsGetAll]    Script Date: 2/25/2020 9:44:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[MealsGetAll]
AS
SELECT Id, Name, CategoryId, Version
FROM     Meals
GO
/****** Object:  View [dbo].[MealsPortionsGetAll]    Script Date: 2/25/2020 9:44:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO


CREATE VIEW [dbo].[MealsPortionsGetAll]
AS
SELECT MealsPortions.MealId, MealsPortions.PortionId, MealsPortions.Price
FROM     MealsPortions INNER JOIN
                  Portions ON Portions.Id = MealsPortions.PortionId
GO
/****** Object:  View [dbo].[OrdersGetAll]    Script Date: 2/25/2020 9:44:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[OrdersGetAll]
AS
SELECT orders.Id, orders.Comment, orders.Quantity, orders.LunchTime, orders.OrderDate, orders.UserId, orders.MealId, orders.PortionId, orders.Version, mp.Price * orders.Quantity AS Price, categories.ApplicableDailyDiscount
FROM dbo.Orders AS orders INNER JOIN
              dbo.MealsPortions AS mp ON orders.PortionId = mp.PortionId AND orders.MealId = mp.MealId INNER JOIN
              dbo.Meals AS meals ON meals.Id = orders.MealId INNER JOIN
              dbo.Categories AS categories ON categories.Id = meals.CategoryId
GO
/****** Object:  View [dbo].[PortionsGetAll]    Script Date: 2/25/2020 9:44:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PortionsGetAll]
AS
SELECT *
FROM Portions
GO
/****** Object:  View [dbo].[ReportGetAll]    Script Date: 2/25/2020 9:44:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




CREATE VIEW [dbo].[ReportGetAll]
AS
SELECT [Meals].[Id] as MealId, Meals.Name as MealName, 
Portions.Id as PortionId, Portions.Name as PortionName, 
Users.Id as UserId, Users.FullName as UserName,
Companies.Id as CompanyId, Companies.Name as CompanyName, 
Orders.Quantity,(Orders.Quantity * MealsPortions.Price) as Price, 
((Orders.Quantity * MealsPortions.Price) - 0) as DiscountedPrice,
Companies.DailyDiscount,
Orders.LunchTime,
Orders.OrderDate,
Meals.CategoryId,
Categories.Name as CategoryName
FROM Orders
INNER JOIN Meals on Meals.Id = Orders.MealId
INNER JOIN Portions on Portions.Id = Orders.PortionId
INNER JOIN MealsPortions on (MealsPortions.PortionId = Orders.PortionId AND MealsPortions.MealId = Orders.MealId)
INNER JOIN Users on Users.Id = Orders.UserId
INNER JOIN Companies on Companies.Id = Users.CompanyId
INNER JOIN Categories on Categories.Id = Meals.CategoryId
GO
/****** Object:  View [dbo].[RolesGetAll]    Script Date: 2/25/2020 9:44:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[RolesGetAll]
AS
SELECT *
FROM Roles
GO
/****** Object:  View [dbo].[UsersGetAll]    Script Date: 2/25/2020 9:44:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UsersGetAll]
AS
SELECT *
FROM Users
GO
/****** Object:  View [dbo].[UsersRolesGetAll]    Script Date: 2/25/2020 9:44:58 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UsersRolesGetAll]
AS
SELECT *
FROM UsersRoles
GO
