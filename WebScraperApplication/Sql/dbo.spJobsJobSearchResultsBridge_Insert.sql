CREATE PROCEDURE [dbo].[spJobsJobSearchResultsBridge_Insert]
	@ID varchar(36),
	@JobID varchar(36),
	@UserID nvarchar(450)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT ID FROM dbo.Jobs_JobSearchResults_Bridge WHERE ID = @ID)
		BEGIN
			INSERT INTO [dbo].[Jobs_JobSearchResults_Bridge] (ID, JobID, UserID) 
			VALUES (@ID, @JobID, @UserID);
		END
END