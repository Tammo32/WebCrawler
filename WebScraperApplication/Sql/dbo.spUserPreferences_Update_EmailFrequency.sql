CREATE PROCEDURE [dbo].[spUserPreferences_Update_EmailFrequency]
	@ID varchar(36),
	@EmailFrequency int
AS
BEGIN
	SET NOCOUNT ON;
	IF EXISTS (SELECT ID FROM dbo.UserPreferences WHERE ID = @ID)
		BEGIN
			UPDATE [dbo].[UserPreferences]
			SET EmailFrequency = @EmailFrequency
			WHERE ID = @ID
		END
END