USE [master]
GO
/****** Object:  Database [car_project]    Script Date: 20/05/2021 14:57:17 ******/
CREATE DATABASE [car_project]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'car_project', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\car_project.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'car_project_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\car_project_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [car_project] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [car_project].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [car_project] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [car_project] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [car_project] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [car_project] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [car_project] SET ARITHABORT OFF 
GO
ALTER DATABASE [car_project] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [car_project] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [car_project] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [car_project] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [car_project] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [car_project] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [car_project] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [car_project] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [car_project] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [car_project] SET  DISABLE_BROKER 
GO
ALTER DATABASE [car_project] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [car_project] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [car_project] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [car_project] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [car_project] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [car_project] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [car_project] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [car_project] SET RECOVERY FULL 
GO
ALTER DATABASE [car_project] SET  MULTI_USER 
GO
ALTER DATABASE [car_project] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [car_project] SET DB_CHAINING OFF 
GO
ALTER DATABASE [car_project] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [car_project] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [car_project] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [car_project] SET QUERY_STORE = OFF
GO
USE [car_project]
GO
/****** Object:  Table [dbo].[car]    Script Date: 20/05/2021 14:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[car](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NULL,
	[numOfSeats] [int] NULL,
	[carNumber] [int] NOT NULL,
	[numOfAvailableSeats] [int] NULL,
 CONSTRAINT [PK_car] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[gender]    Script Date: 20/05/2021 14:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[gender](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[description] [nvarchar](10) NULL,
 CONSTRAINT [PK_gender] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[regularTraveling]    Script Date: 20/05/2021 14:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[regularTraveling](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[driverId] [int] NULL,
	[source] [nvarchar](50) NULL,
	[destination] [nvarchar](50) NULL,
	[exitTime] [time](7) NULL,
	[arriveTime] [time](7) NULL,
	[day] [int] NULL,
 CONSTRAINT [PK_regularTraveling] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[temporaryTraveling]    Script Date: 20/05/2021 14:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[temporaryTraveling](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[driverId] [int] NULL,
	[source] [nvarchar](50) NULL,
	[destination] [nvarchar](50) NULL,
	[exitTime] [time](7) NULL,
	[arriveTime] [time](7) NULL,
	[date] [date] NULL,
 CONSTRAINT [PK_temporaryTraveling] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[temporaryTraveller]    Script Date: 20/05/2021 14:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[temporaryTraveller](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NULL,
	[travelId] [int] NULL,
	[travellerId] [int] NULL,
	[collectionPoint] [nvarchar](50) NULL,
	[destinationPoint] [nvarchar](50) NULL,
	[isRegular] [bit] NULL,
 CONSTRAINT [PK_temporaryTraveller] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[travellerInRegularTravel]    Script Date: 20/05/2021 14:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[travellerInRegularTravel](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[regularTravelingId] [int] NULL,
	[travelerId] [int] NULL,
	[collectingPoint] [nvarchar](50) NULL,
	[destinationPoint] [nvarchar](50) NULL,
 CONSTRAINT [PK_travellerInRegularTravel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 20/05/2021 14:57:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[firstName] [nvarchar](20) NULL,
	[lastName] [nvarchar](20) NULL,
	[userName] [nvarchar](20) NULL,
	[password] [nvarchar](20) NULL,
	[tel] [nvarchar](20) NULL,
	[mail] [nvarchar](30) NULL,
	[genderId] [int] NULL,
	[points] [int] NULL,
	[isHasCar] [bit] NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[gender] ON 

INSERT [dbo].[gender] ([id], [description]) VALUES (1, N'זכר')
INSERT [dbo].[gender] ([id], [description]) VALUES (2, N'נקבה')
SET IDENTITY_INSERT [dbo].[gender] OFF
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [firstName], [lastName], [userName], [password], [tel], [mail], [genderId], [points], [isHasCar]) VALUES (1, N'שולמית', N'לוי', N'שולמית', N'12345', N'0548594162', N'shulamit@gmail.com', 2, NULL, 1)
INSERT [dbo].[user] ([id], [firstName], [lastName], [userName], [password], [tel], [mail], [genderId], [points], [isHasCar]) VALUES (2, N'אסתר חוה', N'בניטה', N'אסתר חוה', N'211664925', N'0548433803', N'esterhava@gmail.com', 2, NULL, 0)
SET IDENTITY_INSERT [dbo].[user] OFF
/****** Object:  Index [IX_temporaryTraveller]    Script Date: 20/05/2021 14:57:17 ******/
CREATE NONCLUSTERED INDEX [IX_temporaryTraveller] ON [dbo].[temporaryTraveller]
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[car]  WITH CHECK ADD  CONSTRAINT [FK_car_user] FOREIGN KEY([userId])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[car] CHECK CONSTRAINT [FK_car_user]
GO
ALTER TABLE [dbo].[regularTraveling]  WITH CHECK ADD  CONSTRAINT [FK_regularTraveling_user] FOREIGN KEY([driverId])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[regularTraveling] CHECK CONSTRAINT [FK_regularTraveling_user]
GO
ALTER TABLE [dbo].[temporaryTraveling]  WITH CHECK ADD  CONSTRAINT [FK_temporaryTraveling_user] FOREIGN KEY([driverId])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[temporaryTraveling] CHECK CONSTRAINT [FK_temporaryTraveling_user]
GO
ALTER TABLE [dbo].[temporaryTraveller]  WITH CHECK ADD  CONSTRAINT [FK_temporaryTraveller_user] FOREIGN KEY([travellerId])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[temporaryTraveller] CHECK CONSTRAINT [FK_temporaryTraveller_user]
GO
ALTER TABLE [dbo].[travellerInRegularTravel]  WITH CHECK ADD  CONSTRAINT [FK_travellerInRegularTravel_regularTraveling] FOREIGN KEY([regularTravelingId])
REFERENCES [dbo].[regularTraveling] ([id])
GO
ALTER TABLE [dbo].[travellerInRegularTravel] CHECK CONSTRAINT [FK_travellerInRegularTravel_regularTraveling]
GO
ALTER TABLE [dbo].[travellerInRegularTravel]  WITH CHECK ADD  CONSTRAINT [FK_travellerInRegularTravel_user] FOREIGN KEY([travelerId])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[travellerInRegularTravel] CHECK CONSTRAINT [FK_travellerInRegularTravel_user]
GO
ALTER TABLE [dbo].[user]  WITH CHECK ADD  CONSTRAINT [FK_user_gender] FOREIGN KEY([genderId])
REFERENCES [dbo].[gender] ([id])
GO
ALTER TABLE [dbo].[user] CHECK CONSTRAINT [FK_user_gender]
GO
USE [master]
GO
ALTER DATABASE [car_project] SET  READ_WRITE 
GO
