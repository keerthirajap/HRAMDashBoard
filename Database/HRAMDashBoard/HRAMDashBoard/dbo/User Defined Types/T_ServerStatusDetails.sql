CREATE TYPE [dbo].[T_ServerStatusDetails] AS TABLE (
    [ServerStatusBatchId] BIGINT          NULL,
    [StoreServerId]       BIGINT          NULL,
    [HRAMStoreId]         BIGINT          NULL,
    [StoreNo]             BIGINT          NULL,
    [ISSName]             NVARCHAR (1000) NULL,
    [IsServerActive]      BIT             NULL,
    [ServerResponseTime]  INT             NULL,
    [UserId]              NVARCHAR (1000) NULL);

