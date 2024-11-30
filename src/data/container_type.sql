CREATE TABLE [dbo].[container_type]
(
  [container_type_id] INT NOT NULL PRIMARY KEY IDENTITY(1,1),
  [name] NVARCHAR(1024) NOT NULL,
  [description] NVARCHAR(MAX) NULL
)
