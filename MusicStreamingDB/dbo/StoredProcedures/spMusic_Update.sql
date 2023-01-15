CREATE PROCEDURE [dbo].[spMusic_Update]
	@Title varchar(50),
	@Path varchar(100),
	@Description varchar(255),
	@Extension nchar(10)
AS
begin
	update [dbo].[Music]
	set [Path] = @Path, [Description] = @Description, [Extension] = @Extension
	where [Title] = @Title;
end
