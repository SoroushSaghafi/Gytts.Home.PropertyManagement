CREATE PROCEDURE [dbo].[spProperty_Insert]
	@Name nvarchar(50),
	@Address nvarchar(50)
AS
begin
	insert into dbo.[Property] (Name, Address)
	values (@Name, @Address);
end