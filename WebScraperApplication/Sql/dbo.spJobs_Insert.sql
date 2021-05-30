CREATE PROCEDURE [dbo].[spJobs_Insert]
	@JobID varchar(36),
	@Title nvarchar(255),
	@Company nvarchar(255),
	@Description text,
	@Availability nvarchar(10),
	@Url nvarchar(450),
	@Salary varchar(7)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT JobID FROM dbo.Jobs WHERE JobID = @JobID)
		BEGIN
			INSERT INTO [dbo].[Jobs] (JobID, Title, Company, [Description], [Availability], [Url], Salary) 
			VALUES (@JobID, @Title, @Company, @Description, @Availability, @Url, @Salary);
		END
END
