CREATE TABLE [dbo].[Users] (
    [UserId]       INT            IDENTITY (1, 1) NOT NULL,
    [Username]     NVARCHAR (MAX) NULL,
    [FirstName]    NVARCHAR (MAX) NULL,
    [LastName]     NVARCHAR (MAX) NULL,
    [Email]        NVARCHAR (MAX) NULL,
    [Password]     NVARCHAR (MAX) NULL,
    [PasswordHash] NVARCHAR (300) NULL,
    [PasswordSalt] NVARCHAR (100) NULL,
    [IsActive]     BIT            NULL,
    [CreatedOn]    DATETIME       NULL,
    [CreatedBy]    BIGINT         NULL,
    [ModifiedOn]   DATETIME       NULL,
    [ModifiedBy]   BIGINT         NULL,
    CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED ([UserId] ASC)
);

