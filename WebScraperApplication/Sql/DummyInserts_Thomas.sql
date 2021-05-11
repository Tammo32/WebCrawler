IF NOT EXISTS (SELECT * FROM [dbo].[UserPreferences] WHERE ID = 1)
BEGIN
	INSERT INTO [dbo].[UserPreferences]
	([ID]
	,[UserID]
	,[EmailFrequency]
	, [Count])
	VALUES
	(1,'2ca67394-19dd-4cd6-9056-ad957d93346f', 1, 2)
END

IF NOT EXISTS (SELECT * FROM [dbo].[JobSearchResults] WHERE ID = 1)
BEGIN
	INSERT INTO [dbo].[JobSearchResults]
	([ID]
	,[UserID]
	,[ResultsDate])
	VALUES
	(1,'2ca67394-19dd-4cd6-9056-ad957d93346f', '05/05/2021 7:09 pm')
END