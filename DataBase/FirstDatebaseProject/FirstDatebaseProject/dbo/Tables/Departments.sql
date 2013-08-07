CREATE TABLE [dbo].[Departments] (
    [DepartmentID] INT           IDENTITY (1, 1) NOT NULL,
    [Name]         NVARCHAR (50) NOT NULL,
    [ManagerID]    INT           NOT NULL,
    CONSTRAINT [PK_Departments] PRIMARY KEY CLUSTERED ([DepartmentID] ASC),
    CONSTRAINT [FK_Departments_Employees] FOREIGN KEY ([ManagerID]) REFERENCES [dbo].[Employees] ([EmployeeID])
);

