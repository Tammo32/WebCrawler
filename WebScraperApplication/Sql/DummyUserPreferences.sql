IF NOT EXISTS (SELECT * FROM [dbo].[UserPreferences] WHERE ID = 1)
BEGIN
	INSERT INTO [dbo].[UserPreferences]
	([ID]
	,[UserID]
	,[EmailFrequency]
	, [EmailDay])
	VALUES
	('00c85f13-5456-44a5-acad-954f3557e620','0a437e84-a886-4678-af63-c563a62772c0', 1, 0)
END

IF NOT EXISTS (SELECT * FROM [dbo].[JobSearchResults] WHERE ID = 1)
BEGIN
	INSERT INTO [dbo].[JobSearchResults]
	([ID]
	,[UserID]
	,[ResultsDate])
	VALUES
	('09a32899-cc87-4303-adbd-6cf81499bc3a','0a437e84-a886-4678-af63-c563a62772c0', '05/05/2021 7:09 pm')
END