USE [master]
GO
/****** Object:  Database [BookstoreDb]    Script Date: 7/25/2013 5:32:14 PM ******/
CREATE DATABASE [BookstoreDb] 
GO
ALTER DATABASE [BookstoreDb] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BookstoreDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BookstoreDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BookstoreDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BookstoreDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BookstoreDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BookstoreDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [BookstoreDb] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [BookstoreDb] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [BookstoreDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BookstoreDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BookstoreDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BookstoreDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BookstoreDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BookstoreDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BookstoreDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BookstoreDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BookstoreDb] SET  DISABLE_BROKER 
GO
ALTER DATABASE [BookstoreDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BookstoreDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BookstoreDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BookstoreDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BookstoreDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BookstoreDb] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BookstoreDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BookstoreDb] SET RECOVERY FULL 
GO
ALTER DATABASE [BookstoreDb] SET  MULTI_USER 
GO
ALTER DATABASE [BookstoreDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BookstoreDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BookstoreDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BookstoreDb] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'BookstoreDb', N'ON'
GO
USE [BookstoreDb]
GO
/****** Object:  Table [dbo].[Authors]    Script Date: 7/25/2013 5:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Authors](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Authors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
 CONSTRAINT [UK_Name] UNIQUE NONCLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[BookReviews]    Script Date: 7/25/2013 5:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BookReviews](
	[BookId] [int] NOT NULL,
	[ReviewId] [int] NOT NULL,
 CONSTRAINT [PK_BookReviews] PRIMARY KEY CLUSTERED 
(
	[BookId] ASC,
	[ReviewId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Books]    Script Date: 7/25/2013 5:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Books](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[title] [nvarchar](100) NOT NULL,
	[ISBN] [char](13) NULL,
	[Price] [money] NULL,
	[Website] [nvarchar](max) NULL,
 CONSTRAINT [PK_Books] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BooksAuthors]    Script Date: 7/25/2013 5:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BooksAuthors](
	[AuthorId] [int] NOT NULL,
	[BookId] [int] NOT NULL,
 CONSTRAINT [PK_BooksAuthors] PRIMARY KEY CLUSTERED 
(
	[AuthorId] ASC,
	[BookId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Reviews]    Script Date: 7/25/2013 5:32:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Reviews](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateOfCreation] [date] NOT NULL,
	[AuthorId] [int] NULL,
	[Text] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Reviews] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Index [Index_Name]    Script Date: 7/25/2013 5:32:14 PM ******/
CREATE NONCLUSTERED INDEX [Index_Name] ON [dbo].[Books]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BookReviews]  WITH CHECK ADD  CONSTRAINT [FK_BookReviews_Books1] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[BookReviews] CHECK CONSTRAINT [FK_BookReviews_Books1]
GO
ALTER TABLE [dbo].[BookReviews]  WITH CHECK ADD  CONSTRAINT [FK_BookReviews_Reviews1] FOREIGN KEY([ReviewId])
REFERENCES [dbo].[Reviews] ([Id])
GO
ALTER TABLE [dbo].[BookReviews] CHECK CONSTRAINT [FK_BookReviews_Reviews1]
GO
ALTER TABLE [dbo].[BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_Authors] FOREIGN KEY([AuthorId])
REFERENCES [dbo].[Authors] ([Id])
GO
ALTER TABLE [dbo].[BooksAuthors] CHECK CONSTRAINT [FK_BooksAuthors_Authors]
GO
ALTER TABLE [dbo].[BooksAuthors]  WITH CHECK ADD  CONSTRAINT [FK_BooksAuthors_Books] FOREIGN KEY([BookId])
REFERENCES [dbo].[Books] ([Id])
GO
ALTER TABLE [dbo].[BooksAuthors] CHECK CONSTRAINT [FK_BooksAuthors_Books]
GO
USE [master]
GO
ALTER DATABASE [BookstoreDb] SET  READ_WRITE 
GO
