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

# Testing the project
## 1. Please go the Add Store from the Navigation Menu and Add a Store.
## 2. Then please go to the Add Rack page from Nav Menu and add a Rack. Without Store you can not add any rack.
## 3. After adding the Rack, you can add an Element to the Rack from Add Element option of  Nav menu.
## 4. Also you can Edit or Delete any component its corresponding list page such as Sotres, Racks and Elements. You will find Edit and Delete icon in the Action column. If you delete any parent item it will delete all its child items too. For example, if you delete a particular store then it will also delete containing Racks and Elements. But if you delete any child item it won't effect the parent.
## 5. Report page of the Nav menu is only for demo.
