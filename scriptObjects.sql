USE [Locations]
GO
/****** Object:  Table [dbo].[CompareList]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CompareList](
	[login] [varchar](50) NOT NULL,
	[placeId] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[login] ASC,
	[placeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Demographics]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Demographics](
	[placeId] [bigint] NOT NULL,
	[year] [bigint] NOT NULL,
	[genderRatio] [float] NULL,
	[population] [bigint] NULL,
	[medianAge] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[placeId] ASC,
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Economy]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Economy](
	[placeId] [bigint] NOT NULL,
	[year] [bigint] NOT NULL,
	[povertyLevel] [float] NULL,
	[laborParticipation] [float] NULL,
	[averageIncome] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[placeId] ASC,
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Industry]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Industry](
	[placeId] [bigint] NOT NULL,
	[type] [varchar](200) NOT NULL,
	[year] [bigint] NOT NULL,
	[numberOfWorkers] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[placeId] ASC,
	[year] ASC,
	[type] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Note]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Note](
	[noteId] [bigint] IDENTITY(1,1) NOT NULL,
	[content] [varchar](5000) NULL,
	[placeId] [bigint] NOT NULL,
	[userLogin] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Note] PRIMARY KEY CLUSTERED 
(
	[noteId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Place]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Place](
	[placeId] [bigint] NOT NULL,
	[name] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Place] PRIMARY KEY CLUSTERED 
(
	[placeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PlaceIsIn]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PlaceIsIn](
	[placeId] [bigint] NOT NULL,
	[stateName] [varchar](100) NOT NULL,
	[year] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[placeId] ASC,
	[stateName] ASC,
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[State]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[State](
	[name] [varchar](100) NOT NULL,
	[year] [bigint] NOT NULL,
	[spendingEducation] [float] NULL,
	[spendingNaturalResources] [float] NULL,
	[spendingPublicWelfare] [float] NULL,
	[spendingHealth] [float] NULL,
	[incomeTotal] [float] NULL,
	[population] [bigint] NULL,
PRIMARY KEY CLUSTERED 
(
	[name] ASC,
	[year] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[User]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[User](
	[login] [varchar](50) NOT NULL,
	[firstName] [varchar](50) NULL,
	[lastName] [varchar](50) NULL,
	[password] [varchar](500) NULL,
PRIMARY KEY CLUSTERED 
(
	[login] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[CompareList]  WITH CHECK ADD FOREIGN KEY([login])
REFERENCES [dbo].[User] ([login])
GO
ALTER TABLE [dbo].[CompareList]  WITH CHECK ADD FOREIGN KEY([placeId])
REFERENCES [dbo].[Place] ([placeId])
GO
ALTER TABLE [dbo].[Demographics]  WITH CHECK ADD  CONSTRAINT [FK_Demographics_Place] FOREIGN KEY([placeId])
REFERENCES [dbo].[Place] ([placeId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Demographics] CHECK CONSTRAINT [FK_Demographics_Place]
GO
ALTER TABLE [dbo].[Economy]  WITH CHECK ADD  CONSTRAINT [FK_Economy_Place] FOREIGN KEY([placeId])
REFERENCES [dbo].[Place] ([placeId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Economy] CHECK CONSTRAINT [FK_Economy_Place]
GO
ALTER TABLE [dbo].[Industry]  WITH CHECK ADD  CONSTRAINT [FK_Industry_Place] FOREIGN KEY([placeId])
REFERENCES [dbo].[Place] ([placeId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Industry] CHECK CONSTRAINT [FK_Industry_Place]
GO
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_Place] FOREIGN KEY([placeId])
REFERENCES [dbo].[Place] ([placeId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_Place]
GO
ALTER TABLE [dbo].[Note]  WITH CHECK ADD  CONSTRAINT [FK_Note_User] FOREIGN KEY([userLogin])
REFERENCES [dbo].[User] ([login])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Note] CHECK CONSTRAINT [FK_Note_User]
GO
ALTER TABLE [dbo].[PlaceIsIn]  WITH CHECK ADD  CONSTRAINT [FK_PlaceIsIn_Place] FOREIGN KEY([placeId])
REFERENCES [dbo].[Place] ([placeId])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaceIsIn] CHECK CONSTRAINT [FK_PlaceIsIn_Place]
GO
ALTER TABLE [dbo].[PlaceIsIn]  WITH CHECK ADD  CONSTRAINT [FK_PlaceIsIn_State] FOREIGN KEY([stateName], [year])
REFERENCES [dbo].[State] ([name], [year])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[PlaceIsIn] CHECK CONSTRAINT [FK_PlaceIsIn_State]
GO
/****** Object:  StoredProcedure [dbo].[AddToCompareList]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie Lee
-- Create date: 12/7/2016
-- Description:	insert another line into compare list
-- =============================================
CREATE PROCEDURE [dbo].[AddToCompareList] 
	-- Add the parameters for the stored procedure here
	@login varchar(50) = glee, 
	@placeId bigint = 5548000
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	INSERT INTO CompareList
	([login],[placeId])
	VALUES (@login,@placeId)
END

GO
/****** Object:  StoredProcedure [dbo].[CanAddToCompareList]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie Lee
-- Create date: 12/7/2016
-- Description:	
-- =============================================
CREATE PROCEDURE [dbo].[CanAddToCompareList] 
	-- Add the parameters for the stored procedure here
	@login varchar(50) = glee, 
	@placeId bigint = 5548000
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT CASE WHEN (SELECT 1 FROM dbo.CompareList WHERE login = @login AND placeId = @placeId) IS NULL
       THEN 1 ELSE 0 END;
END

GO
/****** Object:  StoredProcedure [dbo].[ChangePassword]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ChangePassword]
  @login [varchar](50) NULL,
  @oldPassword VARCHAR(500),
  @newPassword VARCHAR(500)

AS
BEGIN

UPDATE [User]
SET [User].password = @newPassword
WHERE [User].login = @login

END


GO
/****** Object:  StoredProcedure [dbo].[CheckLogin]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CheckLogin]
  @login [varchar](50) NULL

AS
BEGIN
SELECT 
  CASE WHEN ISNULL(@login, '') <> ''   
              AND NOT EXISTS ( SELECT 1
                                 FROM [User]
                                   WHERE [login] = @login )
       THEN 1 ELSE 0 END;
END


GO
/****** Object:  StoredProcedure [dbo].[CheckPassword]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[CheckPassword]
  @login [varchar](50) NULL,
  @password [varchar](500) NULL

AS
BEGIN
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT CASE WHEN EXISTS ( SELECT 1 FROM [User] WHERE [User].login = @login AND [User].password = @password ) THEN 1 ELSE 0 END
          
END


GO
/****** Object:  StoredProcedure [dbo].[createNote]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[createNote]
	@content varchar(5000),
	@placeId bigint,
	@userLogin varchar(50)
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO Note 
	(	
		content
		,placeId
		,userLogin
	)
	VALUES
	(
		@content
		,@placeId
		,@userLogin
	)
END

GO
/****** Object:  StoredProcedure [dbo].[CreateUser]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CreateUser]
  @login [varchar](50) NULL,
  @password [varchar](500) NULL,
  @firstName [varchar](50) NULL,
  @lastName [varchar](50) NULL

AS
BEGIN
INSERT INTO [User]
(      [login]
      ,[password]
      ,[firstName]
      ,[lastName]
)
VALUES 
(     
  @login,
  @password,
  @firstName,
  @lastName
)

END


GO
/****** Object:  StoredProcedure [dbo].[deleteNote]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[deleteNote]
	@noteId bigint
AS
BEGIN
	SET NOCOUNT ON;
	DELETE FROM Note WHERE Note.noteId=@noteId;
END

GO
/****** Object:  StoredProcedure [dbo].[DeleteSavedPlaces]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteSavedPlaces]
  @login varchar(50)
AS
BEGIN
  SET NOCOUNT ON;
  DELETE FROM CompareList WHERE CompareList.login = @login;
END

GO
/****** Object:  StoredProcedure [dbo].[GetAvgIncomeChange]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie Lee
-- Create date: 12/6/2016
-- Description:	Get Avg income Change
-- =============================================
CREATE PROCEDURE [dbo].[GetAvgIncomeChange] 
	-- Add the parameters for the stored procedure here
	@placeId bigint = 5548000
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
   	ROUND(( CAST( E2.averageIncome AS float ) - CAST( E1.averageIncome AS float ) ) / CAST( E1.averageIncome AS float ), 4) as incomeChange
  FROM Economy E1
	INNER JOIN Economy E2
  	ON E1.placeId = E2.placeId
  WHERE E1.placeId = @placeId
	AND E1.year = ( SELECT MIN(year)
                  	FROM Economy
                  	WHERE placeId = @placeId )
	AND E2.year = ( SELECT MAX(year)
                  	FROM Economy
                  	WHERE placeId = @placeId  )
END

GO
/****** Object:  StoredProcedure [dbo].[GetCompareCities]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCompareCities]  
    @login varchar(50)
AS
BEGIN
  SELECT CompareList.placeId, Place.name, PlaceIsIn.stateName 
    FROM [dbo].CompareList
      INNER JOIN [dbo].Place
        ON CompareList.placeId = Place.placeId
      INNER JOIN [dbo].PlaceIsIn
        ON CompareList.placeId = PlaceIsIn.placeId
          AND EXISTS ( SELECT 1
                         FROM PlaceIsIn pii0
                           WHERE pii0.placeId = PlaceIsIn.placeId
                         GROUP BY pii0.placeId
                         HAVING MAX(pii0.year) = PlaceIsIn.year )
      WHERE CompareList.login = @login
END

GO
/****** Object:  StoredProcedure [dbo].[GetEconomicData]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie Lee
-- Create date: 12/5/2016
-- Description:	Get latest place economic data
-- =============================================
CREATE PROCEDURE [dbo].[GetEconomicData] 
	-- Add the parameters for the stored procedure here
	@placeId bigint = 5548000,
	@year bigint NULL = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT e1.povertyLevel,e1.laborParticipation,e1.averageIncome
	FROM Economy as e1
	WHERE e1.placeId = @placeId 
	AND e1.year = isnull(@year,(SELECT MAX(e2.year) FROM Economy as e2 WHERE e2.placeId = @placeId))
END

GO
/****** Object:  StoredProcedure [dbo].[GetGenderRatio]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie Lee
-- Create date: 12/6/2016
-- Description:	Get gender ratio
-- =============================================
CREATE PROCEDURE [dbo].[GetGenderRatio] 
	-- Add the parameters for the stored procedure here
	@placeId bigInt = 5548000,
	@year bigint NULL = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT ROUND(genderRatio,2)
	FROM Demographics as d1
	WHERE d1.placeId = @placeId
	AND d1.year = isnull(@year,(SELECT MAX(d2.year) FROM Demographics as d2 WHERE d2.placeId = @placeId))
END

GO
/****** Object:  StoredProcedure [dbo].[GetIndustries]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetIndustries]
AS
BEGIN
  SELECT DISTINCT type FROM dbo.Industry
END

GO
/****** Object:  StoredProcedure [dbo].[GetLaborParticipationChange]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie Lee
-- Create date: 12/5/2016
-- Description:	Get labor participation rate changes for place
-- =============================================
CREATE PROCEDURE [dbo].[GetLaborParticipationChange] 
	-- Add the parameters for the stored procedure here
	@placeId bigint = 0
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT
   	ROUND(( CAST( E2.laborParticipation AS float ) - CAST( E1.laborParticipation AS float ) ) / CAST( E1.laborParticipation AS float ), 4) as laborChange
  FROM Economy E1
	INNER JOIN Economy E2
  	ON E1.placeId = E2.placeId
  WHERE E1.placeId = @placeId
	AND E1.year = ( SELECT MIN(year)
                  	FROM Economy
                  	WHERE placeId = @placeId )
	AND E2.year = ( SELECT MAX(year)
                  	FROM Economy
                  	WHERE placeId = @placeId  )
END

GO
/****** Object:  StoredProcedure [dbo].[GetMedianAge]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie Lee
-- Create date: 12/6/2016
-- Description:	Get Avg Age
-- =============================================
CREATE PROCEDURE [dbo].[GetMedianAge] 
	-- Add the parameters for the stored procedure here
	@placeId bigint = 5548000,
	@year bigint NULL = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT medianAge
	FROM Demographics as d1
	WHERE d1.placeId = @placeId
	AND d1.year = isnull(@year,(SELECT MAX(d2.year) FROM Demographics as d2 WHERE d2.placeId = @placeId))
END

GO
/****** Object:  StoredProcedure [dbo].[GetName]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetName]
  @login [varchar](50) NULL
AS
BEGIN
/****** Script for SelectTopNRows command from SSMS  ******/
SELECT ISNULL(firstName, 'Dude')
  FROM [User]
  WHERE [login] = @login
          
END


GO
/****** Object:  StoredProcedure [dbo].[GetPlaceName]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie Lee
-- Create date: 12/4/2016
-- Description:	Get the Place Name from Place ID
-- =============================================
CREATE PROCEDURE [dbo].[GetPlaceName] 
	-- Add the parameters for the stored procedure here
	@placeId bigint = 107000
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Place.name
	FROM Place
	WHERE Place.placeId = @placeId
END

GO
/****** Object:  StoredProcedure [dbo].[GetPlacePopulation]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie
-- Create date: 12/5/2016
-- Description:	Get latest population
-- =============================================
CREATE PROCEDURE [dbo].[GetPlacePopulation] 
	-- Add the parameters for the stored procedure here
	@placeId bigint = 5548000,
	@year bigint NULL = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT population
	FROM Demographics as d1
	WHERE d1.placeId = @placeId
	AND d1.year = isnull(@year,(SELECT MAX(d2.year) FROM Demographics as d2 WHERE d2.placeId = @placeId))
END

GO
/****** Object:  StoredProcedure [dbo].[GetPopChange]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie Lee
-- Create date: 12/5/2016
-- Description:	Get population change for city
-- =============================================
CREATE PROCEDURE [dbo].[GetPopChange]
	-- Add the parameters for the stored procedure here
	@placeId bigint = 5548000
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	
	SELECT
   	ROUND(( CAST( P2.population AS float ) - CAST( P1.population AS float ) ) / CAST( P1.population AS float ), 4) as popChange
  FROM Demographics P1
	INNER JOIN Demographics P2
  	ON P1.placeId = P2.placeId
  WHERE P1.placeId = @placeId
	AND P1.year = ( SELECT MIN(year)
                  	FROM Demographics
                  	WHERE placeId = @placeId )
	AND P2.year = ( SELECT MAX(year)
                  	FROM Demographics
                  	WHERE placeId = @placeId  )

END

GO
/****** Object:  StoredProcedure [dbo].[GetPovertyChange]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie Lee
-- Create date: 12/5/2016
-- Description:	Get Poverty Level change
-- =============================================
CREATE PROCEDURE [dbo].[GetPovertyChange] 
	-- Add the parameters for the stored procedure here
	@placeId bigInt = 5548000
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT 
   	ROUND(( CAST( E2.povertyLevel AS float ) - CAST( E1.povertyLevel AS float ) ) / CAST( E1.povertyLevel AS float ), 4) as popChange
  FROM Economy E1
	INNER JOIN Economy E2
  	ON E1.placeId = E2.placeId
  WHERE E1.placeId = @placeId
	AND E1.year = ( SELECT MIN(year)
                  	FROM Economy
                  	WHERE placeId = @placeId )
	AND E2.year = ( SELECT MAX(year)
                  	FROM Economy
                  	WHERE placeId = @placeId  )
END

GO
/****** Object:  StoredProcedure [dbo].[GetStateInfo]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie Lee
-- Create date: 12/4/2016
-- Description:	Find state average info based on Place ID
-- =============================================
CREATE PROCEDURE [dbo].[GetStateInfo] 
	-- Add the parameters for the stored procedure here
	@placeId bigint,
	@year bigint NULL = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 1 [State].name,
		[State].incomeTotal avgIncome, 
		[State].spendingEducation as avgEdu, 
		[State].spendingNaturalResources as avgNatRec,
		[State].spendingPublicWelfare as avgWelfare,
		[State].population as avgPop
	FROM PlaceIsIn
		INNER JOIN [State]
		  ON PlaceIsIn.stateName = [State].name
                                                                    AND PlaceIsIn.year = [State].year
	WHERE PlaceIsIn.placeId = @placeId
                                  AND PlaceIsIn.year = isnull(@year,(SELECT MAX(d2.year) FROM Demographics as d2 WHERE d2.placeId = @placeId))
END

GO
/****** Object:  StoredProcedure [dbo].[GetTopIndustries]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Genie Lee
-- Create date: 12/6/2016
-- Description:	Top industries in place
-- =============================================
CREATE PROCEDURE [dbo].[GetTopIndustries] 
	-- Add the parameters for the stored procedure here
	@placeId bigint = 5548000,
	@year bigint NULL = NULL
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT TOP 3 t1.type
	FROM Industry as t1
	WHERE t1.placeId = @placeId 
	AND t1.type <> 'Total'
	AND t1.year = ISNULL(@year,(SELECT max(t2.year) FROM Industry as t2 WHERE placeId = @placeId))
	ORDER BY t1.numberOfWorkers DESC
END

GO
/****** Object:  StoredProcedure [dbo].[placeNotes]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[placeNotes]
	@placeId bigint,
	@login varchar(50)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Note.content, Note.userLogin
	FROM Note
	WHERE Note.placeId = @placeId
	AND Note.userLogin <> @login
	ORDER BY Note.noteId DESC
END

GO
/****** Object:  StoredProcedure [dbo].[updateNote]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[updateNote]
	-- Add the parameters for the stored procedure here
	@noteId bigint,
	@content varchar(5000)
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	UPDATE Note
	SET Note.content = @content 
	WHERE Note.noteId = @noteId;
END

GO
/****** Object:  StoredProcedure [dbo].[UpdateUser]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateUser]
  @login [varchar](50) NULL,
  @password [varchar](500) NULL = NULL,
  @firstName [varchar](50) NULL = NULL,
  @lastName [varchar](50) NULL = NULL

AS
BEGIN
UPDATE [User]
SET 
   [password] = ISNULL( NULLIF( @password, '' ), [password] )
  ,[firstName] = @firstName
  ,[lastName] = @lastName
WHERE [login] = @login

END


GO
/****** Object:  StoredProcedure [dbo].[userNotes]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[userNotes]   
    @login varchar(50)
    --@usernotescursor cursor varying output  
as
begin
    set nocount on;  
	select note.noteid, note.content, place.name, note.placeid
	from note
      inner join place
		on note.placeid = place.placeid
	where note.userlogin = @login;
end
    
	/*set nocount on;  
    set @usernotescursor = cursor  
    forward_only static for  
      select place.name, note.content, note.timestamp
        from note
          inner join place
            on note.placeid = place.placeid
        where note.userlogin = @login
    open @usernotescursor;  */

GO
/****** Object:  StoredProcedure [dbo].[userPlaceNote]    Script Date: 12/12/2016 10:37:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[userPlaceNote] 
	-- Add the parameters for the stored procedure here
	@login varchar(50),
	@placeId bigint
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Note.noteId, Note.content FROM Note WHERE @placeId = Note.placeId AND @login = Note.userLogin;
END

GO
