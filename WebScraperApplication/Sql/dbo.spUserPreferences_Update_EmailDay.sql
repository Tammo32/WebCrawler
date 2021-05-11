CREATE PROCEDURE [dbo].[spUserPreferences_Update_EmailDay]
	@ID varchar(36),
	@EmailDay int
AS
BEGIN
	SET NOCOUNT ON;

	IF EXISTS (SELECT ID FROM dbo.UserPreferences WHERE ID = @ID)
		BEGIN
			UPDATE [dbo].[UserPreferences]
			SET EmailDay = @EmailDay
			WHERE ID = @ID
		END
END