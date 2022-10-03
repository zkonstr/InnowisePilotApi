USE [FridgeManagmentDB]
GO

CREATE PROCEDURE sp_check_quantity
AS
BEGIN
	SELECT [Id],[ProductId],[FridgeID],[Quantity]
	FROM FridgeProducts
	WHERE FridgeProducts.Quantity = 0
END;
GO

--EXEC sp_check_products_in_fridges