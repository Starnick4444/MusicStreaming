CREATE PROCEDURE [dbo].[spMusic_Delete]
	@Title varchar(50)
AS
begin
	delete
	from [dbo].Music
	where [Title] = @Title;
end
