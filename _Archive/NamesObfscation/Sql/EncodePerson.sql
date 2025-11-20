use WowLpes_SR
go

select count(*) as 'Person FirstNames to Code' 
from Person
where not Firstname Like '_[0-9][0-9][0-9][0-9][0-9]'

Update Person 
set Firstname = FirstNameFirstChar +
				(select newvalue 
				 from   WowService.dbo.RandomCodeContent
				 where  tablename='Person'
				  and   columnname='firstname'
				  and   oldvalue = Person.firstname) 
Where not FirstName Like '_[0-9][0-9][0-9][0-9][0-9]'

Select @@ROWCOUNT as 'Person FirstName rows affected'

-----------------------------------------------------------------------

select count(*) as 'Person MiddleNames to Code' 
from Person
where not Middlename Like '_[0-9][0-9][0-9][0-9][0-9]'

Update Person 
set Middlename = substring(Middlename,1,1) +
				(select newvalue 
				 from   WowService.dbo.RandomCodeContent
				 where  tablename='Person'
				  and   columnname='Middlename'
				  and   oldvalue = Person.Middlename) 
Where not Middlename Like '_[0-9][0-9][0-9][0-9][0-9]'

Select @@ROWCOUNT as 'Person MiddleName rows affected'

-----------------------------------------------------------------------

select count(*) as 'Person LastNames to Code' 
from Person
where not Lastname Like '_[0-9][0-9][0-9][0-9][0-9]'

Update Person 
set Lastname = LastNamefirstChar +
				(select newvalue 
				 from   WowService.dbo.RandomCodeContent
				 where  tablename='Person'
				  and   columnname='lastname'
				  and   oldvalue = Person.lastname) 
Where not LastName Like '_[0-9][0-9][0-9][0-9][0-9]'

Select @@ROWCOUNT as 'Person LastName rows affected'

-----------------------------------------------------------------------

select count(*) as 'Person SSNumbers to code'
from WowLpes_Sr.dbo.Person
where SSNumber not like '[0-9][0-9][0-9][0-9][0-9]'

Update WowLpes_Sr.dbo.Person
set SSNumber = 
				(select newvalue 
				 from   WowService.dbo.RandomCodeContent
				 where  tablename='Person'
				  and   columnname='SSNumber'
				  and   oldvalue = WowLpes_Sr.dbo.Person.SSNumber) 
where SSNumber is not null
 and  SSNumber not like '[0-9][0-9][0-9][0-9][0-9]'

Select @@ROWCOUNT as 'Person SSNumber''s rows affected'

-----------------------------------------------------------------------

select count(*) as 'Person DriversLicenseNums to code'
from WowLpes_Sr.dbo.Person
where DriversLicenseNum not like '[0-9][0-9][0-9][0-9][0-9]'

Update WowLpes_Sr.dbo.Person
set DriversLicenseNum = 
				(select newvalue 
				 from   WowService.dbo.RandomCodeContent
				 where  tablename='Person'
				  and   columnname='DriversLicenseNum'
				  and   oldvalue = WowLpes_Sr.dbo.Person.DriversLicenseNum) 
where DriversLicenseNum is not null
 and  DriversLicenseNum not like '[0-9][0-9][0-9][0-9][0-9]'

Select @@ROWCOUNT as 'Person DriversLicenseNum''s rows affected'

-----------------------------------------------------------------------
