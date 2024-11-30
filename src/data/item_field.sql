CREATE TABLE [dbo].[item_field]
(
  [item_field_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [item_id] INT NOT NULL,
  [type_field_id] INT NOT NULL,
  [value] VARBINARY(MAX) NOT NULL
  FOREIGN KEY ([item_id]) REFERENCES [item]([item_id]),
  FOREIGN KEY ([type_field_id]) REFERENCES [type_field]([type_field_id])
)
