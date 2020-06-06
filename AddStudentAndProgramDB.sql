
SET IDENTITY_INSERT [dbo].[Student] ON
INSERT INTO [dbo].[Student] ([Student_Id], [Name], [Email], [Background]) VALUES (1, N'Leo Kane', N'lk@gmail.com', N'IT')
INSERT INTO [dbo].[Student] ([Student_Id], [Name], [Email], [Background]) VALUES (2, N'Zeenat Hubbard', N'zh@gmail.com', N'High School')
INSERT INTO [dbo].[Student] ([Student_Id], [Name], [Email], [Background]) VALUES (3, N'Annalise Farrell', N'af@gmail.com', N'High School')
INSERT INTO [dbo].[Student] ([Student_Id], [Name], [Email], [Background]) VALUES (4, N'Wasim Callahan', N'wc@gmail.com', N'IT')
INSERT INTO [dbo].[Student] ([Student_Id], [Name], [Email], [Background]) VALUES (5, N'Dawood Driscoll', N'dd@gmail.com', N'Theatre')
INSERT INTO [dbo].[Student] ([Student_Id], [Name], [Email], [Background]) VALUES (6, N'Ella-Mai Miranda', N'em@gmail.com', N'Economics')
INSERT INTO [dbo].[Student] ([Student_Id], [Name], [Email], [Background]) VALUES (7, N'Jon-Paul Penn', N'jp@gmail.com', N'High School')
INSERT INTO [dbo].[Student] ([Student_Id], [Name], [Email], [Background]) VALUES (8, N'Kamil Currie', N'kc@gmail.com', N'Chemistry')
INSERT INTO [dbo].[Student] ([Student_Id], [Name], [Email], [Background]) VALUES (9, N'Brenden Orr', N'bo@gmail.com', N'High School')
INSERT INTO [dbo].[Student] ([Student_Id], [Name], [Email], [Background]) VALUES (10, N'Jamie Sierra
', N'js@gmail.com', N'IT')
SET IDENTITY_INSERT [dbo].[Student] OFF

SET IDENTITY_INSERT [dbo].[Programme] ON
INSERT INTO [dbo].[Programme] ([Programme_Id], [Name], [Year_Of_Beginning], [Year_Of_End]) VALUES (5, N'AP Computer Science', N'2019-09-01', N'2022-01-31')
INSERT INTO [dbo].[Programme] ([Programme_Id], [Name], [Year_Of_Beginning], [Year_Of_End]) VALUES (1005, N'AP Commerce Management', N'2018-09-01', N'2021-01-31')
INSERT INTO [dbo].[Programme] ([Programme_Id], [Name], [Year_Of_Beginning], [Year_Of_End]) VALUES (1006, N'AP Logistic Management', N'2020-09-01', N'2023-01-31')
INSERT INTO [dbo].[Programme] ([Programme_Id], [Name], [Year_Of_Beginning], [Year_Of_End]) VALUES (1007, N'AP Marketing Management', N'2019-02-01', N'2022-06-30')
INSERT INTO [dbo].[Programme] ([Programme_Id], [Name], [Year_Of_Beginning], [Year_Of_End]) VALUES (1008, N'AP Multimedia Design', N'2018-02-01', N'2021-06-30')
INSERT INTO [dbo].[Programme] ([Programme_Id], [Name], [Year_Of_Beginning], [Year_Of_End]) VALUES (1009, N'AP Management', N'2019-09-01', N'2022-01-31')
SET IDENTITY_INSERT [dbo].[Programme] OFF
