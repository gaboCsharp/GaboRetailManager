CREATE PROCEDURE [dbo].[spProduct_GetById]
	@Id int
AS
begin
	set nocount on;
		select 
	id,
	ProductName,
	[Description],
	RetailPrice,
	QuantityInStock,
	isTaxable
	from Product
	where Id = @Id;
end
