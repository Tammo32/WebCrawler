CREATE PROCEDURE [dbo].[spJobSearchResults_Insert]
	@ID varchar(36),
	@UserID nvarchar(450),
	@ResultsDate datetime
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT ID FROM dbo.JobSearchResults WHERE ID = @ID)
		BEGIN
			INSERT INTO [dbo].[JobSearchResults] (ID, UserID, ResultsDate) 
			VALUES (@ID, @UserID, @ResultsDate);
		END
END