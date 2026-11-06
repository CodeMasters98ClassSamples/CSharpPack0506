USE [CSharpPack0506DB]
GO

/****** Object:  Table [dbo].[StudentTerm]    Script Date: 15/08/1405 05:47:28 È.Ù ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StudentTerm](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RegistrationStatus] [int] NOT NULL,
	[RegisteredAt] [datetime] NOT NULL,
	[PaidAmount] [decimal](18, 2) NOT NULL,
	[StudentId] [int] NULL,
	[TermId] [int] NULL,
 CONSTRAINT [PK_StudentTerm] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[StudentTerm] ADD  CONSTRAINT [DF_StudentTerm_RegistrationStatus]  DEFAULT ((1)) FOR [RegistrationStatus]
GO

ALTER TABLE [dbo].[StudentTerm] ADD  CONSTRAINT [DF_StudentTerm_RegisteredAt]  DEFAULT (getdate()) FOR [RegisteredAt]
GO

ALTER TABLE [dbo].[StudentTerm]  WITH CHECK ADD  CONSTRAINT [FK_StudentTerm_Student] FOREIGN KEY([StudentId])
REFERENCES [dbo].[Student] ([Id])
GO

ALTER TABLE [dbo].[StudentTerm] CHECK CONSTRAINT [FK_StudentTerm_Student]
GO

ALTER TABLE [dbo].[StudentTerm]  WITH CHECK ADD  CONSTRAINT [FK_StudentTerm_Term] FOREIGN KEY([TermId])
REFERENCES [dbo].[Term] ([Id])
GO

ALTER TABLE [dbo].[StudentTerm] CHECK CONSTRAINT [FK_StudentTerm_Term]
GO


