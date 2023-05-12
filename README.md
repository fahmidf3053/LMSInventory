# LMSInventory

> A web app for managing inventory, using .net core and MS-SQL.

## Architecture Diagram of LMSInventory


<p align="center">
  <img src="https://github.com/fahmidf3053/LMSInventory/blob/master/Documents/ArchitectureDiagram/lms.png">
</p>



# To run the Project please open the LmsInventory.sln with Visual Studio



## First run the MasterDBScript.sql under the Folder DBScript
> it will create the full database with the default User


## If you want to use your own credentials then please encrypt your password using DBCredsManager and provide encrypted password & other info in the "LMSInventory/LMSInventory/API/LMS.API/appsettings.json"
<p align="center">
  <img src="https://github.com/fahmidf3053/LMSInventory/blob/master/Documents/ScreenShots/settAPI.png">
</p>


## Now Run the LMS.API(Backend) and you will get the following swagger view
<p align="center">
  <img src="https://github.com/fahmidf3053/LMSInventory/blob/master/Documents/ScreenShots/APIs.png">
</p>
