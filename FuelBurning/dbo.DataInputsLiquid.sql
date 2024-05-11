CREATE TABLE [dbo].[DataInputsLiquid] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [Description] NVARCHAR (MAX) NULL,
    [UserId]      INT            NOT NULL,
    [IsActive]    BIT            NOT NULL,
    [C]           FLOAT (53)     NOT NULL,
    [H]           FLOAT (53)     NOT NULL,
    [S]           FLOAT (53)     NOT NULL,
    [N]           FLOAT (53)     NOT NULL,
    [O]           FLOAT (53)     NOT NULL,
    [Wp]          FLOAT (53)     NOT NULL,
    [Ap]          FLOAT (53)     NOT NULL,
    [T_v]         FLOAT (53)     NOT NULL,
    [T_t]         FLOAT (53)     NOT NULL,
    [alfaG]       FLOAT (53)     NOT NULL,
    [M_недожог]   FLOAT (53)     NOT NULL,
    [gg]          FLOAT (53)     NOT NULL,
    CONSTRAINT [PK_DataInputsLiquid] PRIMARY KEY CLUSTERED ([Id] ASC)
);

