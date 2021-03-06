USE [hairsalon]
GO
/****** Object:  Table [dbo].[client]    Script Date: 2/26/16 3:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[client](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[stylist]    Script Date: 2/26/16 3:09:08 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[stylist](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[client] ON 

INSERT [dbo].[client] ([id], [name], [stylist_id]) VALUES (1, N'Taylor', 1)
SET IDENTITY_INSERT [dbo].[client] OFF
SET IDENTITY_INSERT [dbo].[stylist] ON 

INSERT [dbo].[stylist] ([id], [name]) VALUES (1, N'Don')
SET IDENTITY_INSERT [dbo].[stylist] OFF
