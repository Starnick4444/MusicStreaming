CREATE PROCEDURE [dbo].[spMusic_Get]
	@Title varchar(50)
AS
begin
	SELECT [Title], [Path], [Description], [Extension] from [dbo].Music
	WHERE [Title] = @Title
end
