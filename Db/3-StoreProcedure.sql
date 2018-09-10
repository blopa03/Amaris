USE [Amaris]
GO

/****** Object:  StoredProcedure [dbo].[NLog_AddEntry_p]    Script Date: 10/09/2018 0:56:51 ******/
DROP PROCEDURE IF EXISTS [dbo].[NLog_AddEntry_p]
GO

/****** Object:  StoredProcedure [dbo].[NLog_AddEntry_p]    Script Date: 10/09/2018 0:56:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[NLog_AddEntry_p]') AND type in (N'P', N'PC'))
BEGIN
EXEC dbo.sp_executesql @statement = N'CREATE PROCEDURE [dbo].[NLog_AddEntry_p] AS' 
END
GO


ALTER PROCEDURE [dbo].[NLog_AddEntry_p] (
  @machineName nvarchar(200),
  @siteName nvarchar(200),
  @logged datetime,
  @level varchar(5),
  @userName nvarchar(200),
  @message nvarchar(max),
  @logger nvarchar(300),
  @properties nvarchar(max),
  @serverName nvarchar(200),
  @port nvarchar(100),
  @url nvarchar(2000),
  @https bit,
  @serverAddress nvarchar(100),
  @remoteAddress nvarchar(100),
  @callSite nvarchar(300),
  @exception nvarchar(max)
) AS
BEGIN
  INSERT INTO [dbo].[NLog] (
    [MachineName],
    [SiteName],
    [Logged],
    [Level],
    [UserName],
    [Message],
    [Logger],
    [Properties],
    [ServerName],
    [Port],
    [Url],
    [Https],
    [ServerAddress],
    [RemoteAddress],
    [CallSite],
    [Exception]
  ) VALUES (
    @machineName,
    @siteName,
    @logged,
    @level,
    @userName,
    @message,
    @logger,
    @properties,
    @serverName,
    @port,
    @url,
    @https,
    @serverAddress,
    @remoteAddress,
    @callSite,
    @exception
  );
END
GO


