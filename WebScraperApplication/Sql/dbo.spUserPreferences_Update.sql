CREATE PROCEDURE [dbo].[spUserPreferences_Update]
	@ID varchar(36),
	@EmailFrequency int,
	@EmailDay int
AS
BEGIN

	SET NOCOUNT ON;

	IF EXISTS (SELECT ID FROM dbo.UserPreferences WHERE ID = @ID)
		BEGIN
			UPDATE [dbo].[UserPreferences]
			SET EmailFrequency = @EmailFrequency, EmailDay = @EmailDay
			WHERE ID = @ID
		END
END