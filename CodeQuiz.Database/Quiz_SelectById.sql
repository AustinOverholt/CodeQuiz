CREATE PROCEDURE [dbo].[Quiz_SelectById]
	@Id int
/*
Declare @_id int = 1
Execute dbo.Quiz_SelectById 
	@_id 
*/
AS
BEGIN
SELECT [Id]
      ,[Category]
      ,[Question]
      ,[Answer1]
      ,[Answer2]
      ,[Answer3]
      ,[Answer4]
  FROM [dbo].[Quiz]
  WHERE Id = @Id
END

