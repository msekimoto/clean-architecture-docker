USE [teste_webmotors]
GO

/****** Object:  Table [dbo].[tb_anunciowebmotors]    Script Date: 11/09/2019 13:59:09 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tb_anunciowebmotors](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[marca] [varchar](45) NOT NULL,
	[modelo] [varchar](45) NOT NULL,
	[versao] [varchar](45) NOT NULL,
	[ano] [int] NOT NULL,
	[quilometragem] [int] NOT NULL,
	[observacao] [text] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO


