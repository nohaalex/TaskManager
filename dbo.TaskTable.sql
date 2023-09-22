USE [Mydb]
GO

/****** Object: Table [dbo].[TaskTable] Script Date: 22-09-2023 11:28:33 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[TaskTable] (
    [TaskId]          INT           IDENTITY (1, 1) NOT NULL,
    [TaskName]        NVARCHAR (50) NULL,
    [TaskDescription] TEXT          NULL
);


