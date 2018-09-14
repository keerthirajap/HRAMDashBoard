CREATE TABLE [dbo].[ZendeskTickets] (
    [ZendeskTicketId] BIGINT         IDENTITY (1, 1) NOT NULL,
    [TicketNo]        VARCHAR (1000) NOT NULL,
    [TicketSubject]   VARCHAR (1000) NOT NULL,
    [Priority]        INT            NOT NULL,
    [TicketCreatedOn] VARCHAR (1000) NOT NULL,
    [TicketCreatedBy] VARCHAR (1000) NOT NULL,
    [SLA]             VARCHAR (1000) NOT NULL,
    [CreatedOn]       DATETIME       NULL,
    [CreatedBy]       BIGINT         NULL,
    [ModifiedOn]      DATETIME       NULL,
    [ModifiedBy]      BIGINT         NULL
);

