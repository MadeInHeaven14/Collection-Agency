USE [CollectionAgency]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 29.04.2023 14:33:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[ID_Client] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [varchar](50) NOT NULL,
	[Collector_ID] [int] NOT NULL,
	[Address] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[ID_Client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Collector]    Script Date: 29.04.2023 14:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Collector](
	[ID_Collector] [int] IDENTITY(1,1) NOT NULL,
	[FIO] [varchar](50) NOT NULL,
	[Login] [varchar](10) NOT NULL,
	[Password] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Collector] PRIMARY KEY CLUSTERED 
(
	[ID_Collector] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Debt]    Script Date: 29.04.2023 14:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Debt](
	[ID_Debt] [int] IDENTITY(1,1) NOT NULL,
	[Sum] [float] NOT NULL,
	[Percent] [int] NOT NULL,
 CONSTRAINT [PK_Debt] PRIMARY KEY CLUSTERED 
(
	[ID_Debt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Debt_Client]    Script Date: 29.04.2023 14:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Debt_Client](
	[ID_Debt_Client] [int] IDENTITY(1,1) NOT NULL,
	[Debt_ID] [int] NOT NULL,
	[Client_ID] [int] NOT NULL,
	[Debt_Finish_ID] [int] NOT NULL,
 CONSTRAINT [PK_Debt_Client] PRIMARY KEY CLUSTERED 
(
	[ID_Debt_Client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Debt_Finish]    Script Date: 29.04.2023 14:33:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Debt_Finish](
	[ID_Debt_Finish] [int] NOT NULL,
	[Is_Debt_Finish] [varchar](10) NOT NULL,
 CONSTRAINT [PK_Debt_Finish] PRIMARY KEY CLUSTERED 
(
	[ID_Debt_Finish] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Client] ON 

INSERT [dbo].[Client] ([ID_Client], [FIO], [Collector_ID], [Address]) VALUES (5, N'q', 1, N'q')
INSERT [dbo].[Client] ([ID_Client], [FIO], [Collector_ID], [Address]) VALUES (8, N'f', 1, N'f')
SET IDENTITY_INSERT [dbo].[Client] OFF
GO
SET IDENTITY_INSERT [dbo].[Collector] ON 

INSERT [dbo].[Collector] ([ID_Collector], [FIO], [Login], [Password]) VALUES (0, N'Иванов Иван Иванович', N'login', N'123')
INSERT [dbo].[Collector] ([ID_Collector], [FIO], [Login], [Password]) VALUES (1, N'qwe', N'qwe', N'qwe')
SET IDENTITY_INSERT [dbo].[Collector] OFF
GO
SET IDENTITY_INSERT [dbo].[Debt] ON 

INSERT [dbo].[Debt] ([ID_Debt], [Sum], [Percent]) VALUES (1, 200, 2)
INSERT [dbo].[Debt] ([ID_Debt], [Sum], [Percent]) VALUES (4, 1, 1)
SET IDENTITY_INSERT [dbo].[Debt] OFF
GO
SET IDENTITY_INSERT [dbo].[Debt_Client] ON 

INSERT [dbo].[Debt_Client] ([ID_Debt_Client], [Debt_ID], [Client_ID], [Debt_Finish_ID]) VALUES (1, 1, 5, 2)
INSERT [dbo].[Debt_Client] ([ID_Debt_Client], [Debt_ID], [Client_ID], [Debt_Finish_ID]) VALUES (4, 4, 8, 2)
SET IDENTITY_INSERT [dbo].[Debt_Client] OFF
GO
INSERT [dbo].[Debt_Finish] ([ID_Debt_Finish], [Is_Debt_Finish]) VALUES (1, N'Да')
INSERT [dbo].[Debt_Finish] ([ID_Debt_Finish], [Is_Debt_Finish]) VALUES (2, N'Нет')
GO
ALTER TABLE [dbo].[Client]  WITH CHECK ADD  CONSTRAINT [FK_Client_Collector] FOREIGN KEY([Collector_ID])
REFERENCES [dbo].[Collector] ([ID_Collector])
GO
ALTER TABLE [dbo].[Client] CHECK CONSTRAINT [FK_Client_Collector]
GO
ALTER TABLE [dbo].[Debt_Client]  WITH CHECK ADD  CONSTRAINT [FK_Debt_Client_Client] FOREIGN KEY([Client_ID])
REFERENCES [dbo].[Client] ([ID_Client])
GO
ALTER TABLE [dbo].[Debt_Client] CHECK CONSTRAINT [FK_Debt_Client_Client]
GO
ALTER TABLE [dbo].[Debt_Client]  WITH CHECK ADD  CONSTRAINT [FK_Debt_Client_Debt] FOREIGN KEY([Debt_ID])
REFERENCES [dbo].[Debt] ([ID_Debt])
GO
ALTER TABLE [dbo].[Debt_Client] CHECK CONSTRAINT [FK_Debt_Client_Debt]
GO
ALTER TABLE [dbo].[Debt_Client]  WITH CHECK ADD  CONSTRAINT [FK_Debt_Client_Debt_Finish] FOREIGN KEY([Debt_Finish_ID])
REFERENCES [dbo].[Debt_Finish] ([ID_Debt_Finish])
GO
ALTER TABLE [dbo].[Debt_Client] CHECK CONSTRAINT [FK_Debt_Client_Debt_Finish]
GO
