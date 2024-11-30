CREATE PROCEDURE [dbo].[QueryTenant]
  @TenantId INT
AS
  SELECT [tenant_id], [name], [is_enabled], [created_at], [updated_at] FROM [dbo].[tenant] WHERE [tenant_id] = @TenantId;
RETURN 0
