CREATE PROCEDURE [dbo].[spProperty_GetAll]
AS
begin
	select Id, [Name], [Address]
	from dbo.[Property];
end
