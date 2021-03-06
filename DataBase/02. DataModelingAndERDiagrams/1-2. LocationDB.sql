USE [master]
GO
/****** Object:  Database [LocationDB]    Script Date: 7/10/2013 12:34:39 AM ******/
CREATE DATABASE [LocationDB]
GO
ALTER DATABASE [LocationDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [LocationDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [LocationDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [LocationDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [LocationDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [LocationDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [LocationDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [LocationDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [LocationDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [LocationDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [LocationDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [LocationDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [LocationDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [LocationDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [LocationDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [LocationDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [LocationDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [LocationDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [LocationDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [LocationDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [LocationDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [LocationDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [LocationDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [LocationDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [LocationDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [LocationDB] SET RECOVERY FULL 
GO
ALTER DATABASE [LocationDB] SET  MULTI_USER 
GO
ALTER DATABASE [LocationDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [LocationDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [LocationDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [LocationDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'LocationDB', N'ON'
GO
USE [LocationDB]
GO
/****** Object:  Table [dbo].[Adress]    Script Date: 7/10/2013 12:34:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Adress](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Address_text] [text] NOT NULL,
	[TownID] [int] NOT NULL,
 CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Continents]    Script Date: 7/10/2013 12:34:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Continents](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Countries]    Script Date: 7/10/2013 12:34:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Countries](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[ContinentId] [int] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[People]    Script Date: 7/10/2013 12:34:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[People](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[First_Name] [varchar](50) NOT NULL,
	[Last_Name] [varchar](50) NOT NULL,
	[AddressId] [int] NOT NULL,
 CONSTRAINT [PK_People] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Town]    Script Date: 7/10/2013 12:34:39 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Town](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[CountryID] [int] NOT NULL,
 CONSTRAINT [PK_Town] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Adress] ON 

GO
INSERT [dbo].[Adress] ([Id], [Address_text], [TownID]) VALUES (1, N'Address in Sofia', 1)
GO
INSERT [dbo].[Adress] ([Id], [Address_text], [TownID]) VALUES (2, N'Address in  Tokyo', 2)
GO
INSERT [dbo].[Adress] ([Id], [Address_text], [TownID]) VALUES (3, N'Address in Boston', 3)
GO
INSERT [dbo].[Adress] ([Id], [Address_text], [TownID]) VALUES (4, N'Address in Cairo', 4)
GO
INSERT [dbo].[Adress] ([Id], [Address_text], [TownID]) VALUES (5, N'Address in Paris', 5)
GO
INSERT [dbo].[Adress] ([Id], [Address_text], [TownID]) VALUES (6, N'Address in Otava', 6)
GO
SET IDENTITY_INSERT [dbo].[Adress] OFF
GO
SET IDENTITY_INSERT [dbo].[Continents] ON 

GO
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (1, N'Europe')
GO
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (2, N'Asia')
GO
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (3, N'North America')
GO
INSERT [dbo].[Continents] ([Id], [Name]) VALUES (4, N'Africa')
GO
SET IDENTITY_INSERT [dbo].[Continents] OFF
GO
SET IDENTITY_INSERT [dbo].[Countries] ON 

GO
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (1, N'Bulgaria', 1)
GO
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (2, N'Japan', 2)
GO
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (3, N'USA', 3)
GO
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (4, N'Egypt', 4)
GO
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (5, N'France', 1)
GO
INSERT [dbo].[Countries] ([Id], [Name], [ContinentId]) VALUES (6, N'Canada', 3)
GO
SET IDENTITY_INSERT [dbo].[Countries] OFF
GO
SET IDENTITY_INSERT [dbo].[People] ON 

GO
INSERT [dbo].[People] ([Id], [First_Name], [Last_Name], [AddressId]) VALUES (1, N'Sofia', N'Sofia', 1)
GO
INSERT [dbo].[People] ([Id], [First_Name], [Last_Name], [AddressId]) VALUES (2, N'Tokyo', N'Tokyo', 2)
GO
INSERT [dbo].[People] ([Id], [First_Name], [Last_Name], [AddressId]) VALUES (3, N'Boston', N'Boston', 3)
GO
INSERT [dbo].[People] ([Id], [First_Name], [Last_Name], [AddressId]) VALUES (4, N'Cairo', N'Cairo', 4)
GO
INSERT [dbo].[People] ([Id], [First_Name], [Last_Name], [AddressId]) VALUES (5, N'Paris', N'Paris', 5)
GO
INSERT [dbo].[People] ([Id], [First_Name], [Last_Name], [AddressId]) VALUES (6, N'Otava', N'Otava', 6)
GO
SET IDENTITY_INSERT [dbo].[People] OFF
GO
SET IDENTITY_INSERT [dbo].[Town] ON 

GO
INSERT [dbo].[Town] ([Id], [Name], [CountryID]) VALUES (1, N'Sofia', 1)
GO
INSERT [dbo].[Town] ([Id], [Name], [CountryID]) VALUES (2, N'Tokyo', 2)
GO
INSERT [dbo].[Town] ([Id], [Name], [CountryID]) VALUES (3, N'Boston', 3)
GO
INSERT [dbo].[Town] ([Id], [Name], [CountryID]) VALUES (4, N'Cairo', 4)
GO
INSERT [dbo].[Town] ([Id], [Name], [CountryID]) VALUES (5, N'Paris', 5)
GO
INSERT [dbo].[Town] ([Id], [Name], [CountryID]) VALUES (6, N'Otava', 6)
GO
SET IDENTITY_INSERT [dbo].[Town] OFF
GO
ALTER TABLE [dbo].[Adress]  WITH CHECK ADD  CONSTRAINT [FK_Adress_Town] FOREIGN KEY([TownID])
REFERENCES [dbo].[Town] ([Id])
GO
ALTER TABLE [dbo].[Adress] CHECK CONSTRAINT [FK_Adress_Town]
GO
ALTER TABLE [dbo].[Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Continents] FOREIGN KEY([ContinentId])
REFERENCES [dbo].[Continents] ([Id])
GO
ALTER TABLE [dbo].[Countries] CHECK CONSTRAINT [FK_Countries_Continents]
GO
ALTER TABLE [dbo].[People]  WITH CHECK ADD  CONSTRAINT [FK_People_Adress] FOREIGN KEY([AddressId])
REFERENCES [dbo].[Adress] ([Id])
GO
ALTER TABLE [dbo].[People] CHECK CONSTRAINT [FK_People_Adress]
GO
ALTER TABLE [dbo].[Town]  WITH CHECK ADD  CONSTRAINT [FK_Town_Countries] FOREIGN KEY([CountryID])
REFERENCES [dbo].[Countries] ([Id])
GO
ALTER TABLE [dbo].[Town] CHECK CONSTRAINT [FK_Town_Countries]
GO
USE [master]
GO
ALTER DATABASE [LocationDB] SET  READ_WRITE 
GO
