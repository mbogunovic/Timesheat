CREATE TRIGGER OrdersDateCheck ON Orders
AFTER INSERT
AS
BEGIN
	IF EXISTS(SELECT * FROM inserted WHERE OrderDate <= GETDATE())
		BEGIN 
			RAISERROR('Order can not be created for past date or current date.', 16, 1);
			ROLLBACK TRANSACTION;
		END
END