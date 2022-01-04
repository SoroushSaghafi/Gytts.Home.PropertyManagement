CREATE PROCEDURE [dbo].[spProperty_GetAll]
	@param1 int = 0,
	@param2 int
AS
begin
	select Id, [Name], [Address]
	from dbo.[Property];
end
