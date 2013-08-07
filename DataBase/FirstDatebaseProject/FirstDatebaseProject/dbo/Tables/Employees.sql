CREATE TABLE [dbo].[Employees] (
    [EmployeeID]   INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]    NVARCHAR (50) NOT NULL,
    [LastName]     NVARCHAR (50) NOT NULL,
    [MiddleName]   NVARCHAR (50) NULL,
    [JobTitle]     NVARCHAR (50) NOT NULL,
    [DepartmentID] INT           NOT NULL,
    [ManagerID]    INT           NULL,
    [HireDate]     SMALLDATETIME NOT NULL,
    [Salary]       MONEY         NOT NULL,
    [AddressID]    INT           NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY CLUSTERED ([EmployeeID] ASC),
    CONSTRAINT [FK_Employees_Addresses] FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Addresses] ([AddressID]),
    CONSTRAINT [FK_Employees_Departments] FOREIGN KEY ([DepartmentID]) REFERENCES [dbo].[Departments] ([DepartmentID]) ON DELETE CASCADE,
    CONSTRAINT [FK_Employees_Employees] FOREIGN KEY ([ManagerID]) REFERENCES [dbo].[Employees] ([EmployeeID])
);

