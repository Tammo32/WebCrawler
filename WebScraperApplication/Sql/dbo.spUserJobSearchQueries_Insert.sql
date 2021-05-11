CREATE PROCEDURE [dbo].[spUserJobSearchQueries_Insert]
	@ID varchar(36),
	@UserID nvarchar(450),
	@QueryUrl nvarchar(255)
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT ID FROM dbo.UserJobSearchQueries WHERE ID = @ID)
		BEGIN
			INSERT INTO [dbo].[UserJobSearchQueries] (ID, UserID, QueryUrl) 
			VALUES (@ID, @UserID, @QueryUrl);
		END
END