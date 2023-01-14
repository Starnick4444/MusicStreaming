CREATE PROCEDURE [dbo].[spMusic_Insert]
	@Title varchar(50),
	@Path varchar(100),
	@Description varchar(255),
	@Extension nchar(10)
AS
begin
	insert into [dbo].Music (Title, [Path], [Description], [Extension])
	values (@Title, @Path, @Description, @Extension);
end
