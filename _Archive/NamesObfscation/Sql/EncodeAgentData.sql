use WowLpes_SR
go

select count(*) as 'AgentData FirstNames to Code' 
from AgentData
where not Firstname Like '_[0-9][0-9][0-9][0-9][0-9]'

Update AgentData 
set Firstname = substring(firstname,1,1) +
				(select newvalue 
				 from   WowService.dbo.RandomCodeContent
				 where  tablename='Agentdata'
				  and   columnname='firstname'
				  and   oldvalue = Agentdata.firstname) 
Where not FirstName Like '_[0-9][0-9][0-9][0-9][0-9]'

Select @@ROWCOUNT as 'AgentData FirstName rows affected'

-----------------------------------------------------------------------

select count(*) as 'AgentData MiddleNames to Code' 
from AgentData
where not Middlename Like '_[0-9][0-9][0-9][0-9][0-9]'

Update AgentData 
set Middlename = substring(Middlename,1,1) +
				(select newvalue 
				 from   WowService.dbo.RandomCodeContent
				 where  tablename='Agentdata'
				  and   columnname='Middlename'
				  and   oldvalue = Agentdata.Middlename) 
Where not MiddleName Like '_[0-9][0-9][0-9][0-9][0-9]'

Select @@ROWCOUNT as 'AgentData MiddleName rows affected'

-----------------------------------------------------------------------

select count(*) as 'AgentData LastNames to Code' 
from AgentData
where not Lastname Like '_[0-9][0-9][0-9][0-9][0-9]'

Update AgentData 
set Lastname = substring(Lastname,1,1) +
				(select newvalue 
				 from   WowService.dbo.RandomCodeContent
				 where  tablename='Agentdata'
				  and   columnname='lastname'
				  and   oldvalue = Agentdata.lastname) 
Where not LastName Like '_[0-9][0-9][0-9][0-9][0-9]'

Select @@ROWCOUNT as 'AgentData LastName rows affected'

