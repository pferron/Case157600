
.\BcpTemplate out LpaSqlT1 WowLpes_sr AgentData 
pause
.\BcpTemplate out LpaSqlT1 WowLpes_sr Address
pause
.\BcpTemplate out LpaSqlT1 WowLpes_sr AgentDChannel
.\BcpTemplate out LpaSqlT1 WowLpes_sr AgentDChannelContactInfo
.\BcpTemplate out LpaSqlT1 WowLpes_sr UserData 
pause
.\BcpTemplate out LpaSqlT1 WowLpes_sr Person
pause
.\

.\BcpTemplate in "np:\\.\pipe\LOCALDB#8DC8DA84\tsql\query" WowLpes_sr Address
.\BcpTemplate in "np:\\.\pipe\LOCALDB#8DC8DA84\tsql\query" WowLpes_sr AgentData 
.\BcpTemplate in "np:\\.\pipe\LOCALDB#8DC8DA84\tsql\query" WowLpes_sr AgentDChannel
.\BcpTemplate in "np:\\.\pipe\LOCALDB#8DC8DA84\tsql\query" WowLpes_sr AgentDChannelContactInfo
.\BcpTemplate in "np:\\.\pipe\LOCALDB#8DC8DA84\tsql\query" WowLpes_sr UserData 
.\BcpTemplate in "np:\\.\pipe\LOCALDB#8DC8DA84\tsql\query" WowLpes_sr Person

 
