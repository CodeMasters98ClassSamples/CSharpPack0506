USE [CSharpPack0506DB]
GO

/****** Object:  Table [dbo].[Student]    Script Date: 15/08/1405 03:37:48 È.Ù ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Student](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
	[LastName] [nvarchar](100) NOT NULL,
	[MobileNumber] [nvarchar](11) NOT NULL,
	[NationalCode] [nvarchar](10) NOT NULL,
	[BirthDate] [datetime] NULL,
	[LastDocument] [int] NULL,
 CONSTRAINT [PK_Student] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


