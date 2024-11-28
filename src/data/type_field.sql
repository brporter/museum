CREATE TABLE [dbo].[type_field]
(
  [type_field_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [name] NVARCHAR(1024) NOT NULL,
  [description] NVARCHAR(MAX) NOT NULL,
  [type_id] INT NOT NULL,
  FOREIGN KEY ([type_id]) REFERENCES [type]([type_id])
)
