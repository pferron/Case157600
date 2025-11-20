declare @count int
select @count=count(*) from dbo.RandomCodeContent
if @count>0
begin
	Truncate Table RandomCodeContent
end
