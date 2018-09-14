




CREATE PROC [dbo].[P_UpdateServerServiceStatusBatch] 
	@T_ServerStatusDetails	[dbo].[T_ServerStatusDetails] READONLY
		
  AS
begin

INSERT INTO [dbo].[ServerStatusDetails]
           ([ServerStatusBatchId]
           ,[StoreServerId]
           ,[HRAMStoreId]
           ,[StoreNo]
           ,[ISSName]
           ,[IsServerActive]
           ,[ServerResponseTime]
           ,[CreatedOn]
           ,[CreatedBy]
           ,[ModifiedOn]
           ,[ModifiedBy])
SELECT [ServerStatusBatchId]
      ,[StoreServerId]
      ,[HRAMStoreId]
      ,[StoreNo]
      ,[ISSName]
      ,[IsServerActive]
      ,[ServerResponseTime]
      ,GETDATE()
      ,[UserId]
       ,GETDATE()
      ,[UserId]
  FROM @T_ServerStatusDetails

SELECT CAST(1 AS bit)
end








