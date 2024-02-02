# TestProgi

# System Requirements
* .Net 8.0
* Node js

# Installation Steps
Clone this repository
Go to cloned repository folder

There are two ways of executing this project:
1. executing it directly from visual studio 
2. by command console

If you decide to do it by command console please follow the steps below:
1. Go to the cloned directory folder
2. Go to the bidcalculationapp.client folder
3. Open vite.config.js file, with some editor text
4. Modify line 50, in the target attribute replace https://localhost:7065/ (swagger page) by http://localhost:5037/.
5. Save the file
6. Go to bidCalculationApp.Server folder
7. Open a new power shell terminal here
8. execute the next commands 
* dotnet restore  
* dotnet build
* dotnet run
10. Go to https://localhost:5173/


This will be enough for the application to communicate with the backend and work.

# Tech Stack
* .Net 8.0
* NPM
* Vue js
* xUnit
