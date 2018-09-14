CREATE TABLE [dbo].[ServerStatusDetailsHistory] (
    [ServerStatusId]      BIGINT          NULL,
    [StoreServerId]       BIGINT          NULL,
    [HRAMStoreId]         BIGINT          NULL,
    [ServerStatusBatchId] BIGINT          NULL,
    [StoreNo]             BIGINT          NULL,
    [ISSName]             NVARCHAR (1000) NULL,
    [IsServerActive]      BIT             NULL,
    [ServerResponseTime]  INT             NULL,
    [CreatedOn]           DATETIME        NULL,
    [CreatedBy]           BIGINT          NULL,
    [ModifiedOn]          DATETIME        NULL,
    [ModifiedBy]          BIGINT          NULL
);

