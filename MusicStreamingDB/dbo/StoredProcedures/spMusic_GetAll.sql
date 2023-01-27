CREATE PROCEDURE [dbo].[spMusic_GetAll]
AS
begin
	SELECT [Id], [Title], [Description], [Extension] from [dbo].Music
end