USE [EmployeeDb]
GO

/****** Object:  Table [dbo].[EmployeeSalaries]    Script Date: 8/4/2023 9:40:42 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[EmployeeSalaries](
	[Id] [bigint] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](64) NOT NULL,
	[LastName] [nvarchar](64) NOT NULL,
	[BaseSalary] [bigint] NOT NULL,
	[Allowance] [bigint] NOT NULL,
	[Transportation] [bigint] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
	[ModifiedDate] [datetime2](7) NOT NULL,
	[OverTimeCalculator] [nvarchar](16) NOT NULL,
	[TotalSalary] [bigint] NOT NULL,
 CONSTRAINT [PK_EmployeeSalaries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


