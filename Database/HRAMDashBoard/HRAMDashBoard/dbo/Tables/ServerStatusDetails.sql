CREATE TABLE [dbo].[ServerStatusDetails] (
    [ServerStatusId]      BIGINT          IDENTITY (1, 1) NOT NULL,
    [ServerStatusBatchId] BIGINT          NULL,
    [StoreServerId]       BIGINT          NULL,
    [HRAMStoreId]         BIGINT          NULL,
    [StoreNo]             BIGINT          NULL,
    [ISSName]             NVARCHAR (1000) NULL,
    [IsServerActive]      BIT             NULL,
    [ServerResponseTime]  INT             NULL,
    [CreatedOn]           DATETIME        NULL,
    [CreatedBy]           BIGINT          NULL,
    [ModifiedOn]          DATETIME        NULL,
    [ModifiedBy]          BIGINT          NULL,
    CONSTRAINT [PK_ServerStatusId] PRIMARY KEY CLUSTERED ([ServerStatusId] ASC)
);

