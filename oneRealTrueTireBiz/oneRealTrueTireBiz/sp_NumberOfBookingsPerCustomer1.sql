CREATE PROCEDURE [dbo].[sp_NumberOfBookingsPerCustomer1]
AS

declare @antal int = 1;
declare @maxAntal int = (
select top(1) count(t.CustomerID) as 'Antal'
	from TireChange t
	group by t.CustomerID
	order by Antal desc
	);
declare @currentAntal int;
declare @tablez table (Amount int, TireChanges int);
insert into @tablez values ((
	select count(*) as a
	from Customer c
	left join TireChange t on c.CustomerID = t.CustomerID

where t.CustomerID is null	),0);
	while @antal <= @maxAntal begin
		set @currentAntal = (
			select count(antal) as 'Totalt' from
			(select count(t.CustomerID) as 'Antal'
			from TireChange t
			group by t.CustomerID) as agg
			group by antal
			having antal = @antal);
 
 insert into @tablez values (@currentAntal,@antal);
 set @antal +=1;
end;
select * from @tablez;

return 0

