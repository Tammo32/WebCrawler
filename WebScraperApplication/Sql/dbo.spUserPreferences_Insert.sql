CREATE PROCEDURE [dbo].[spUserPreferences_Insert]
	@ID varchar(36),
	@UserID nvarchar(450),
	@EmailFrequency int,
	@EmailDay int
AS
BEGIN
	SET NOCOUNT ON;

	IF NOT EXISTS (SELECT ID FROM dbo.UserPreferences WHERE ID = @ID)
		BEGIN
			INSERT INTO [dbo].[UserPreferences] (ID, UserID, EmailFrequency, EmailDay) 
			VALUES (@ID, @UserID, @EmailFrequency, @EmailDay);
		END
END