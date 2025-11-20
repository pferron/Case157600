pause Address Blankout

sqlcmd -S LpaSqlT1 -d WowLpes_sr -i AddressesBlankOut.sql

Pause Encode AgentData

sqlcmd -S LpaSqlT1 -d WowLpes_sr -i EncodeAgentData.sql

Pause Encode Person

sqlcmd -S LpaSqlT1 -d WowLpes_sr -i EncodePerson.sql

Pause Encode UserData

sqlcmd -S LpaSqlT1 -d WowLpes_sr -i EncodeUserData.sql