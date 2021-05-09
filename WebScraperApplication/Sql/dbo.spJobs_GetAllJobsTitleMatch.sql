CREATE PROCEDURE [dbo].[spJobs_GetAllJobsTitleMatch]
	@Title nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT Title FROM [dbo].[Jobs] WHERE Title LIKE @Title

END
GO