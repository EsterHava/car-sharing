USE [master]
GO
/****** Object:  Database [car_project]    Script Date: 05/03/2022 21:33:42 ******/
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
EXEC sys.sp_db_vardecimal_storage_format N'car_project', N'ON'
GO
ALTER DATABASE [car_project] SET QUERY_STORE = OFF
GO
USE [car_project]
GO
/****** Object:  Table [dbo].[car]    Script Date: 05/03/2022 21:33:43 ******/
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
/****** Object:  Table [dbo].[gender]    Script Date: 05/03/2022 21:33:43 ******/
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
/****** Object:  Table [dbo].[joinRequests]    Script Date: 05/03/2022 21:33:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[joinRequests](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[regularTravelId] [int] NULL,
	[temporaryTravelId] [int] NULL,
 CONSTRAINT [PK_joinRequests] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[messages]    Script Date: 05/03/2022 21:33:43 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[messages](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[userId] [int] NOT NULL,
	[message] [nvarchar](max) NULL,
	[isRead] [bit] NOT NULL,
 CONSTRAINT [PK_messages] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[regularTraveling]    Script Date: 05/03/2022 21:33:43 ******/
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
	[lngSource] [float] NULL,
	[latSource] [float] NULL,
	[lngDestination] [float] NULL,
	[latDestination] [float] NULL,
	[availableSeats] [int] NULL,
 CONSTRAINT [PK_regularTraveling] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[temporaryTraveling]    Script Date: 05/03/2022 21:33:43 ******/
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
/****** Object:  Table [dbo].[temporaryTraveller]    Script Date: 05/03/2022 21:33:43 ******/
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
/****** Object:  Table [dbo].[travellerInRegularTravel]    Script Date: 05/03/2022 21:33:43 ******/
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
	[latCollection] [float] NULL,
	[lngCollection] [float] NULL,
	[latDestination] [float] NULL,
	[lngDestination] [float] NULL,
 CONSTRAINT [PK_travellerInRegularTravel] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[user]    Script Date: 05/03/2022 21:33:43 ******/
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
SET IDENTITY_INSERT [dbo].[joinRequests] ON 

INSERT [dbo].[joinRequests] ([id], [userId], [Date], [regularTravelId], [temporaryTravelId]) VALUES (1, 1, CAST(N'2021-10-09' AS Date), 26, NULL)
INSERT [dbo].[joinRequests] ([id], [userId], [Date], [regularTravelId], [temporaryTravelId]) VALUES (2, 1, CAST(N'2021-10-09' AS Date), 3, NULL)
INSERT [dbo].[joinRequests] ([id], [userId], [Date], [regularTravelId], [temporaryTravelId]) VALUES (3, 1, CAST(N'2021-10-19' AS Date), NULL, 1)
INSERT [dbo].[joinRequests] ([id], [userId], [Date], [regularTravelId], [temporaryTravelId]) VALUES (4, 1, CAST(N'2021-10-19' AS Date), NULL, 1)
INSERT [dbo].[joinRequests] ([id], [userId], [Date], [regularTravelId], [temporaryTravelId]) VALUES (5, 1, CAST(N'2021-10-19' AS Date), NULL, 1)
INSERT [dbo].[joinRequests] ([id], [userId], [Date], [regularTravelId], [temporaryTravelId]) VALUES (6, 1, CAST(N'2021-11-07' AS Date), 3, NULL)
INSERT [dbo].[joinRequests] ([id], [userId], [Date], [regularTravelId], [temporaryTravelId]) VALUES (7, 1, CAST(N'2021-11-07' AS Date), NULL, 1)
INSERT [dbo].[joinRequests] ([id], [userId], [Date], [regularTravelId], [temporaryTravelId]) VALUES (8, 1, CAST(N'2021-11-07' AS Date), 3, NULL)
SET IDENTITY_INSERT [dbo].[joinRequests] OFF
SET IDENTITY_INSERT [dbo].[messages] ON 

INSERT [dbo].[messages] ([id], [userId], [message], [isRead]) VALUES (1, 24, N'נוסע מעונין להצטרף', 0)
INSERT [dbo].[messages] ([id], [userId], [message], [isRead]) VALUES (3, 24, N'ביטול נסיעה', 0)
SET IDENTITY_INSERT [dbo].[messages] OFF
SET IDENTITY_INSERT [dbo].[regularTraveling] ON 

INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (3, 1, N'שדל', N'ירושלים', CAST(N'21:32:00' AS Time), CAST(N'22:32:00' AS Time), 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (26, 20, N'חזון איש ', N'שדל', CAST(N'20:00:00' AS Time), CAST(N'20:56:00' AS Time), 5, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (27, NULL, N'מצדה 7 בני ברק', N'אלקנה ירושלים', CAST(N'07:50:00' AS Time), CAST(N'16:50:00' AS Time), 3, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (28, NULL, N'מצדה 7 בני ברק', N'אלקנה ירושלים', CAST(N'07:50:00' AS Time), CAST(N'16:50:00' AS Time), 2, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (29, NULL, N'מצדה 7 בני ברק', N'אלקנה ירושלים', CAST(N'07:50:00' AS Time), CAST(N'16:50:00' AS Time), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (30, NULL, N'הרב שר 3 בני ברק ישראל', N'הרב שר 3 בני ברק ישראל', CAST(N'14:04:00' AS Time), CAST(N'15:45:00' AS Time), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (31, NULL, N'הרב שר 3 בני ברק ישראל', N'הרב שר 3 בני ברק ישראל', CAST(N'14:05:00' AS Time), CAST(N'18:05:00' AS Time), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (32, NULL, N'הרב שר 3 בני ברק ישראל', N'הרב שר 3 בני ברק ישראל', CAST(N'14:05:00' AS Time), CAST(N'15:06:00' AS Time), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (33, NULL, N'פרדו 14 בני ברק ישראל', N'אלקנה 14 ירושלים ישראל', CAST(N'14:50:00' AS Time), CAST(N'01:50:00' AS Time), 6, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (34, NULL, N'פרדו 14 בני ברק ישראל', N'פרדו 14 בני ברק ישראל', CAST(N'04:50:00' AS Time), CAST(N'20:50:00' AS Time), 1, NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (35, NULL, N'דנגור 6 בני ברק ישראל', N'דנגור 6 בני ברק ישראל', CAST(N'14:20:00' AS Time), CAST(N'21:22:00' AS Time), 1, 34.8328326, 32.0957624, NULL, 34.8328326, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (36, NULL, N'הרב שר 3 בני ברק', N'הרב שר 3 בני ברק', CAST(N'04:54:00' AS Time), CAST(N'05:45:00' AS Time), 1, 34.8284168, 32.0893905, 34.8284168, 32.0893905, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (37, NULL, N'פרדו 15 בני ברק', N'מסילת יוסף 54 מודיעין עילית', CAST(N'05:00:00' AS Time), CAST(N'07:00:00' AS Time), 1, 34.8444741, 32.0875309, 35.0422695, 31.9272223, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (38, NULL, N'פרדו 15 בני ברק', N'מסילת יוסף 54 מודיעין עילית', CAST(N'05:00:00' AS Time), CAST(N'07:00:00' AS Time), 5, 34.8444741, 32.0875309, 35.0422695, 31.9272223, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (39, NULL, N'פרדו 15 בני ברק', N'מסילת יוסף 54 מודיעין עילית', CAST(N'05:00:00' AS Time), CAST(N'07:00:00' AS Time), 3, 34.8444741, 32.0875309, 35.0422695, 31.9272223, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (40, NULL, N'יהושע 5 בני ברק', N'אלקנה 14 ירושלים ', CAST(N'07:00:00' AS Time), CAST(N'08:00:00' AS Time), 1, 34.8281889, 32.0857811, 35.2130509, 31.7933274, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (41, NULL, N'יהושע 5 בני ברק', N'אלקנה 14 ירושלים ', CAST(N'07:00:00' AS Time), CAST(N'08:00:00' AS Time), 3, 34.8281889, 32.0857811, 35.2130509, 31.7933274, NULL)
INSERT [dbo].[regularTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [day], [lngSource], [latSource], [lngDestination], [latDestination], [availableSeats]) VALUES (42, NULL, N'יהושע 5 בני ברק', N'אלקנה 14 ירושלים ', CAST(N'07:00:00' AS Time), CAST(N'08:00:00' AS Time), 2, 34.8281889, 32.0857811, 35.2130509, 31.7933274, NULL)
SET IDENTITY_INSERT [dbo].[regularTraveling] OFF
SET IDENTITY_INSERT [dbo].[temporaryTraveling] ON 

INSERT [dbo].[temporaryTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [date]) VALUES (1, 1, N'פרדו', N'ירושלים', CAST(N'21:09:00' AS Time), CAST(N'22:09:00' AS Time), CAST(N'2021-08-18' AS Date))
INSERT [dbo].[temporaryTraveling] ([id], [driverId], [source], [destination], [exitTime], [arriveTime], [date]) VALUES (5, 20, N'בעלז', N'טרפון', CAST(N'17:00:00' AS Time), CAST(N'17:10:00' AS Time), CAST(N'2021-10-07' AS Date))
SET IDENTITY_INSERT [dbo].[temporaryTraveling] OFF
SET IDENTITY_INSERT [dbo].[travellerInRegularTravel] ON 

INSERT [dbo].[travellerInRegularTravel] ([id], [regularTravelingId], [travelerId], [collectingPoint], [destinationPoint], [latCollection], [lngCollection], [latDestination], [lngDestination]) VALUES (1, 3, 23, N'טרפון רבי עקיבא', N'גבעת שאול', NULL, NULL, NULL, NULL)
INSERT [dbo].[travellerInRegularTravel] ([id], [regularTravelingId], [travelerId], [collectingPoint], [destinationPoint], [latCollection], [lngCollection], [latDestination], [lngDestination]) VALUES (3, 26, 23, N'XXX', N'YYY', NULL, NULL, NULL, NULL)
INSERT [dbo].[travellerInRegularTravel] ([id], [regularTravelingId], [travelerId], [collectingPoint], [destinationPoint], [latCollection], [lngCollection], [latDestination], [lngDestination]) VALUES (4, 26, 24, N'פרדו', N'נועם אלימלך', NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[travellerInRegularTravel] OFF
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([id], [firstName], [lastName], [userName], [password], [tel], [mail], [genderId], [points], [isHasCar]) VALUES (1, N'עע', N'עיח', N'1', N'1', NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[user] ([id], [firstName], [lastName], [userName], [password], [tel], [mail], [genderId], [points], [isHasCar]) VALUES (20, N'אסתר חוה', N'בניטה', N'אסתר חוה', N'1234', N'0548433803', N'esterhava@gmail.com', 2, NULL, 0)
INSERT [dbo].[user] ([id], [firstName], [lastName], [userName], [password], [tel], [mail], [genderId], [points], [isHasCar]) VALUES (23, N'אסתי', N'גרוסנס', N'2', N'2', N'0527696162', N'grosnas100@gmail.com', 2, NULL, 1)
INSERT [dbo].[user] ([id], [firstName], [lastName], [userName], [password], [tel], [mail], [genderId], [points], [isHasCar]) VALUES (24, N'חני', N'שולמן', N'3', N'3', N'0533162565', N'grosnas100@gmail.com', 1, NULL, 1)
SET IDENTITY_INSERT [dbo].[user] OFF
ALTER TABLE [dbo].[car]  WITH CHECK ADD  CONSTRAINT [FK_car_user] FOREIGN KEY([userId])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[car] CHECK CONSTRAINT [FK_car_user]
GO
ALTER TABLE [dbo].[joinRequests]  WITH CHECK ADD  CONSTRAINT [FK_joinRequests_regularTraveling] FOREIGN KEY([regularTravelId])
REFERENCES [dbo].[regularTraveling] ([id])
GO
ALTER TABLE [dbo].[joinRequests] CHECK CONSTRAINT [FK_joinRequests_regularTraveling]
GO
ALTER TABLE [dbo].[joinRequests]  WITH CHECK ADD  CONSTRAINT [FK_joinRequests_temporaryTraveling] FOREIGN KEY([temporaryTravelId])
REFERENCES [dbo].[temporaryTraveling] ([id])
GO
ALTER TABLE [dbo].[joinRequests] CHECK CONSTRAINT [FK_joinRequests_temporaryTraveling]
GO
ALTER TABLE [dbo].[joinRequests]  WITH CHECK ADD  CONSTRAINT [FK_joinRequests_user] FOREIGN KEY([userId])
REFERENCES [dbo].[user] ([id])
GO
ALTER TABLE [dbo].[joinRequests] CHECK CONSTRAINT [FK_joinRequests_user]
GO
ALTER TABLE [dbo].[messages]  WITH CHECK ADD FOREIGN KEY([userId])
REFERENCES [dbo].[user] ([id])
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
ALTER TABLE [dbo].[temporaryTraveller]  WITH CHECK ADD  CONSTRAINT [FK_temporaryTraveller_temporaryTraveling] FOREIGN KEY([travelId])
REFERENCES [dbo].[temporaryTraveling] ([id])
GO
ALTER TABLE [dbo].[temporaryTraveller] CHECK CONSTRAINT [FK_temporaryTraveller_temporaryTraveling]
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
