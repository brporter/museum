CREATE PROCEDURE [dbo].[EstablishTenant]
  @Name NVARCHAR(2048)
AS
  INSERT INTO [dbo].[tenant] ([name]) VALueS (@Name);
  
RETURN SCOPE_IDENTITY()
