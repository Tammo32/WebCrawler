CREATE PROCEDURE [dbo].[spJobs_BriefInsert]
	@id nvarchar(450),
	@Title nvarchar(255),
	@Company nvarchar(255),
	@BriefDescription nvarchar(255),
	@Availability nvarchar(10),
	@Url nvarchar(450),
	@StartingSalary nvarchar(7),
	@EndingSalary nvarchar(7)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT JobID FROM dbo.Jobs WHERE JobID = @id)
		BEGIN
			INSERT INTO dbo.Jobs (JobID, Title, Company, BriefDescription, [Availability], [Url], StartingSalary, EndingSalary) 
			VALUES (@id, @Title, @Company, @BriefDescription, @Availability, @Url, @StartingSalary, @EndingSalary);
		END
END
GO