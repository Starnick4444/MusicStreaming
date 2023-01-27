CREATE PROCEDURE [dbo].[spMusic_Insert]
	@Title varchar(50),
	@Description varchar(255),
	@Extension nchar(10)
AS
begin
	insert into [dbo].Music (Title, [Description], [Extension])
	values (@Title, @Description, @Extension);
	select SCOPE_IDENTITY();
end
