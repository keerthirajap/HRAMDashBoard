CREATE TABLE [dbo].[ZendeskTicketsHistory] (
    [ZendeskTicketsId] BIGINT         NULL,
    [TicketsNo]        VARCHAR (1000) NOT NULL,
    [TicketsSubject]   VARCHAR (1000) NOT NULL,
    [TicketsCreatedOn] VARCHAR (1000) NOT NULL,
    [TicketsCreatedBy] VARCHAR (1000) NOT NULL,
    [SLA]              VARCHAR (1000) NOT NULL,
    [CreatedOn]        DATETIME       NULL,
    [CreatedBy]        BIGINT         NULL,
    [ModifiedOn]       DATETIME       NULL,
    [ModifiedBy]       BIGINT         NULL
);

