





CREATE PROC [dbo].[P_UpdateWindowsServiceHeartBeat] 
	@ServiceName [nvarchar](1000) ,
	@RunningServerName [nvarchar](1000) ,
	@HeartBeatValue [nvarchar] (MAX) ,
	@UserId [bigint] 	
  AS
begin

DECLARE @CurrentDateTime DATETIME = (SELECT GETDATE())

INSERT INTO [dbo].[WindowsServiceStatusHeartBeat]
           ([ServiceName]
           ,[RunningServerName]
           ,[HeartBeatValue]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[ModifiedOn]
           ,[ModifiedBy])
	SELECT
			@ServiceName
			,@RunningServerName 
			,@HeartBeatValue
			,@CurrentDateTime
			,@UserId 	
			,@CurrentDateTime
			,@UserId 

SELECT CAST(1 AS bit)
end









