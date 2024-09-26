DROP PROCEDURE IF EXISTS CreateUser

GO;


CREATE PROCEDURE CreateUser (
	@Username TEXT,
	@Password Text

)
AS
BEGIN

DECLARE @sql Text

SET @sql = 'CREATE User ' + @username + ' WITH PASSWORD = ''' + @Password + ''', DEFAULT_DATABASE='+@username+' , CHECK_POLICY = OFF;'
EXEC @sql;


end
GO;