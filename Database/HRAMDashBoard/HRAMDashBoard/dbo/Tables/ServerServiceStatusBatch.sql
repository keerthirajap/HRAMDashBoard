CREATE TABLE [dbo].[ServerServiceStatusBatch] (
    [ServerServiceStatusBatchId] BIGINT   IDENTITY (1, 1) NOT NULL,
    [CreatedOn]                  DATETIME NULL,
    [CreatedBy]                  BIGINT   NULL,
    [ModifiedOn]                 DATETIME NULL,
    [ModifiedBy]                 BIGINT   NULL
);

