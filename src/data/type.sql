CREATE TABLE [dbo].[type]
(
  [type_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [name] NVARCHAR(1024) NOT NULL,
  [tenant_id] INT NOT NULL,
  FOREIGN KEY ([tenant_id]) REFERENCES [tenant]([tenant_id])
)
