CREATE PROCEDURE [dbo].[spMusic_Update]
	@Title varchar(50),
	@Description varchar(255),
	@Extension nchar(10)
AS
begin
	update [dbo].[Music]
	set [Description] = @Description, [Extension] = @Extension
	where [Title] = @Title;
end
