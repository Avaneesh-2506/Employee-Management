USE [Tech_Project_HubDB]
GO
/****** Object:  Table [dbo].[DeveloperMaster]    Script Date: 23-09-2023 6.32.28 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DeveloperMaster](
	[Name] [varchar](200) NULL,
	[Email_Id] [varchar](150) NOT NULL,
	[Mobile_No] [varchar](15) NULL,
	[Qualification] [varchar](90) NULL,
	[Gender] [varchar](15) NULL,
	[Designation] [varchar](150) NULL,
	[Address] [varchar](300) NULL,
	[ProfilePic] [varchar](300) NULL,
	[Registered_On] [datetime] NULL,
 CONSTRAINT [PK_DeveloperMaster] PRIMARY KEY CLUSTERED 
(
	[Email_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EnquiryMaster]    Script Date: 23-09-2023 6.32.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EnquiryMaster](
	[Enq_Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NULL,
	[EmailId] [varchar](100) NULL,
	[MobNo] [varchar](30) NULL,
	[Query] [varchar](max) NULL,
	[Enq_DT] [datetime] NULL,
 CONSTRAINT [PK_EnquiryMaster] PRIMARY KEY CLUSTERED 
(
	[Enq_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FeedbackMaster]    Script Date: 23-09-2023 6.32.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FeedbackMaster](
	[Fid] [int] IDENTITY(1,1) NOT NULL,
	[Feedback_Title] [varchar](70) NULL,
	[Feedback_Detail] [varchar](max) NULL,
	[DeveloperId] [varchar](150) NULL,
	[MsgDT] [datetime] NULL,
 CONSTRAINT [PK_FeedbackMaster] PRIMARY KEY CLUSTERED 
(
	[Fid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LoginMaster]    Script Date: 23-09-2023 6.32.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginMaster](
	[Email_Id] [varchar](150) NOT NULL,
	[Pass] [varchar](200) NULL,
	[Utype] [varchar](150) NULL,
 CONSTRAINT [PK_LoginMaster] PRIMARY KEY CLUSTERED 
(
	[Email_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotificationMaster]    Script Date: 23-09-2023 6.32.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[NotificationMaster](
	[Nid] [int] IDENTITY(1,1) NOT NULL,
	[NMsg] [varchar](max) NULL,
	[NDT] [varchar](30) NULL,
 CONSTRAINT [PK_NotificationMaster] PRIMARY KEY CLUSTERED 
(
	[Nid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[PostProjectMaster]    Script Date: 23-09-2023 6.32.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PostProjectMaster](
	[Project_Id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Deadline] [datetime] NULL,
	[Proj_Description] [varchar](300) NULL,
	[Filename] [varchar](250) NULL,
	[Upload_DT] [datetime] NULL,
 CONSTRAINT [PK_PostProjectMaster] PRIMARY KEY CLUSTERED 
(
	[Project_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProjectMaster]    Script Date: 23-09-2023 6.32.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProjectMaster](
	[Project_Id] [int] IDENTITY(1,1) NOT NULL,
	[Project_Title] [varchar](150) NULL,
	[Deadline] [datetime] NULL,
	[Description] [varchar](max) NULL,
	[Project_File] [varchar](150) NULL,
	[Project_DT] [datetime] NULL,
 CONSTRAINT [PK_ProjectMaster] PRIMARY KEY CLUSTERED 
(
	[Project_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RequestMaster]    Script Date: 23-09-2023 6.32.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RequestMaster](
	[Request_Id] [int] IDENTITY(1,1) NOT NULL,
	[Request_For] [int] NULL,
	[Request_Msg] [varchar](300) NULL,
	[Requested_By] [varchar](150) NULL,
	[Request_DT] [datetime] NULL,
	[Status] [bit] NULL,
 CONSTRAINT [PK_RequestMaster] PRIMARY KEY CLUSTERED 
(
	[Request_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TaskMaster]    Script Date: 23-09-2023 6.32.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TaskMaster](
	[Task_Id] [int] IDENTITY(1,1) NOT NULL,
	[ForDeveloper] [varchar](150) NULL,
	[ForDate] [datetime] NULL,
	[TaskTitle] [varchar](150) NULL,
	[TaskDescription] [varchar](max) NULL,
	[UploadedOn] [datetime] NULL,
	[TaskFile] [varchar](250) NULL,
 CONSTRAINT [PK_TaskMaster] PRIMARY KEY CLUSTERED 
(
	[Task_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UploadCodeMaster]    Script Date: 23-09-2023 6.32.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UploadCodeMaster](
	[Upload_Id] [int] IDENTITY(1,1) NOT NULL,
	[Upload_Title] [varchar](200) NULL,
	[Code_Descrip] [varchar](max) NULL,
	[Uploaded_By] [varchar](150) NULL,
	[CodeFile_Name] [varchar](150) NULL,
	[Uploaded_DT] [datetime] NULL,
 CONSTRAINT [PK_UploadCodeMaster] PRIMARY KEY CLUSTERED 
(
	[Upload_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[WorkReportMaster]    Script Date: 23-09-2023 6.32.29 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[WorkReportMaster](
	[Report_Id] [int] IDENTITY(1,1) NOT NULL,
	[Report_Title] [varchar](200) NULL,
	[Report_Descrip] [varchar](max) NULL,
	[WorkDate] [datetime] NULL,
	[IsHelpNeeded] [bit] NULL,
	[Submitted_By] [varchar](150) NULL,
	[Submitted_DT] [datetime] NULL,
 CONSTRAINT [PK_WorkReportMaster] PRIMARY KEY CLUSTERED 
(
	[Report_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[DeveloperMaster] ([Name], [Email_Id], [Mobile_No], [Qualification], [Gender], [Designation], [Address], [ProfilePic], [Registered_On]) VALUES (N'Nikhil Singh', N'003yunew20@gmail.com', N'6832184313', N'MCA', N'Male', N'Senior Software Engineer', N'Azamgarh, Uttar Pradesh ', N'n4yy3id0.te4IMG20230729153903.jpg', CAST(N'2023-09-22T10:50:13.240' AS DateTime))
INSERT [dbo].[DeveloperMaster] ([Name], [Email_Id], [Mobile_No], [Qualification], [Gender], [Designation], [Address], [ProfilePic], [Registered_On]) VALUES (N'Akshat Kumar', N'akshatkumar8678089614@gmail.com', N'9450521152', N'BCA', N'Male', N'General Manager', N'Aurangabad, Bihar, India', N'bbhmrxap.oc03.jpeg', CAST(N'2023-09-23T17:21:20.143' AS DateTime))
INSERT [dbo].[DeveloperMaster] ([Name], [Email_Id], [Mobile_No], [Qualification], [Gender], [Designation], [Address], [ProfilePic], [Registered_On]) VALUES (N'Amit Kumnar Yadav', N'amit974403727250@gmail.com', N'8976546845', N'Diploma(IT)', N'Male', N'Android Developer', N'Jaunpur', N'aoo3c5jd.tqrWhatsApp Image 2023-06-14 at 2.15.19 PM.jpeg', CAST(N'2023-09-19T15:42:26.887' AS DateTime))
INSERT [dbo].[DeveloperMaster] ([Name], [Email_Id], [Mobile_No], [Qualification], [Gender], [Designation], [Address], [ProfilePic], [Registered_On]) VALUES (N'Gulshan Singh', N'gulshansingh12@gmail.com', N'9936128545', N'Diploma(IT)', N'Male', N'Project Manager', N'Shivpur, Varanasi, Uttar Pradesh', N'bzlsmms4.tianew.jpg', CAST(N'2023-09-23T17:19:14.017' AS DateTime))
INSERT [dbo].[DeveloperMaster] ([Name], [Email_Id], [Mobile_No], [Qualification], [Gender], [Designation], [Address], [ProfilePic], [Registered_On]) VALUES (N'Vishal Patel', N'vishal96@gmail.com', N'9964552500', N'MCA', N'Male', N'Trainee', N'Semari, Prayagraj, Uttar Pradesh', N'dobunkbz.mfc2.jpeg', CAST(N'2023-09-23T17:23:36.357' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[EnquiryMaster] ON 

INSERT [dbo].[EnquiryMaster] ([Enq_Id], [Name], [EmailId], [MobNo], [Query], [Enq_DT]) VALUES (3003, N'Nikhil Singh', N'nikh13435@gmail.com', N'68428848225', N'I am a web developer and i want to know which type of projects should i do.', CAST(N'2023-09-23T17:24:55.677' AS DateTime))
SET IDENTITY_INSERT [dbo].[EnquiryMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[FeedbackMaster] ON 

INSERT [dbo].[FeedbackMaster] ([Fid], [Feedback_Title], [Feedback_Detail], [DeveloperId], [MsgDT]) VALUES (1002, N'E-commerce ', N'I really happy to work on E-commerce website. i have created a fully responsive website', N'003yunew20@gmail.com', CAST(N'2023-09-23T17:27:05.003' AS DateTime))
INSERT [dbo].[FeedbackMaster] ([Fid], [Feedback_Title], [Feedback_Detail], [DeveloperId], [MsgDT]) VALUES (1003, N'Regular Cross-Functional Meetings', N'Implementing regular cross-functional team meetings can foster a better understanding of each team''s responsibilities and dependencies. This will streamline project workflows and reduce bottlenecks.', N'003yunew20@gmail.com', CAST(N'2023-09-23T17:51:35.307' AS DateTime))
INSERT [dbo].[FeedbackMaster] ([Fid], [Feedback_Title], [Feedback_Detail], [DeveloperId], [MsgDT]) VALUES (1004, N'Improved Documentation', N'Enhancing our internal documentation can be a game-changer. Clear and up-to-date documentation ensures that team members have easy access to critical information, reducing confusion and errors.', N'003yunew20@gmail.com', CAST(N'2023-09-23T17:52:17.723' AS DateTime))
INSERT [dbo].[FeedbackMaster] ([Fid], [Feedback_Title], [Feedback_Detail], [DeveloperId], [MsgDT]) VALUES (1005, N'Project Post-Mortems', N'Conducting project post-mortems can help us learn from our successes and failures. It''s an opportunity to celebrate achievements and identify areas for improvement.', N'003yunew20@gmail.com', CAST(N'2023-09-23T17:52:40.217' AS DateTime))
SET IDENTITY_INSERT [dbo].[FeedbackMaster] OFF
GO
INSERT [dbo].[LoginMaster] ([Email_Id], [Pass], [Utype]) VALUES (N'003yunew20@gmail.com', N'UPROPS234', N'DEVELOPER')
INSERT [dbo].[LoginMaster] ([Email_Id], [Pass], [Utype]) VALUES (N'009avaneesh@gmail.com', N'Z]HULLZO@234', N'DEVELOPER')
INSERT [dbo].[LoginMaster] ([Email_Id], [Pass], [Utype]) VALUES (N'akshatkumar8678089614@gmail.com', N'23456', N'DEVELOPER')
INSERT [dbo].[LoginMaster] ([Email_Id], [Pass], [Utype]) VALUES (N'gulshansingh12@gmail.com', N'23456', N'DEVELOPER')
INSERT [dbo].[LoginMaster] ([Email_Id], [Pass], [Utype]) VALUES (N'manager@gmail.com', N'234', N'MANAGER')
INSERT [dbo].[LoginMaster] ([Email_Id], [Pass], [Utype]) VALUES (N'vishal96@gmail.com', N'23456', N'DEVELOPER')
GO
SET IDENTITY_INSERT [dbo].[NotificationMaster] ON 

INSERT [dbo].[NotificationMaster] ([Nid], [NMsg], [NDT]) VALUES (5, N'Your Project submission date is about to close. Please submit project on time...', N'17-09-2023 11.27.11 AM')
INSERT [dbo].[NotificationMaster] ([Nid], [NMsg], [NDT]) VALUES (6, N'Search new and amazing projects at Trending Projects section.', N'17-09-2023 11.28.45 AM')
INSERT [dbo].[NotificationMaster] ([Nid], [NMsg], [NDT]) VALUES (7, N'Our company is about to announce some new project ideas which is very helpful for fresher to develop their web development skills.', N'17-09-2023 11.30.21 AM')
SET IDENTITY_INSERT [dbo].[NotificationMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[PostProjectMaster] ON 

INSERT [dbo].[PostProjectMaster] ([Project_Id], [Title], [Deadline], [Proj_Description], [Filename], [Upload_DT]) VALUES (1, NULL, CAST(N'2002-12-12T00:00:00.000' AS DateTime), NULL, N'0kymms4q.v3ptzg4nqsb.s4zDS Practicle No-1.pdf', CAST(N'2023-09-18T19:47:13.200' AS DateTime))
SET IDENTITY_INSERT [dbo].[PostProjectMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[ProjectMaster] ON 

INSERT [dbo].[ProjectMaster] ([Project_Id], [Project_Title], [Deadline], [Description], [Project_File], [Project_DT]) VALUES (1003, N'Tech Work', CAST(N'2023-12-10T00:00:00.000' AS DateTime), N'Project coming soon...', N'z2bhmg4x.ddsAvaneesh Shukla _certificate.pdf', CAST(N'2023-09-19T19:22:12.467' AS DateTime))
INSERT [dbo].[ProjectMaster] ([Project_Id], [Project_Title], [Deadline], [Description], [Project_File], [Project_DT]) VALUES (2003, N'Lost & Found', CAST(N'2023-11-10T00:00:00.000' AS DateTime), N'This project is related to lost and found materials on street or somewhere someone', N'mxlw0syp.uakDS Practicle No-2.pdf', CAST(N'2023-09-21T23:00:52.970' AS DateTime))
INSERT [dbo].[ProjectMaster] ([Project_Id], [Project_Title], [Deadline], [Description], [Project_File], [Project_DT]) VALUES (3003, N'Home Decoration', CAST(N'2023-10-10T00:00:00.000' AS DateTime), N'Home Decoration is a new project .', N'nrneqld5.s3zAssignment-2.pdf', CAST(N'2023-09-23T08:34:43.113' AS DateTime))
INSERT [dbo].[ProjectMaster] ([Project_Id], [Project_Title], [Deadline], [Description], [Project_File], [Project_DT]) VALUES (4003, N'Smart Home Automation System', CAST(N'2023-09-30T00:00:00.000' AS DateTime), N'Create a system that allows users to control and automate various devices in their homes, such as lights, thermostats, and security cameras, using a mobile app or voice commands.', N'gipncfkc.fihJava All Practicals.docx', CAST(N'2023-09-23T17:35:27.567' AS DateTime))
INSERT [dbo].[ProjectMaster] ([Project_Id], [Project_Title], [Deadline], [Description], [Project_File], [Project_DT]) VALUES (4004, N'Eco-Friendly Packaging Initiative', CAST(N'2023-09-27T00:00:00.000' AS DateTime), N'Develop sustainable packaging solutions for a range of products to reduce environmental impact, including researching and implementing biodegradable materials and eco-conscious designs.
', N'2u1tezos.vegDS Practicle No-2.pdf', CAST(N'2023-09-23T17:36:00.010' AS DateTime))
INSERT [dbo].[ProjectMaster] ([Project_Id], [Project_Title], [Deadline], [Description], [Project_File], [Project_DT]) VALUES (4005, N'Healthcare Management App', CAST(N'2023-09-28T00:00:00.000' AS DateTime), N' Build a mobile application that helps patients schedule appointments, access medical records, and receive medication reminders while also allowing healthcare providers to manage appointments and patient information efficiently.', N'jmss3wrd.0l2DS Practicle No-9(ii).pdf', CAST(N'2023-09-23T17:36:42.843' AS DateTime))
INSERT [dbo].[ProjectMaster] ([Project_Id], [Project_Title], [Deadline], [Description], [Project_File], [Project_DT]) VALUES (4006, N'Renewable Energy Monitoring System', CAST(N'2023-09-25T00:00:00.000' AS DateTime), N' Create a platform that collects and analyzes data from renewable energy sources like solar panels and wind turbines to optimize energy production, reduce costs, and lower carbon footprints.', N'ajifanu3.21uDS Practicle No-4.pdf', CAST(N'2023-09-23T17:38:21.453' AS DateTime))
SET IDENTITY_INSERT [dbo].[ProjectMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[RequestMaster] ON 

INSERT [dbo].[RequestMaster] ([Request_Id], [Request_For], [Request_Msg], [Requested_By], [Request_DT], [Status]) VALUES (3003, 3003, N'I want to work on this project. ', N'003yunew20@gmail.com', CAST(N'2023-09-23T17:27:42.733' AS DateTime), NULL)
INSERT [dbo].[RequestMaster] ([Request_Id], [Request_For], [Request_Msg], [Requested_By], [Request_DT], [Status]) VALUES (3004, 2003, N'This project is only made for me', N'003yunew20@gmail.com', CAST(N'2023-09-23T17:28:08.127' AS DateTime), NULL)
INSERT [dbo].[RequestMaster] ([Request_Id], [Request_For], [Request_Msg], [Requested_By], [Request_DT], [Status]) VALUES (3005, 4006, N'I kindly request your review and approval to proceed with this project. Your guidance and insights would be invaluable in ensuring its success.', N'003yunew20@gmail.com', CAST(N'2023-09-23T17:54:47.043' AS DateTime), NULL)
SET IDENTITY_INSERT [dbo].[RequestMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[TaskMaster] ON 

INSERT [dbo].[TaskMaster] ([Task_Id], [ForDeveloper], [ForDate], [TaskTitle], [TaskDescription], [UploadedOn], [TaskFile]) VALUES (2, N'003yunew20@gmail.com', CAST(N'2023-09-30T00:00:00.000' AS DateTime), N'Email sending', N'Your today task is create a email sender module in your project', CAST(N'2023-09-23T08:36:59.520' AS DateTime), N'd5om2pfe.w1dAssignment-2.pdf')
INSERT [dbo].[TaskMaster] ([Task_Id], [ForDeveloper], [ForDate], [TaskTitle], [TaskDescription], [UploadedOn], [TaskFile]) VALUES (3, N'003yunew20@gmail.com', CAST(N'2023-10-15T00:00:00.000' AS DateTime), N'Captcha Code generator', N'Create random code generator and use it on your captcha', CAST(N'2023-09-23T08:39:17.423' AS DateTime), N'migvpcsh.g5rMySQL .pdf')
INSERT [dbo].[TaskMaster] ([Task_Id], [ForDeveloper], [ForDate], [TaskTitle], [TaskDescription], [UploadedOn], [TaskFile]) VALUES (4, N'003yunew20@gmail.com', CAST(N'2023-10-12T00:00:00.000' AS DateTime), N'Enquiry Modal', N'Add a enquiry modal for users on general page. This enquiry modal will full functionally with and email informative', CAST(N'2023-09-23T08:43:46.203' AS DateTime), N'cqj1dtfb.re1Communication Skills- II.pdf')
SET IDENTITY_INSERT [dbo].[TaskMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[UploadCodeMaster] ON 

INSERT [dbo].[UploadCodeMaster] ([Upload_Id], [Upload_Title], [Code_Descrip], [Uploaded_By], [CodeFile_Name], [Uploaded_DT]) VALUES (1002, N'Tech work', N'Tech work project really a very good project.. ', N'003yunew20@gmail.com', N'n05oapme.ftjJava Practicals.pdf', CAST(N'2023-09-23T17:28:56.777' AS DateTime))
SET IDENTITY_INSERT [dbo].[UploadCodeMaster] OFF
GO
SET IDENTITY_INSERT [dbo].[WorkReportMaster] ON 

INSERT [dbo].[WorkReportMaster] ([Report_Id], [Report_Title], [Report_Descrip], [WorkDate], [IsHelpNeeded], [Submitted_By], [Submitted_DT]) VALUES (1002, N'E-Study', N'Project Completed', CAST(N'2023-10-15T00:00:00.000' AS DateTime), 1, N'amit974403727250@gmail.com', CAST(N'2023-09-19T17:03:55.137' AS DateTime))
INSERT [dbo].[WorkReportMaster] ([Report_Id], [Report_Title], [Report_Descrip], [WorkDate], [IsHelpNeeded], [Submitted_By], [Submitted_DT]) VALUES (1003, N'Lost and found', N'on the way', CAST(N'2023-10-12T00:00:00.000' AS DateTime), 0, N'amit974403727250@gmail.com', CAST(N'2023-09-19T17:13:02.427' AS DateTime))
INSERT [dbo].[WorkReportMaster] ([Report_Id], [Report_Title], [Report_Descrip], [WorkDate], [IsHelpNeeded], [Submitted_By], [Submitted_DT]) VALUES (1004, N'Email Sender Module', N'I have completed my email sender module within 5 days', CAST(N'2023-09-15T00:00:00.000' AS DateTime), 0, N'003yunew20@gmail.com', CAST(N'2023-09-23T17:30:23.317' AS DateTime))
SET IDENTITY_INSERT [dbo].[WorkReportMaster] OFF
GO
ALTER TABLE [dbo].[FeedbackMaster]  WITH CHECK ADD  CONSTRAINT [FK_FeedbackMaster_DeveloperMaster] FOREIGN KEY([DeveloperId])
REFERENCES [dbo].[DeveloperMaster] ([Email_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[FeedbackMaster] CHECK CONSTRAINT [FK_FeedbackMaster_DeveloperMaster]
GO
ALTER TABLE [dbo].[RequestMaster]  WITH CHECK ADD  CONSTRAINT [FK_RequestMaster_DeveloperMaster] FOREIGN KEY([Requested_By])
REFERENCES [dbo].[DeveloperMaster] ([Email_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequestMaster] CHECK CONSTRAINT [FK_RequestMaster_DeveloperMaster]
GO
ALTER TABLE [dbo].[RequestMaster]  WITH CHECK ADD  CONSTRAINT [FK_RequestMaster_ProjectMaster] FOREIGN KEY([Request_For])
REFERENCES [dbo].[ProjectMaster] ([Project_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RequestMaster] CHECK CONSTRAINT [FK_RequestMaster_ProjectMaster]
GO
ALTER TABLE [dbo].[TaskMaster]  WITH CHECK ADD  CONSTRAINT [FK_TaskMaster_DeveloperMaster] FOREIGN KEY([ForDeveloper])
REFERENCES [dbo].[DeveloperMaster] ([Email_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[TaskMaster] CHECK CONSTRAINT [FK_TaskMaster_DeveloperMaster]
GO
ALTER TABLE [dbo].[UploadCodeMaster]  WITH CHECK ADD  CONSTRAINT [FK_UploadCodeMaster_DeveloperMaster] FOREIGN KEY([Uploaded_By])
REFERENCES [dbo].[DeveloperMaster] ([Email_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UploadCodeMaster] CHECK CONSTRAINT [FK_UploadCodeMaster_DeveloperMaster]
GO
ALTER TABLE [dbo].[WorkReportMaster]  WITH CHECK ADD  CONSTRAINT [FK_WorkReportMaster_DeveloperMaster] FOREIGN KEY([Submitted_By])
REFERENCES [dbo].[DeveloperMaster] ([Email_Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[WorkReportMaster] CHECK CONSTRAINT [FK_WorkReportMaster_DeveloperMaster]
GO
