CREATE TABLE [dbo].[container]
(
  [container_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [name] NVARCHAR(1024) NOT NULL,
  [description] NVARCHAR(MAX) NULL,
  [parent_container_id] INT NULL,
  [container_type_id] INT NOT NULL,
  [tenant_id] INT NOT NULL,
  FOREIGN KEY ([parent_container_id]) REFERENCES [container]([container_id]),
  FOREIGN KEY ([container_type_id]) REFERENCES [container_type]([container_type_id]),
  FOREIGN KEY ([tenant_id]) REFERENCES [tenant]([tenant_id])
)
