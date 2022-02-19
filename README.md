# Background Tasks
I have written this [article](https://sosuliviu.medium.com/lets-talk-about-scheduled-background-tasks-2708b9873941) and you can follow the instructions bellow to run the examples.

Curently the solution consist of four projects. There projectes have nothing to do with each other. 
Each of them is used to demostrate an aproach of using a scheduled background task.

# Prerequisites
1. Visual Studio 2022 or later
2. Microsoft SQL Server V18 or later

# Setup
1. Create a SQL Database in the your SQL Server instance
2. Open there the file "Database seed.sql" that you will find on the "Other" directory. Run it to seed the database. 
 **NOTE**: Be aware of the Timing_Offset variable that is defined there. You will have all the technicals explanations of how to use it in the comments of this SQL file.
 You can watch this [video](https://www.youtube.com/watch?v=UQjTafcHcGI&ab_channel=Liviu%C8%98o%C8%99u) for a better undesrtanding.

# Usage
Set as start-up project in Visual Studio the project that you want to experiment (i.e. ASP.NET-BackroundTask) and run the application

If you have any questions please do not hesitate to get in touch.
