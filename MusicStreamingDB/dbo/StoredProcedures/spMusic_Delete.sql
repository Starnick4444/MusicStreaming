CREATE PROCEDURE [dbo].[spMusic_Delete]
	@Id varchar(50)
AS
begin
	delete
	from [dbo].Music
	where Id = @Id;
end
