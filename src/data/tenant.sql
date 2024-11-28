CREATE TABLE [dbo].[tenant]
(
  [tenant_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [name] NVARCHAR(2048) NOT NULL,
)
