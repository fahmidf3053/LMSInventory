# LMSInventory

> A web app for managing inventory, using .net core and MS-SQL.
> I have used Blazor WebAssembly for Front-End, .net core 6 for Back-End & MS-SQL Database
> For api's security I have used JWT authentication and followed Code First approach In Entity Framework.

## Architecture Diagram of LMSInventory


<p align="center">
  <img src="https://github.com/fahmidf3053/LMSInventory/blob/master/Documents/ArchitectureDiagram/lms.png">
</p>



# To run the Project please open the LmsInventory.sln with Visual Studio



## Step-1. First run the MasterDBScript.sql under the Folder DBScript
> it will create the full database with the default User


## Step-2. If you want to use your own credentials then please encrypt your password using DBCredsManager and provide encrypted password & other info in the "LMSInventory/LMSInventory/API/LMS.API/appsettings.json"
<p align="center">
  <img src="https://github.com/fahmidf3053/LMSInventory/blob/master/Documents/ScreenShots/settAPI.png">
</p>


## Step-3. Now Run the LMS.API(Backend) and you will get the following swagger view
<p align="center">
  <img src="https://github.com/fahmidf3053/LMSInventory/blob/master/Documents/ScreenShots/APIs.png">
</p>

## Step-4. Now Run the LMS.Portal(Frontend)
> if you want to change the Base Url for api, then please change "LMSInventory/LMS.Portal/wwwroot/appsettings.json"
> Some front end pages are given below

## Home
<p align="center">
  <img src="https://github.com/fahmidf3053/LMSInventory/blob/master/Documents/ScreenShots/home.png">
</p>

## Home When Hovered
<p align="center">
  <img src="https://github.com/fahmidf3053/LMSInventory/blob/master/Documents/ScreenShots/home_hover.png">
</p>

## Stores
<p align="center">
  <img src="https://github.com/fahmidf3053/LMSInventory/blob/master/Documents/ScreenShots/stores.png">
</p>

## Add Elemnet
<p align="center">
  <img src="https://github.com/fahmidf3053/LMSInventory/blob/master/Documents/ScreenShots/addElement.png">
</p>

## Delete Store
<p align="center">
  <img src="https://github.com/fahmidf3053/LMSInventory/blob/master/Documents/ScreenShots/delete_Store.png">
</p>

