CREATE PROCEDURE [dbo].[spProduct_GetAll]
AS
	set nocount on;
begin	
	select 
	id,
	ProductName,
	[Description],
	RetailPrice,
	QuantityInStock,
	isTaxable
	from Product
	Order by ProductName;
end
