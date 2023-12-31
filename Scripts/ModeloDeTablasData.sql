USE [Repository]
GO
/****** Object:  Table [dbo].[Clients]    Script Date: 13/6/2023 21:49:39 ******/
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
/****** Object:  Table [dbo].[Figures]    Script Date: 13/6/2023 21:49:39 ******/
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
/****** Object:  Table [dbo].[LambertianMaterials]    Script Date: 13/6/2023 21:49:39 ******/
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
/****** Object:  Table [dbo].[Materials]    Script Date: 13/6/2023 21:49:39 ******/
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
/****** Object:  Table [dbo].[MetalicMaterials]    Script Date: 13/6/2023 21:49:39 ******/
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
/****** Object:  Table [dbo].[Models]    Script Date: 13/6/2023 21:49:39 ******/
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
/****** Object:  Table [dbo].[PositionatedModels]    Script Date: 13/6/2023 21:49:39 ******/
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
/****** Object:  Table [dbo].[Scenes]    Script Date: 13/6/2023 21:49:39 ******/
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
INSERT [dbo].[Clients] ([Username], [Password], [RegisterDate]) VALUES (N'Carlos', N'Carlos4567', CAST(N'2023-06-09T01:50:23.580' AS DateTime))
INSERT [dbo].[Clients] ([Username], [Password], [RegisterDate]) VALUES (N'Gonza', N'2617Gg', CAST(N'2023-06-09T01:50:08.173' AS DateTime))
INSERT [dbo].[Clients] ([Username], [Password], [RegisterDate]) VALUES (N'Seba', N'Sc1234', CAST(N'2023-06-09T01:49:54.570' AS DateTime))
GO
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Bola', N'Gonza', 1.5)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Bola', N'Seba', 0.5)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Bola de billar', N'Carlos', 2)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Brubuja', N'Seba', 2)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Canica', N'Carlos', 0.5)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Canica', N'Seba', 3)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Chicle', N'Carlos', 1)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Disco', N'Gonza', 2)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Esfera', N'Gonza', 4)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Esfera', N'Seba', 2)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Frambuesa', N'Carlos', 2.5)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Huevo', N'Gonza', 1)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Pompa de jabón', N'Carlos', 3)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Terreno', N'Carlos', 2000)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Terreno', N'Gonza', 2000)
INSERT [dbo].[Figures] ([FigureName], [FigureOwnerId], [Radio]) VALUES (N'Terreno', N'Seba', 2000)
GO
INSERT [dbo].[LambertianMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue]) VALUES (N'Madera', N'Carlos', -7650029)
INSERT [dbo].[LambertianMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue]) VALUES (N'Madera', N'Gonza', -7650029)
INSERT [dbo].[LambertianMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue]) VALUES (N'Pasto', N'Carlos', -16744384)
INSERT [dbo].[LambertianMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue]) VALUES (N'Pasto', N'Gonza', -16744448)
INSERT [dbo].[LambertianMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue]) VALUES (N'Pasto', N'Seba', -16744448)
INSERT [dbo].[LambertianMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue]) VALUES (N'Plastico', N'Gonza', -16776961)
INSERT [dbo].[LambertianMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue]) VALUES (N'Superficie', N'Carlos', -8355585)
INSERT [dbo].[LambertianMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue]) VALUES (N'Tela', N'Seba', -1317211)
GO
INSERT [dbo].[MetalicMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue], [Difuminated]) VALUES (N'Aluminio', N'Carlos', -4144960, 0.7)
INSERT [dbo].[MetalicMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue], [Difuminated]) VALUES (N'Esmeralda', N'Gonza', -16725673, 0.1)
INSERT [dbo].[MetalicMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue], [Difuminated]) VALUES (N'Oro', N'Carlos', -10496, 0)
INSERT [dbo].[MetalicMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue], [Difuminated]) VALUES (N'Perla', N'Seba', -1381917, 0)
INSERT [dbo].[MetalicMaterials] ([MaterialName], [MaterialOwnerId], [ColorValue], [Difuminated]) VALUES (N'Rubi', N'Seba', -8388608, 0.2)
GO
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Bola de aluminio', N'Carlos', N'Bola de billar', N'Carlos', N'Aluminio', N'Carlos', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Bola de juguete', N'Gonza', N'Bola', N'Gonza', N'Plastico', N'Gonza', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Bolita de tela', N'Seba', N'Bola', N'Seba', N'Tela', N'Seba', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Canica de joya', N'Seba', N'Canica', N'Seba', N'Rubi', N'Seba', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Canica de oro', N'Carlos', N'Canica', N'Carlos', N'Oro', N'Carlos', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Canica de perla', N'Seba', N'Canica', N'Seba', N'Perla', N'Seba', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Chicle de superficie', N'Carlos', N'Chicle', N'Carlos', N'Superficie', N'Carlos', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Esfera de perla', N'Seba', N'Esfera', N'Seba', N'Perla', N'Seba', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Frambuesa de pasto', N'Carlos', N'Frambuesa', N'Carlos', N'Pasto', N'Carlos', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Huevo de madera', N'Gonza', N'Huevo', N'Gonza', N'Madera', N'Gonza', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Joya', N'Gonza', N'Esfera', N'Gonza', N'Esmeralda', N'Gonza', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Piso', N'Carlos', N'Terreno', N'Carlos', N'Superficie', N'Carlos', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Planeta', N'Carlos', N'Terreno', N'Carlos', N'Pasto', N'Carlos', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Planeta', N'Gonza', N'Terreno', N'Gonza', N'Pasto', N'Gonza', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Planeta tierra', N'Seba', N'Terreno', N'Seba', N'Pasto', N'Seba', N'none')
INSERT [dbo].[Models] ([ModelName], [ModelOwnerId], [ModelFigureName], [ModelFigureOwnerId], [ModelMaterialName], [ModelMaterialOwnerId], [ModelPreviewPath]) VALUES (N'Pompa de aluminio', N'Carlos', N'Pompa de jabón', N'Carlos', N'Aluminio', N'Carlos', N'none')
GO
SET IDENTITY_INSERT [dbo].[PositionatedModels] ON 

INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (647, 0, -2000, -1, N'Piso', N'Carlos', N'Escena_09062023_024151', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (648, 0, 0.5, -2, N'Canica de oro', N'Carlos', N'Escena_09062023_024151', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (649, -1, 0.5, -2, N'Canica de oro', N'Carlos', N'Escena_09062023_024151', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (650, -1, 2, -10, N'Bola de aluminio', N'Carlos', N'Escena_09062023_024151', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (651, 1, -2000, -1, N'Planeta', N'Carlos', N'Escena_09062023_071537', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (652, 1, 0.5, 6, N'Canica de oro', N'Carlos', N'Escena_09062023_071537', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (653, 0, 0.5, 5, N'Canica de oro', N'Carlos', N'Escena_09062023_071537', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (654, 2, 0.5, 5, N'Canica de oro', N'Carlos', N'Escena_09062023_071537', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (655, 0, 1, 12, N'Chicle de superficie', N'Carlos', N'Escena_09062023_071537', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (656, -3, 2, 15, N'Bola de aluminio', N'Carlos', N'Escena_09062023_071537', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (657, 3, 2.5, 19, N'Frambuesa de pasto', N'Carlos', N'Escena_09062023_071537', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (658, 0, 3, 30, N'Pompa de aluminio', N'Carlos', N'Escena_09062023_071537', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (659, 0, 0.5, 7, N'Canica de oro', N'Carlos', N'Paraiso', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (660, 1, -2000, 1, N'Piso', N'Carlos', N'Paraiso', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (661, -3, 2.5, 14, N'Frambuesa de pasto', N'Carlos', N'Paraiso', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (662, 1, 2, 30, N'Bola de aluminio', N'Carlos', N'Paraiso', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (663, 3, 2.5, 21, N'Pompa de aluminio', N'Carlos', N'Paraiso', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (664, 1, -2000, -1, N'Planeta', N'Carlos', N'Reunion', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (665, 1, 0.5, 9, N'Canica de oro', N'Carlos', N'Reunion', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (666, 3, 1, 9, N'Chicle de superficie', N'Carlos', N'Reunion', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (667, -4, 2, 15, N'Bola de aluminio', N'Carlos', N'Reunion', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (668, 0, 3, 20, N'Pompa de aluminio', N'Carlos', N'Reunion', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (669, -3, 1, 9, N'Chicle de superficie', N'Carlos', N'Reunion', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (670, 4, 2.5, 18, N'Frambuesa de pasto', N'Carlos', N'Reunion', N'Carlos')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (671, -2, -2000, -2, N'Planeta', N'Gonza', N'Escena_09062023_073007', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (672, -1, 1, 8, N'Huevo de madera', N'Gonza', N'Escena_09062023_073007', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (673, 0, 1, 10, N'Huevo de madera', N'Gonza', N'Escena_09062023_073007', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (674, 1, 1, 8, N'Huevo de madera', N'Gonza', N'Escena_09062023_073007', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (675, -3, 3, 20, N'Joya', N'Gonza', N'Escena_09062023_073007', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (676, 3, 1.5, 14, N'Bola de juguete', N'Gonza', N'Escena_09062023_073007', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (677, -5, 1.5, 14, N'Bola de juguete', N'Gonza', N'Escena_09062023_073007', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (678, -1, -2000, -3, N'Planeta', N'Gonza', N'Escena_09062023_074624', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (679, 0, 1.5, 5, N'Bola de juguete', N'Gonza', N'Escena_09062023_074624', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (680, 5.5, 3, 5, N'Joya', N'Gonza', N'Escena_09062023_074624', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (681, 2.5, 1, 5, N'Huevo de madera', N'Gonza', N'Escena_09062023_074624', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (682, 0.5, -2000, -0.5, N'Planeta', N'Gonza', N'Escena_09062023_075354', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (683, 0, 3, 12, N'Joya', N'Gonza', N'Escena_09062023_075354', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (684, 3, 6, 5, N'Bola de juguete', N'Gonza', N'Escena_09062023_075354', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (685, -3, 6, 5, N'Bola de juguete', N'Gonza', N'Escena_09062023_075354', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (686, 0, 1, 5, N'Huevo de madera', N'Gonza', N'Escena_09062023_075354', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (687, -3, -2000, -3, N'Planeta', N'Gonza', N'Espectador', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (688, 0, 1.5, 3, N'Bola de juguete', N'Gonza', N'Espectador', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (689, 4, 3, 12, N'Joya', N'Gonza', N'Espectador', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (690, -1, 3, 12, N'Joya', N'Gonza', N'Espectador', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (691, -0.5, -2000, 1, N'Planeta', N'Gonza', N'Vista helicoptero', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (692, 0, 1, 7, N'Huevo de madera', N'Gonza', N'Vista helicoptero', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (693, 0, 1.5, 12, N'Bola de juguete', N'Gonza', N'Vista helicoptero', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (694, 0, 3, 20, N'Joya', N'Gonza', N'Vista helicoptero', N'Gonza')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (695, 0, -2000, 1, N'Planeta tierra', N'Seba', N'Escena_09062023_033340', N'Seba')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (696, 0, 2, 20, N'Canica de perla', N'Seba', N'Escena_09062023_033340', N'Seba')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (697, 0, -2, 13, N'Canica de joya', N'Seba', N'Escena_09062023_033340', N'Seba')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (698, 0, 1, 9, N'Bolita de tela', N'Seba', N'Escena_09062023_033340', N'Seba')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (699, 0, -2000, 2, N'Planeta tierra', N'Seba', N'Escena_09062023_040203', N'Seba')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (700, 0, 3, 20, N'Canica de joya', N'Seba', N'Escena_09062023_040203', N'Seba')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (701, -4, 1, 13, N'Esfera de perla', N'Seba', N'Escena_09062023_040203', N'Seba')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (702, 4, 1, 13, N'Esfera de perla', N'Seba', N'Escena_09062023_040203', N'Seba')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (703, 0, 0.5, 10, N'Bolita de tela', N'Seba', N'Escena_09062023_040203', N'Seba')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (704, 0, -2000, -1, N'Planeta tierra', N'Seba', N'MiEscena', N'Seba')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (705, 1, 2, -4, N'Canica de joya', N'Seba', N'MiEscena', N'Seba')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (706, 13, 3, -2, N'Canica de perla', N'Seba', N'MiEscena', N'Seba')
INSERT [dbo].[PositionatedModels] ([PositionatedModelId], [PositionX], [PositionY], [PositionZ], [ModelName], [ModelOwnerId], [Scene_SceneName], [Scene_SceneOwnerId]) VALUES (707, -1, -2, 2, N'Canica de perla', N'Seba', N'MiEscena', N'Seba')
SET IDENTITY_INSERT [dbo].[PositionatedModels] OFF
GO
INSERT [dbo].[Scenes] ([SceneName], [SceneOwnerId], [CreationDate], [ModifiedDate], [LastRender], [LookAtX], [LookAtY], [LookAtZ], [LookFromX], [LookFromY], [LookFromZ], [FoV], [ScenePreviewPath], [LensRadius], [Blur]) VALUES (N'Escena_09062023_024151', N'Carlos', CAST(N'2023-06-09T02:41:51.817' AS DateTime), CAST(N'2023-06-09T02:47:15.203' AS DateTime), N'02:47 - 09/06/2023', 0, 0.5, -2, 4, 2, 8, 40, N'none', 0.1, 0)
INSERT [dbo].[Scenes] ([SceneName], [SceneOwnerId], [CreationDate], [ModifiedDate], [LastRender], [LookAtX], [LookAtY], [LookAtZ], [LookFromX], [LookFromY], [LookFromZ], [FoV], [ScenePreviewPath], [LensRadius], [Blur]) VALUES (N'Escena_09062023_033340', N'Seba', CAST(N'2023-06-09T03:33:40.753' AS DateTime), CAST(N'2023-06-09T03:53:15.720' AS DateTime), N'03:53 - 09/06/2023', 0, 2, 5, 0, 2, 0, 30, N'none', 0.1, 0)
INSERT [dbo].[Scenes] ([SceneName], [SceneOwnerId], [CreationDate], [ModifiedDate], [LastRender], [LookAtX], [LookAtY], [LookAtZ], [LookFromX], [LookFromY], [LookFromZ], [FoV], [ScenePreviewPath], [LensRadius], [Blur]) VALUES (N'Escena_09062023_040203', N'Seba', CAST(N'2023-06-09T04:02:03.850' AS DateTime), CAST(N'2023-06-09T04:14:19.947' AS DateTime), N'04:14 - 09/06/2023', 0, 2, 5, 0, 2, 0, 30, N'none', 0.1, 0)
INSERT [dbo].[Scenes] ([SceneName], [SceneOwnerId], [CreationDate], [ModifiedDate], [LastRender], [LookAtX], [LookAtY], [LookAtZ], [LookFromX], [LookFromY], [LookFromZ], [FoV], [ScenePreviewPath], [LensRadius], [Blur]) VALUES (N'Escena_09062023_071537', N'Carlos', CAST(N'2023-06-09T07:15:37.153' AS DateTime), CAST(N'2023-06-09T07:21:11.407' AS DateTime), N'07:21 - 09/06/2023', 0, 2, 5, 0, 2, 0, 50, N'none', 0.1, 0)
INSERT [dbo].[Scenes] ([SceneName], [SceneOwnerId], [CreationDate], [ModifiedDate], [LastRender], [LookAtX], [LookAtY], [LookAtZ], [LookFromX], [LookFromY], [LookFromZ], [FoV], [ScenePreviewPath], [LensRadius], [Blur]) VALUES (N'Escena_09062023_073007', N'Gonza', CAST(N'2023-06-09T07:30:07.617' AS DateTime), CAST(N'2023-06-09T07:34:39.613' AS DateTime), N'07:34 - 09/06/2023', 0, 2, 5, 0, 2, 0, 30, N'none', 0.1, 0)
INSERT [dbo].[Scenes] ([SceneName], [SceneOwnerId], [CreationDate], [ModifiedDate], [LastRender], [LookAtX], [LookAtY], [LookAtZ], [LookFromX], [LookFromY], [LookFromZ], [FoV], [ScenePreviewPath], [LensRadius], [Blur]) VALUES (N'Escena_09062023_074624', N'Gonza', CAST(N'2023-06-09T07:46:24.957' AS DateTime), CAST(N'2023-06-09T07:53:32.963' AS DateTime), N'07:53 - 09/06/2023', 0, 2, 5, 0, 2, -16, 50, N'none', 0.1, 0)
INSERT [dbo].[Scenes] ([SceneName], [SceneOwnerId], [CreationDate], [ModifiedDate], [LastRender], [LookAtX], [LookAtY], [LookAtZ], [LookFromX], [LookFromY], [LookFromZ], [FoV], [ScenePreviewPath], [LensRadius], [Blur]) VALUES (N'Escena_09062023_075354', N'Gonza', CAST(N'2023-06-09T07:53:54.630' AS DateTime), CAST(N'2023-06-09T07:56:37.917' AS DateTime), N'07:56 - 09/06/2023', 0, 2, 5, 0, 2, -10, 40, N'none', 0.1, 0)
INSERT [dbo].[Scenes] ([SceneName], [SceneOwnerId], [CreationDate], [ModifiedDate], [LastRender], [LookAtX], [LookAtY], [LookAtZ], [LookFromX], [LookFromY], [LookFromZ], [FoV], [ScenePreviewPath], [LensRadius], [Blur]) VALUES (N'Espectador', N'Gonza', CAST(N'2023-06-09T07:35:10.107' AS DateTime), CAST(N'2023-06-09T07:41:41.777' AS DateTime), N'07:41 - 09/06/2023', 0, 2, 5, 0, 5, -5, 50, N'none', 0.1, 0)
INSERT [dbo].[Scenes] ([SceneName], [SceneOwnerId], [CreationDate], [ModifiedDate], [LastRender], [LookAtX], [LookAtY], [LookAtZ], [LookFromX], [LookFromY], [LookFromZ], [FoV], [ScenePreviewPath], [LensRadius], [Blur]) VALUES (N'MiEscena', N'Seba', CAST(N'2023-06-09T02:52:20.827' AS DateTime), CAST(N'2023-06-09T03:30:10.143' AS DateTime), N'03:30 - 09/06/2023', 0, 0.6, -1, -12, 1, 7, 30, N'none', 0.1, 1)
INSERT [dbo].[Scenes] ([SceneName], [SceneOwnerId], [CreationDate], [ModifiedDate], [LastRender], [LookAtX], [LookAtY], [LookAtZ], [LookFromX], [LookFromY], [LookFromZ], [FoV], [ScenePreviewPath], [LensRadius], [Blur]) VALUES (N'Paraiso', N'Carlos', CAST(N'2023-06-09T05:56:53.547' AS DateTime), CAST(N'2023-06-09T06:57:51.537' AS DateTime), N'06:57 - 09/06/2023', 0, 2, 5, 0, 2, 0, 30, N'none', 0.1, 1)
INSERT [dbo].[Scenes] ([SceneName], [SceneOwnerId], [CreationDate], [ModifiedDate], [LastRender], [LookAtX], [LookAtY], [LookAtZ], [LookFromX], [LookFromY], [LookFromZ], [FoV], [ScenePreviewPath], [LensRadius], [Blur]) VALUES (N'Reunion', N'Carlos', CAST(N'2023-06-09T07:04:41.517' AS DateTime), CAST(N'2023-06-09T07:15:00.290' AS DateTime), N'07:14 - 09/06/2023', 0, 2, 5, 0, 2, 0, 40, N'none', 0.1, 1)
INSERT [dbo].[Scenes] ([SceneName], [SceneOwnerId], [CreationDate], [ModifiedDate], [LastRender], [LookAtX], [LookAtY], [LookAtZ], [LookFromX], [LookFromY], [LookFromZ], [FoV], [ScenePreviewPath], [LensRadius], [Blur]) VALUES (N'Vista helicoptero', N'Gonza', CAST(N'2023-06-09T07:41:58.917' AS DateTime), CAST(N'2023-06-09T07:45:44.210' AS DateTime), N'07:45 - 09/06/2023', 0, 2, 11, 0, 8, 0, 50, N'none', 0.1, 0)
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
