USE [Repository]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 9/6/2023 1:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clients](
	[Username] [nvarchar](128) NOT NULL,
	[Password] [nvarchar](max) NULL,
	[RegisterDate] [datetime] NOT NULL,
 CONSTRAINT [PK_dbo.Clients] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Figures]    Script Date: 9/6/2023 1:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Figures](
	[FigureName] [nvarchar](128) NOT NULL,
	[FigureOwnerId] [nvarchar](128) NOT NULL,
	[Radio] [float] NOT NULL,
 CONSTRAINT [PK_dbo.Figures] PRIMARY KEY CLUSTERED 
(
	[FigureName] ASC,
	[FigureOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LambertianMaterials]    Script Date: 9/6/2023 1:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LambertianMaterials](
	[MaterialName] [nvarchar](128) NOT NULL,
	[MaterialOwnerId] [nvarchar](128) NOT NULL,
	[ColorValue] [int] NOT NULL,
 CONSTRAINT [PK_dbo.LambertianMaterials] PRIMARY KEY CLUSTERED 
(
	[MaterialName] ASC,
	[MaterialOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Materials]    Script Date: 9/6/2023 1:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Materials](
	[MaterialName] [nvarchar](128) NOT NULL,
	[MaterialOwnerId] [nvarchar](128) NOT NULL,
	[ColorValue] [int] NOT NULL,
 CONSTRAINT [PK_dbo.Materials] PRIMARY KEY CLUSTERED 
(
	[MaterialName] ASC,
	[MaterialOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MetalicMaterials]    Script Date: 9/6/2023 1:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MetalicMaterials](
	[MaterialName] [nvarchar](128) NOT NULL,
	[MaterialOwnerId] [nvarchar](128) NOT NULL,
	[ColorValue] [int] NOT NULL,
	[Difuminated] [float] NOT NULL,
 CONSTRAINT [PK_dbo.MetalicMaterials] PRIMARY KEY CLUSTERED 
(
	[MaterialName] ASC,
	[MaterialOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Models]    Script Date: 9/6/2023 1:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Models](
	[ModelName] [nvarchar](128) NOT NULL,
	[ModelOwnerId] [nvarchar](128) NOT NULL,
	[ModelFigureName] [nvarchar](128) NOT NULL,
	[ModelFigureOwnerId] [nvarchar](128) NOT NULL,
	[ModelMaterialName] [nvarchar](128) NOT NULL,
	[ModelMaterialOwnerId] [nvarchar](128) NOT NULL,
	[ModelPreviewPath] [nvarchar](max) NULL,
 CONSTRAINT [PK_dbo.Models] PRIMARY KEY CLUSTERED 
(
	[ModelName] ASC,
	[ModelOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PositionatedModels]    Script Date: 9/6/2023 1:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PositionatedModels](
	[PositionatedModelId] [int] IDENTITY(1,1) NOT NULL,
	[PositionX] [float] NOT NULL,
	[PositionY] [float] NOT NULL,
	[PositionZ] [float] NOT NULL,
	[ModelName] [nvarchar](128) NOT NULL,
	[ModelOwnerId] [nvarchar](128) NOT NULL,
	[Scene_SceneName] [nvarchar](128) NULL,
	[Scene_SceneOwnerId] [nvarchar](128) NULL,
 CONSTRAINT [PK_dbo.PositionatedModels] PRIMARY KEY CLUSTERED 
(
	[PositionatedModelId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Scenes]    Script Date: 9/6/2023 1:47:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Scenes](
	[SceneName] [nvarchar](128) NOT NULL,
	[SceneOwnerId] [nvarchar](128) NOT NULL,
	[CreationDate] [datetime] NOT NULL,
	[ModifiedDate] [datetime] NOT NULL,
	[LastRender] [nvarchar](max) NULL,
	[LookAtX] [float] NOT NULL,
	[LookAtY] [float] NOT NULL,
	[LookAtZ] [float] NOT NULL,
	[LookFromX] [float] NOT NULL,
	[LookFromY] [float] NOT NULL,
	[LookFromZ] [float] NOT NULL,
	[FoV] [int] NOT NULL,
	[ScenePreviewPath] [nvarchar](max) NULL,
	[LensRadius] [float] NOT NULL,
	[Blur] [bit] NOT NULL,
 CONSTRAINT [PK_dbo.Scenes] PRIMARY KEY CLUSTERED 
(
	[SceneName] ASC,
	[SceneOwnerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[Figures]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Figures_dbo.Clients_FigureOwnerId] FOREIGN KEY([FigureOwnerId])
REFERENCES [dbo].[Clients] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Figures] CHECK CONSTRAINT [FK_dbo.Figures_dbo.Clients_FigureOwnerId]
GO
ALTER TABLE [dbo].[LambertianMaterials]  WITH CHECK ADD  CONSTRAINT [FK_dbo.LambertianMaterials_dbo.Clients_MaterialOwnerId] FOREIGN KEY([MaterialOwnerId])
REFERENCES [dbo].[Clients] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[LambertianMaterials] CHECK CONSTRAINT [FK_dbo.LambertianMaterials_dbo.Clients_MaterialOwnerId]
GO
ALTER TABLE [dbo].[Materials]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Materials_dbo.Clients_MaterialOwnerId] FOREIGN KEY([MaterialOwnerId])
REFERENCES [dbo].[Clients] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Materials] CHECK CONSTRAINT [FK_dbo.Materials_dbo.Clients_MaterialOwnerId]
GO
ALTER TABLE [dbo].[MetalicMaterials]  WITH CHECK ADD  CONSTRAINT [FK_dbo.MetalicMaterials_dbo.Clients_MaterialOwnerId] FOREIGN KEY([MaterialOwnerId])
REFERENCES [dbo].[Clients] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MetalicMaterials] CHECK CONSTRAINT [FK_dbo.MetalicMaterials_dbo.Clients_MaterialOwnerId]
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Models_dbo.Clients_ModelOwnerId] FOREIGN KEY([ModelOwnerId])
REFERENCES [dbo].[Clients] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [FK_dbo.Models_dbo.Clients_ModelOwnerId]
GO
ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Models_dbo.Figures_ModelFigureName_ModelFigureOwnerId] FOREIGN KEY([ModelFigureName], [ModelFigureOwnerId])
REFERENCES [dbo].[Figures] ([FigureName], [FigureOwnerId])
GO
ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [FK_dbo.Models_dbo.Figures_ModelFigureName_ModelFigureOwnerId]
GO
ALTER TABLE [dbo].[PositionatedModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PositionatedModels_dbo.Models_ModelName_ModelOwnerId] FOREIGN KEY([ModelName], [ModelOwnerId])
REFERENCES [dbo].[Models] ([ModelName], [ModelOwnerId])
GO
ALTER TABLE [dbo].[PositionatedModels] CHECK CONSTRAINT [FK_dbo.PositionatedModels_dbo.Models_ModelName_ModelOwnerId]
GO
ALTER TABLE [dbo].[PositionatedModels]  WITH CHECK ADD  CONSTRAINT [FK_dbo.PositionatedModels_dbo.Scenes_Scene_SceneName_Scene_SceneOwnerId] FOREIGN KEY([Scene_SceneName], [Scene_SceneOwnerId])
REFERENCES [dbo].[Scenes] ([SceneName], [SceneOwnerId])
GO
ALTER TABLE [dbo].[PositionatedModels] CHECK CONSTRAINT [FK_dbo.PositionatedModels_dbo.Scenes_Scene_SceneName_Scene_SceneOwnerId]
GO
ALTER TABLE [dbo].[Scenes]  WITH CHECK ADD  CONSTRAINT [FK_dbo.Scenes_dbo.Clients_SceneOwnerId] FOREIGN KEY([SceneOwnerId])
REFERENCES [dbo].[Clients] ([Username])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Scenes] CHECK CONSTRAINT [FK_dbo.Scenes_dbo.Clients_SceneOwnerId]
GO
