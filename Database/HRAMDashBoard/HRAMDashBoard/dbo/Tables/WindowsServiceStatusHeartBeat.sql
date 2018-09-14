CREATE TABLE [dbo].[WindowsServiceStatusHeartBeat] (
    [HeartBeatId]       BIGINT          IDENTITY (1, 1) NOT NULL,
    [ServiceName]       NVARCHAR (1000) NULL,
    [RunningServerName] NVARCHAR (1000) NULL,
    [HeartBeatValue]    NVARCHAR (MAX)  NULL,
    [CreatedOn]         DATETIME        NULL,
    [CreatedBy]         BIGINT          NULL,
    [ModifiedOn]        DATETIME        NULL,
    [ModifiedBy]        BIGINT          NULL,
    CONSTRAINT [PK_HeartBeatId] PRIMARY KEY CLUSTERED ([HeartBeatId] ASC)
);

