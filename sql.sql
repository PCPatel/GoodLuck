CREATE TABLE [dbo].[Challans] (
    [Id]             INT          IDENTITY (1, 1) NOT NULL,
    [CustomerId]     INT          NOT NULL,
    [ChallanNo]      VARCHAR (20) NULL,
    [ChallanDate]    DATE         NULL,
    [Size]           VARCHAR (10) NULL,
    [Schedule]       VARCHAR (10) NULL,
    [Length]         INT          NULL,
    [90D_Nos]        INT          NULL,
    [90D_Length]     INT          NULL,
    [1D_Nos]         INT          NULL,
    [1D_Length]      INT          NULL,
    [45D_Nos]        INT          NULL,
    [45D_Length]     INT          NULL,
    [Long_Nos]       INT          NULL,
    [Long_Length]    INT          NULL,
    [Reducer_Nos]    INT          NULL,
    [Reducer_Length] INT          NULL,
    [Balance_Length] INT          NULL,
    [Scrap_Length]   INT          NULL,
    [Scrap_Date]     DATE         NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Customers] (
    [Id]            INT           IDENTITY (1, 1) NOT NULL,
    [Name]          VARCHAR (250) NOT NULL,
    [Address1]      VARCHAR (250) NOT NULL,
    [Address2]      VARCHAR (250) NULL,
    [Pincode]       INT           NULL,
    [City]          VARCHAR (50)  NULL,
    [State]         VARCHAR (50)  NULL,
    [Phone]         VARCHAR (15)  NULL,
    [Mobile]        VARCHAR (10)  NULL,
    [GSTNO]         VARCHAR (20)  NULL,
    [ContactPerson] VARCHAR (50)  NULL,
    [AddedBy]       VARCHAR (20)  NOT NULL,
    [AddedOn]       DATETIME      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    UNIQUE NONCLUSTERED ([Name] ASC)
);

CREATE TABLE [dbo].[Users] (
    [Id]        INT           IDENTITY (1, 1) NOT NULL,
    [UserName]  VARCHAR (20)  NOT NULL,
    [Password]  VARCHAR (20)  NOT NULL,
    [FirstName] VARCHAR (20)  NOT NULL,
    [LastName]  VARCHAR (20)  NULL,
    [Email]     VARCHAR (100) NULL,
    [Mobile]    VARCHAR (10)  NULL,
    [IsAdmin]   BIT           NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([UserName] ASC)
);

