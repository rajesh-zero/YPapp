USE [master]
GO
/****** Object:  Database [YouPaper]    Script Date: 15-04-2018 04:53:05 PM ******/
CREATE DATABASE [YouPaper]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'YouPaper', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\YouPaper.mdf' , SIZE = 4096KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'YouPaper_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\YouPaper_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [YouPaper] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [YouPaper].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [YouPaper] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [YouPaper] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [YouPaper] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [YouPaper] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [YouPaper] SET ARITHABORT OFF 
GO
ALTER DATABASE [YouPaper] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [YouPaper] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [YouPaper] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [YouPaper] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [YouPaper] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [YouPaper] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [YouPaper] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [YouPaper] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [YouPaper] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [YouPaper] SET  DISABLE_BROKER 
GO
ALTER DATABASE [YouPaper] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [YouPaper] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [YouPaper] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [YouPaper] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [YouPaper] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [YouPaper] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [YouPaper] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [YouPaper] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [YouPaper] SET  MULTI_USER 
GO
ALTER DATABASE [YouPaper] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [YouPaper] SET DB_CHAINING OFF 
GO
ALTER DATABASE [YouPaper] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [YouPaper] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [YouPaper] SET DELAYED_DURABILITY = DISABLED 
GO
USE [YouPaper]
GO
/****** Object:  Table [dbo].[admin]    Script Date: 15-04-2018 04:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[admin](
	[auid] [int] IDENTITY(1,1) NOT NULL,
	[ausername] [nvarchar](50) NULL,
	[apassword] [nvarchar](50) NULL,
 CONSTRAINT [PK_admin] PRIMARY KEY CLUSTERED 
(
	[auid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[article]    Script Date: 15-04-2018 04:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[article](
	[artid] [int] IDENTITY(1,1) NOT NULL,
	[chid] [int] NOT NULL,
	[cid] [int] NOT NULL,
	[heading] [nvarchar](250) NOT NULL,
	[articlebody] [nvarchar](max) NULL,
	[thumbnail] [nvarchar](50) NULL,
	[postedon] [datetime] NULL,
	[likes] [int] NULL,
	[dislikes] [int] NULL,
	[views] [int] NULL,
 CONSTRAINT [PK_article] PRIMARY KEY CLUSTERED 
(
	[artid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[category]    Script Date: 15-04-2018 04:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[category](
	[cid] [int] IDENTITY(1,1) NOT NULL,
	[cname] [nvarchar](50) NOT NULL,
	[cdescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_category] PRIMARY KEY CLUSTERED 
(
	[cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[channel]    Script Date: 15-04-2018 04:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[channel](
	[chid] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NOT NULL,
	[chname] [nvarchar](50) NOT NULL,
	[chdescription] [nvarchar](max) NULL,
	[chart] [nvarchar](50) NULL,
	[chimage] [nvarchar](50) NULL,
	[chcreatedon] [date] NULL,
	[status] [char](1) NULL,
 CONSTRAINT [PK_channel] PRIMARY KEY CLUSTERED 
(
	[chid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[comments]    Script Date: 15-04-2018 04:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[comments](
	[commentid] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NOT NULL,
	[artid] [int] NOT NULL,
	[comment] [nvarchar](max) NOT NULL,
	[postedon] [datetime] NULL,
 CONSTRAINT [PK_comments] PRIMARY KEY CLUSTERED 
(
	[commentid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[draftarticle]    Script Date: 15-04-2018 04:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[draftarticle](
	[artid] [int] IDENTITY(1,1) NOT NULL,
	[cid] [int] NOT NULL,
	[chid] [int] NOT NULL,
	[heading] [nvarchar](250) NOT NULL,
	[thumbnail] [nvarchar](50) NULL,
	[articlebody] [nvarchar](max) NULL,
	[createdon] [datetime] NULL,
 CONSTRAINT [PK_draftarticle] PRIMARY KEY CLUSTERED 
(
	[artid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[likedislike]    Script Date: 15-04-2018 04:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[likedislike](
	[ldid] [int] IDENTITY(1,1) NOT NULL,
	[uid] [int] NOT NULL,
	[artid] [int] NOT NULL,
	[reaction] [char](1) NOT NULL,
 CONSTRAINT [PK_likedislike] PRIMARY KEY CLUSTERED 
(
	[ldid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[passwordchangerequest]    Script Date: 15-04-2018 04:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[passwordchangerequest](
	[id] [uniqueidentifier] NOT NULL,
	[uid] [int] NOT NULL,
	[requestdatetime] [datetime] NULL,
 CONSTRAINT [PK_passwordchangerequest] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[reports]    Script Date: 15-04-2018 04:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[reports](
	[rid] [int] IDENTITY(1,1) NOT NULL,
	[artid] [int] NOT NULL,
	[uid] [int] NOT NULL,
	[description] [nvarchar](max) NULL,
 CONSTRAINT [PK_reports] PRIMARY KEY CLUSTERED 
(
	[rid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[subscribers]    Script Date: 15-04-2018 04:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[subscribers](
	[sid] [int] IDENTITY(1,1) NOT NULL,
	[chid] [int] NOT NULL,
	[uid] [int] NOT NULL,
	[subscribedon] [datetime] NULL,
 CONSTRAINT [PK_subscribers] PRIMARY KEY CLUSTERED 
(
	[sid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[userprofile]    Script Date: 15-04-2018 04:53:05 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[userprofile](
	[uid] [int] IDENTITY(1,1) NOT NULL,
	[uemail] [nvarchar](50) NOT NULL,
	[upassword] [nvarchar](50) NULL,
	[umobile] [nvarchar](50) NULL,
	[uname] [nvarchar](50) NULL,
	[ugender] [char](1) NULL,
	[uprofilepic] [nvarchar](50) NULL,
	[udob] [date] NULL,
	[uregisteredon] [date] NULL,
	[udescription] [nvarchar](max) NULL,
	[ucountry] [nvarchar](50) NULL,
	[ustatus] [char](1) NULL,
 CONSTRAINT [PK_userprofile] PRIMARY KEY CLUSTERED 
(
	[uid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[passwordchangerequest] ADD  CONSTRAINT [DF_passwordchangerequest_id]  DEFAULT (newid()) FOR [id]
GO
ALTER TABLE [dbo].[article]  WITH CHECK ADD  CONSTRAINT [FK_article_category] FOREIGN KEY([cid])
REFERENCES [dbo].[category] ([cid])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[article] CHECK CONSTRAINT [FK_article_category]
GO
ALTER TABLE [dbo].[article]  WITH CHECK ADD  CONSTRAINT [FK_article_channel] FOREIGN KEY([chid])
REFERENCES [dbo].[channel] ([chid])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[article] CHECK CONSTRAINT [FK_article_channel]
GO
ALTER TABLE [dbo].[channel]  WITH CHECK ADD  CONSTRAINT [FK_channel_userprofile] FOREIGN KEY([uid])
REFERENCES [dbo].[userprofile] ([uid])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[channel] CHECK CONSTRAINT [FK_channel_userprofile]
GO
ALTER TABLE [dbo].[comments]  WITH CHECK ADD  CONSTRAINT [FK_comments_article] FOREIGN KEY([artid])
REFERENCES [dbo].[article] ([artid])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[comments] CHECK CONSTRAINT [FK_comments_article]
GO
ALTER TABLE [dbo].[draftarticle]  WITH CHECK ADD  CONSTRAINT [FK_draftarticle_channel] FOREIGN KEY([chid])
REFERENCES [dbo].[channel] ([chid])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[draftarticle] CHECK CONSTRAINT [FK_draftarticle_channel]
GO
ALTER TABLE [dbo].[likedislike]  WITH CHECK ADD  CONSTRAINT [FK_likedislike_article] FOREIGN KEY([artid])
REFERENCES [dbo].[article] ([artid])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[likedislike] CHECK CONSTRAINT [FK_likedislike_article]
GO
ALTER TABLE [dbo].[passwordchangerequest]  WITH CHECK ADD  CONSTRAINT [FK_passwordchangerequest_userprofile] FOREIGN KEY([uid])
REFERENCES [dbo].[userprofile] ([uid])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[passwordchangerequest] CHECK CONSTRAINT [FK_passwordchangerequest_userprofile]
GO
ALTER TABLE [dbo].[reports]  WITH CHECK ADD  CONSTRAINT [FK_reports_article] FOREIGN KEY([artid])
REFERENCES [dbo].[article] ([artid])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[reports] CHECK CONSTRAINT [FK_reports_article]
GO
ALTER TABLE [dbo].[reports]  WITH CHECK ADD  CONSTRAINT [FK_reports_userprofile] FOREIGN KEY([uid])
REFERENCES [dbo].[userprofile] ([uid])
GO
ALTER TABLE [dbo].[reports] CHECK CONSTRAINT [FK_reports_userprofile]
GO
ALTER TABLE [dbo].[subscribers]  WITH CHECK ADD  CONSTRAINT [FK_subscribers_userprofile] FOREIGN KEY([uid])
REFERENCES [dbo].[userprofile] ([uid])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[subscribers] CHECK CONSTRAINT [FK_subscribers_userprofile]
GO
USE [master]
GO
ALTER DATABASE [YouPaper] SET  READ_WRITE 
GO
