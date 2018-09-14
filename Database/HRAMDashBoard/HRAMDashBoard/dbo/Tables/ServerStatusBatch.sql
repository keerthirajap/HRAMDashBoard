CREATE TABLE [dbo].[ServerStatusBatch] (
    [ServerStatusBatchId] BIGINT   IDENTITY (1, 1) NOT NULL,
    [CreatedOn]           DATETIME NULL,
    [CreatedBy]           BIGINT   NULL,
    [ModifiedOn]          DATETIME NULL,
    [ModifiedBy]          BIGINT   NULL,
    CONSTRAINT [PK_ServerStatusBatchId] PRIMARY KEY CLUSTERED ([ServerStatusBatchId] ASC)
);

