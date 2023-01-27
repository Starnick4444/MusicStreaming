CREATE PROCEDURE [dbo].[spMusic_GetByTitle]
	@Title varchar(50)
AS
begin
	SELECT [Id] ,[Title], [Description], [Extension] from [dbo].Music
	WHERE [Title] = @Title
end
