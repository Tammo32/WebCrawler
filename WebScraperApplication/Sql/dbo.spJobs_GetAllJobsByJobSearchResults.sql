CREATE PROCEDURE [dbo].[spJobs_GetAllJobsByJobSearchResults]
	@UserID nvarchar(255),
	@JsrID varchar(36)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT  
	j.Title, j.Company, j.Availability, j.Description, j.Salary, j.Url
	FROM dbo.Jobs j
	INNER JOIN dbo.Jobs_JobSearchResults_Bridge jsrb 
	 ON jsrb.JobID = j.JobID
	INNER JOIN dbo.JobSearchResults jsr
	 ON jsr.UserID = jsrb.UserID
	WHERE jsr.UserID = @UserID AND jsr.ID = @JsrID

END
GO