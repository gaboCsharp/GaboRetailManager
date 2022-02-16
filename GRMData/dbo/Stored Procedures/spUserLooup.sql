CREATE PROCEDURE [dbo].[spUserLooup]
	@id nvarchar(128)
AS
	set nocount on;
Begin
	select Id,FirstName, LastName, EmailAddress, CreatedDate
	from [dbo].[User]
	where id=@id;
End
