CREATE PROCEDURE [dbo].[Quiz_SelectAll]	
/*
Execute dbo.Quiz_SelectAll
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
END