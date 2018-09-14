CREATE TABLE [dbo].[ServerServiceStatusDetails] (
    [ServerServiceStatusId]      BIGINT          IDENTITY (1, 1) NOT NULL,
    [ServerServiceStatusBatchId] BIGINT          NULL,
    [StoreServerId]              BIGINT          NULL,
    [HRAMStoreId]                BIGINT          NULL,
    [StoreNo]                    BIGINT          NULL,
    [ISSName]                    NVARCHAR (1000) NULL,
    [ServiceName]                NVARCHAR (1000) NULL,
    [IsServiceActive]            BIT             NULL,
    [CreatedOn]                  DATETIME        NULL,
    [CreatedBy]                  BIGINT          NULL,
    [ModifiedOn]                 DATETIME        NULL,
    [ModifiedBy]                 BIGINT          NULL
);

