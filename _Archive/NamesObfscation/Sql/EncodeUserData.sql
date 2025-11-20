use WowLpes_SR
go

select count(*) as 'UserData FirstNames to Code' 
from UserData
where not Firstname Like '_[0-9][0-9][0-9][0-9][0-9]'
go

Update UserData 
set Firstname = substring(firstname,1,1) +
				(select newvalue 
				 from   WowService.dbo.RandomCodeContent
				 where  tablename='Userdata'
				  and   columnname='firstname'
				  and   oldvalue = Userdata.firstname) 
Where not FirstName Like '_[0-9][0-9][0-9][0-9][0-9]'
go

Select @@ROWCOUNT as 'UserData FirstName rows affected'
go

-----------------------------------------------------------------------

select count(*) as 'UserData LastNames to Code' 
from UserData
where not Lastname Like '_[0-9][0-9][0-9][0-9][0-9]'
go

Update UserData 
set Lastname = substring(Lastname,1,1) +
				(select newvalue 
				 from   WowService.dbo.RandomCodeContent
				 where  tablename='Userdata'
				  and   columnname='lastname'
				  and   oldvalue = Userdata.lastname) 
Where not LastName Like '_[0-9][0-9][0-9][0-9][0-9]'
go

Select @@ROWCOUNT as 'UserData LastName rows affected'
go

-----------------------------------------------------------------------
select count(*) as 'Userdata UserNames to code'
from WowLpes_Sr.dbo.Userdata
where UserName not like '[a-z][0-9][0-9][0-9][0-9][0-9]'

Update WowLpes_Sr.dbo.Userdata
set UserName = case when FirstName is not null 
					then substring(FirstName,1,1) 
					else substring(LastName,1,1)
			   end +
				(select newvalue 
				 from   WowService.dbo.RandomCodeContent
				 where  tablename='Userdata'
				  and   columnname='UserName'
				  and   oldvalue = WowLpes_Sr.dbo.Userdata.UserName) 
where UserName is not null
 and  UserName not like '[a-z][0-9][0-9][0-9][0-9][0-9]'

Select @@ROWCOUNT as 'Userdata UserName''s rows affected'
