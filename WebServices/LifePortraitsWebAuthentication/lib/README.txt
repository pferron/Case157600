Per StoneRiver's response below, I swiped the DLL from the LifeServer folder and added it here. If the DLL gets updated during a delivery, this file will need to be replaced.

Doug Dawson

-----------

Hi Doug,

You will need to build the request.accountSetupRequestXML everytime for all requests.  Usually to build it I recommend working with strong typed classes.  The class you need to build is this one:
 
LifeServer.DataModel.request.AgentAccountSetupData

And resides in the project LifeService.DataModel (LifeService.DataModel.dll).

So is like this:

1)Create a new instance of AgentAccountSetupData and populate all required properties.

2) serialize the instance to string using AgentAccountSetupData.Serialize()

3) Call this static method AgentAccountRequest.buildFromStringXML(string) passing the string from step 2.
 
Regards

Stefan Stoian