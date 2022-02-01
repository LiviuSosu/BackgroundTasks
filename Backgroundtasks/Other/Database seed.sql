/****** Script for SelectTopNRows command from SSMS  ******/

DECLARE @Timing_Offset AS int;
SET @Timing_Offset = -8; -- Modify this variable (i.e. -15) if you want to have some more time before running the script

SELECT TOP (1000) [Id]
      ,[Title]
      ,[Description]
      ,[CreatedOn]
  FROM [BackgroundTasks].[dbo].[Articles] Where CreatedOn > DATEADD(SECOND, @Timing_Offset, GETDATE())

  DELETE FROM [BackgroundTasks].[dbo].[Articles]

  INSERT INTO [BackgroundTasks].[dbo].[Articles] ([Title],[Description],[CReatedOn]) VALUES('Title 1','Description 1' , DATEADD(SECOND, 0, GETDATE()))
  INSERT INTO [BackgroundTasks].[dbo].[Articles] ([Title],[Description],[CReatedOn]) VALUES('Title 2','Description 2' , DATEADD(SECOND, 2, GETDATE()))
  INSERT INTO [BackgroundTasks].[dbo].[Articles] ([Title],[Description],[CReatedOn]) VALUES('Title 3','Description 3' , DATEADD(SECOND, 2, GETDATE()))
  INSERT INTO [BackgroundTasks].[dbo].[Articles] ([Title],[Description],[CReatedOn]) VALUES('Title 4','Description 4' , DATEADD(SECOND, 5, GETDATE()))
  INSERT INTO [BackgroundTasks].[dbo].[Articles] ([Title],[Description],[CReatedOn]) VALUES('Title 5','Description 5' , DATEADD(SECOND, 5, GETDATE()))
  INSERT INTO [BackgroundTasks].[dbo].[Articles] ([Title],[Description],[CReatedOn]) VALUES('Title 6','Description 6' , DATEADD(SECOND, 8, GETDATE()))
  INSERT INTO [BackgroundTasks].[dbo].[Articles] ([Title],[Description],[CReatedOn]) VALUES('Title 7','Description 7' , DATEADD(SECOND, 8, GETDATE()))
  INSERT INTO [BackgroundTasks].[dbo].[Articles] ([Title],[Description],[CReatedOn]) VALUES('Title 8','Description 8' , DATEADD(SECOND, 11, GETDATE()))
  INSERT INTO [BackgroundTasks].[dbo].[Articles] ([Title],[Description],[CReatedOn]) VALUES('Title 9','Description 9' , DATEADD(SECOND, 11, GETDATE()))