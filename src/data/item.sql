CREATE TABLE [dbo].[item]
(
  [item_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [name] NVARCHAR(1024) NOT NULL,
  [description] NVARCHAR(MAX) NULL,
  [type_id] INT NOT NULL,
  [tenant_id] INT NOT NULL,
  FOREIGN KEY ([type_id]) REFERENCES [type]([type_id]),
  FOREIGN KEY ([tenant_id]) REFERENCES [tenant]([tenant_id])
)