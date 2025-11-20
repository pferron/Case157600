IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = N'WowService')
begin
	CREATE DATABASE [WowService]
	 CONTAINMENT = NONE
	 ON  PRIMARY 
	( NAME = N'WowService', FILENAME = N'C:\Users\w600006\WowService.mdf' , SIZE = 73728KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
	 LOG ON 
	( NAME = N'WowService_log', FILENAME = N'C:\Users\w600006\WowService_log.ldf' , SIZE = 73728KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
	GO
end

IF EXISTS (SELECT * FROM sys.tables WHERE name = N'RandomCodeContent')
begin
	DROP TABLE [dbo].[RandomCodeContent]
	GO
end

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RandomCodeContent](
	[TableName] [nvarchar](30) NOT NULL,
	[ColumnName] [nvarchar](30) NOT NULL,
	[oldvalue] [nvarchar](200) NOT NULL,
	[newvalue] [nvarchar](10) NOT NULL,
 CONSTRAINT [PK_RandomCodeContent] PRIMARY KEY CLUSTERED 
(
	[TableName] ASC,
	[ColumnName] ASC,
	[oldvalue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO