CREATE PROCEDURE [dbo].[spMusic_GetAll]
AS
begin
	SELECT [Title], [Path], [Description], [Extension] from [dbo].Music
end