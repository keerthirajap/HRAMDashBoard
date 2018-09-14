CREATE TABLE [dbo].[StoreServerDetails] (
    [StoreServerId] BIGINT          IDENTITY (1, 1) NOT NULL,
    [HRAMStoreId]   BIGINT          NULL,
    [StoreNo]       BIGINT          NULL,
    [ISSName]       NVARCHAR (1000) NULL,
    [ISSFullName]   NVARCHAR (1000) NULL,
    [ISSIpAddress]  NVARCHAR (1000) NULL,
    [ISSDomain]     NVARCHAR (1000) NULL,
    [Comments]      NVARCHAR (MAX)  NULL,
    [IsActive]      BIT             NULL,
    [CreatedOn]     DATETIME        NULL,
    [CreatedBy]     BIGINT          NULL,
    [ModifiedOn]    DATETIME        NULL,
    [ModifiedBy]    BIGINT          NULL,
    CONSTRAINT [PK_StoreServerId] PRIMARY KEY CLUSTERED ([StoreServerId] ASC)
);

