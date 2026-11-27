	USE [CSharpPack0506DB]
	GO

	/****** Object:  Table [dbo].[Course]    Script Date: 15/08/1405 05:48:28 È.Ù ******/
	SET ANSI_NULLS ON
	GO

	SET QUOTED_IDENTIFIER ON
	GO

	CREATE TABLE [dbo].[Course](
		[Id] [int] IDENTITY(1,1) NOT NULL,
		[Name] [nvarchar](250) NOT NULL,
		[Description] [nvarchar](500) NULL,
		[Link] [nvarchar](250) NULL,
		[MasterId] [int] NULL,
	 CONSTRAINT [PK_Course] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	GO

	ALTER TABLE [dbo].[Course]  WITH CHECK ADD  CONSTRAINT [FK_Course_Master] FOREIGN KEY([MasterId])
	REFERENCES [dbo].[Master] ([Id])
	GO

	ALTER TABLE [dbo].[Course] CHECK CONSTRAINT [FK_Course_Master]
	GO


