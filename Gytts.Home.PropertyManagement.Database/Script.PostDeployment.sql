if not exists (select 1 from dbo.[Property])
begin
	insert into dbo.[Property] (Name, Address)
	values ('Home #1', 'Home Adrress #1'),
	('Home #2', 'Home Adrress #2'),
    ('Home #3', 'Home Adrress #3');
end
