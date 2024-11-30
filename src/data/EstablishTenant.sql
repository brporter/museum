CREATE PROCEDURE [dbo].[EstablishTenant]
  @Name NVARCHAR(2048),
  @TenantId INT OUTPUT,
  @CreatedAt DATETIME2 OUTPUT,
  @UpdatedAt DATETIME2 OUTPUT
AS
BEGIN
  SET @CreatedAt = SYSUTCDATETIME();
  SET @UpdatedAt = @CreatedAt;

  INSERT INTO [dbo].[tenant] ([name], [created_at], [updated_at], [is_enabled]) VALUES (@Name, @CreatedAt, @UpdatedAt, 1);
  
  SET @TenantId = SCOPE_IDENTITY();
END
