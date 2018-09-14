




CREATE PROC [dbo].[P_GetDashBoardWidgetDetails] 
		
		
  AS
begin
	
	DECLARE @ServerStatusBatchId bigint = (SELECT MAX(ServerStatusBatchId) FROM ServerStatusDetails)	   

	DECLARE @TotalNoHRAMISS02Servers bigint   =  ( SELECT COUNT(ServerStatusBatchId)
														  FROM [dbo].[ServerStatusDetails]
														  WHERE ServerStatusBatchId = @ServerStatusBatchId
														 
														  AND ISSName LIKE '%ISS02%'
														  )

	DECLARE @TotalNoHRAMISS02ServersActive bigint  =  ( SELECT COUNT(ServerStatusBatchId)
														  FROM [dbo].[ServerStatusDetails]
														  WHERE ServerStatusBatchId = @ServerStatusBatchId
														  AND IsServerActive = 1
														  AND ISSName LIKE '%ISS02%'
														  )

	DECLARE @TotalNoHRAMISS02ServersInActive bigint  =  ( SELECT COUNT(ServerStatusBatchId)
														  FROM [dbo].[ServerStatusDetails]
														  WHERE ServerStatusBatchId = @ServerStatusBatchId
														  AND IsServerActive = 0
														  AND ISSName LIKE '%ISS02%'
														  )
	DECLARE @ServerStatusCheckedOn datetime =    ( SELECT MAX(ModifiedOn)
														  FROM [dbo].[ServerStatusDetails]
														  WHERE ServerStatusBatchId = @ServerStatusBatchId														
														  )

	SELECT @TotalNoHRAMISS02Servers				AS TotalNoHRAMISS02Servers 
		  ,@TotalNoHRAMISS02ServersActive		AS TotalNoHRAMISS02ServersActive 
		  ,@TotalNoHRAMISS02ServersInActive		AS TotalNoHRAMISS02ServersInActive
		  ,@ServerStatusCheckedOn				AS ServerStatusCheckedOn
		
	
end








