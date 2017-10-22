CREATE PROC [dbo].[Quiz_SelectByCategory]
	@Category nvarchar(128)
/*
Declare @_category nvarchar(128)  = 'C#'
Execute dbo.Quiz_SelectByCategory 
	@_category
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
	  ,[Correct]
  FROM [dbo].[Quiz]
  WHERE Category = @Category
END