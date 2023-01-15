CREATE PROCEDURE [dbo].[spMusic_Get]
	@Title nvarchar(50)
AS
begin
	SELECT [Title], [Path], [Description], [Extension] from [dbo].Music
	WHERE [Title] = @Title
end
