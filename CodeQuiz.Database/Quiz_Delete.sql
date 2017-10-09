CREATE PROCEDURE [dbo].[Quiz_Delete]
@Id int
/*
Select *
From dbo.Quiz

Declare @_id int = 4

Execute dbo.Quiz_Delete
	@_id

Select *
From dbo.Quiz
*/
AS
BEGIN
DELETE FROM [dbo].[Quiz]
      WHERE Id = @Id
END
