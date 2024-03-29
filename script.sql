USE [ArticleShowAddDemo]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 2019/08/04 16:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Articles]    Script Date: 2019/08/04 16:42:20 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Articles](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [nvarchar](60) NOT NULL,
	[Context] [nvarchar](max) NOT NULL,
	[CreateTime] [datetime2](7) NOT NULL,
	[UpdateTime] [datetime2](7) NOT NULL,
	[htmlUrl] [nvarchar](max) NULL,
 CONSTRAINT [PK_Articles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190803031430_first', N'2.1.11-servicing-32099')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20190804012053_second', N'2.1.11-servicing-32099')
SET IDENTITY_INSERT [dbo].[Articles] ON 

INSERT [dbo].[Articles] ([Id], [Title], [Context], [CreateTime], [UpdateTime], [htmlUrl]) VALUES (5, N'测试11', N'<p>我是一个测试</p><p>我是一个测试</p><p><strong>我是一个测试</strong></p><p><em>我是一个测试</em></p><p><em><br/></em></p><p><em><br/></em></p><h1><em><em style="white-space: normal;">我是一个测试</em><em style="white-space: normal;">我是一个测试</em><em style="white-space: normal;">我是一个测试</em></em></h1><p><em><em style="white-space: normal;">拉开放到堆分&nbsp;<br/></em></em></p>', CAST(N'2019-08-04T00:00:00.0000000' AS DateTime2), CAST(N'2019-08-04T09:53:24.0000000' AS DateTime2), NULL)
INSERT [dbo].[Articles] ([Id], [Title], [Context], [CreateTime], [UpdateTime], [htmlUrl]) VALUES (6, N'测试22', N'<p>23232&nbsp;</p><p><br/></p><p><strong>1111</strong></p><p><strong><br/></strong></p><p><em><strong>2222</strong></em></p>', CAST(N'2019-08-04T00:00:00.0000000' AS DateTime2), CAST(N'2019-08-04T16:10:07.0000000' AS DateTime2), N'C:\Users\Xmap00\Desktop\个人网站前端界面系列\编辑器\UEditorNetCore-master\UEditorNetCore-master\UEditorNetCoreExample\bin\Debug\netcoreapp2.1\wwwroot\2019\8\4\6.html')
INSERT [dbo].[Articles] ([Id], [Title], [Context], [CreateTime], [UpdateTime], [htmlUrl]) VALUES (7, N'测试3有图', N'<p>1</p><p>2</p><p>3</p><p>4</p><p>5</p><p style="text-align:center"><img src="/upload/image/20190804/6370051307301545972723289.jpg" title="TIM图片20190623183038.jpg" alt="TIM图片20190623183038.jpg" width="439" height="495"/></p><p><br/></p>', CAST(N'2019-08-04T00:00:00.0000000' AS DateTime2), CAST(N'2019-08-04T15:51:30.0000000' AS DateTime2), NULL)
INSERT [dbo].[Articles] ([Id], [Title], [Context], [CreateTime], [UpdateTime], [htmlUrl]) VALUES (8, N'测试4', N'<p><br/></p><p><br/></p><p style="text-align:center"><img src="/upload/image/20190804/6370051037063548738209182.jpg" title="TIM图片20190623183038.jpg" alt="TIM图片20190623183038.jpg" width="371" height="311"/></p><p><br/></p>', CAST(N'2019-08-04T00:00:00.0000000' AS DateTime2), CAST(N'2019-08-04T15:45:53.0000000' AS DateTime2), NULL)
INSERT [dbo].[Articles] ([Id], [Title], [Context], [CreateTime], [UpdateTime], [htmlUrl]) VALUES (9, N'34234234', N'<p>5345345345445345B&nbsp;</p>', CAST(N'2019-08-04T10:39:31.0000000' AS DateTime2), CAST(N'2019-08-04T10:39:31.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[Articles] OFF
