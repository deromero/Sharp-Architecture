USE master
GO

IF DB_ID('TardisBank') IS NULL BEGIN
  CREATE DATABASE [TardisBank]
    CONTAINMENT = NONE
  ON  PRIMARY
    ( NAME = N'TardisBank', FILENAME = N'/var/opt/mssql/data/TardisBank.mdf' , SIZE = 2048KB , MAXSIZE = 65536KB , FILEGROWTH = 10%)
  LOG ON
    ( NAME = N'TardisBank_log', FILENAME = N'/var/opt/mssql/data/TardisBank_log.ldf' , SIZE = 2048KB , MAXSIZE = 131072KB , FILEGROWTH = 10%)
END

GO

USE [TardisBank]
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY')
  ALTER DATABASE [TardisBank] MODIFY FILEGROUP [PRIMARY] DEFAULT;


IF DB_ID('DbMain') IS NULL BEGIN
  CREATE DATABASE [DbMain]
    CONTAINMENT = NONE
  ON  PRIMARY
    ( NAME = N'DbMain', FILENAME = N'/var/opt/mssql/data/DbMain.mdf' , SIZE = 2048KB , MAXSIZE = 65536KB , FILEGROWTH = 10%)
  LOG ON
    ( NAME = N'DbMain_log', FILENAME = N'/var/opt/mssql/data/DbMain_log.ldf' , SIZE = 2048KB , MAXSIZE = 131072KB , FILEGROWTH = 10%)
END

GO

USE [DbMain]
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY')
  ALTER DATABASE [DbMain] MODIFY FILEGROUP [PRIMARY] DEFAULT;


IF DB_ID('DbLog') IS NULL BEGIN
  CREATE DATABASE [DbLog]
    CONTAINMENT = NONE
  ON  PRIMARY
    ( NAME = N'DbLog', FILENAME = N'/var/opt/mssql/data/DbLog.mdf' , SIZE = 2048KB , MAXSIZE = 65536KB , FILEGROWTH = 10%)
  LOG ON
    ( NAME = N'DbLog_log', FILENAME = N'/var/opt/mssql/data/DbLog_log.ldf' , SIZE = 2048KB , MAXSIZE = 131072KB , FILEGROWTH = 10%)
END

GO

USE [DbLog]
IF NOT EXISTS (SELECT name FROM sys.filegroups WHERE is_default=1 AND name = N'PRIMARY')
  ALTER DATABASE [DbLog] MODIFY FILEGROUP [PRIMARY] DEFAULT;

