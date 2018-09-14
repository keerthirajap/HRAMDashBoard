CREATE TABLE [dbo].[StoreDetails] (
    [HRAMStoreId]   BIGINT          IDENTITY (1, 1) NOT NULL,
    [StoreNo]       BIGINT          NULL,
    [StoreName]     NVARCHAR (1000) NULL,
    [Domain]        NVARCHAR (1000) NULL,
    [Comments]      NVARCHAR (MAX)  NULL,
    [IsStoreActive] BIT             NULL,
    [CreatedOn]     DATETIME        NULL,
    [CreatedBy]     BIGINT          NULL,
    [ModifiedOn]    DATETIME        NULL,
    [ModifiedBy]    BIGINT          NULL,
    CONSTRAINT [PK_ServerId] PRIMARY KEY CLUSTERED ([HRAMStoreId] ASC)
);

