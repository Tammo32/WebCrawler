IF NOT EXISTS (SELECT * FROM [dbo].[UserPreferences] WHERE ID = 1)
BEGIN
	INSERT INTO [dbo].[UserPreferences]
	([ID]
	,[UserID]
	,[EmailFrequency]
	, [Count])
	VALUES
	(1,'0a437e84-a886-4678-af63-c563a62772c0', 1, 2)
END

IF NOT EXISTS (SELECT * FROM [dbo].[JobSearchResults] WHERE ID = 1)
BEGIN
	INSERT INTO [dbo].[JobSearchResults]
	([ID]
	,[UserID]
	,[ResultsDate])
	VALUES
	(1,'0a437e84-a886-4678-af63-c563a62772c0', '05/05/2021 7:09 pm')
END