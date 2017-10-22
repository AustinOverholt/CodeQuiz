CREATE PROCEDURE [dbo].[Quiz_Update]
	@Category nvarchar(max)
	,@Question nvarchar(max)
	,@Answer1 nvarchar(max)
	,@Answer2 nvarchar(max)
	,@Answer3 nvarchar(max)
	,@Answer4 nvarchar(max)
	,@Correct int
	,@Id int
/*
Declare @_id int = 1
Declare @_category nvarchar(128) = 'new category'
		,@_question nvarchar(max) = 'new question'
		,@_answer1 nvarchar(max) = 'new answer 1'
		,@_answer2 nvarchar(max) = 'new answer 2'
		,@_answer3 nvarchar(max) = 'new answer 3'
		,@_answer4 nvarchar(max) = 'new answer 4'
		,@_correct int = 1
Select * 
From dbo.Quiz 
Where Id = @_id
Execute dbo.Quiz_Update
	@_category
	,@_question
	,@_answer1
	,@_answer2
	,@_answer3
	,@_answer4
	,@_correct
	,@_id
Select *
From dbo.Quiz
Where Id = @_id
*/
AS
BEGIN
UPDATE [dbo].[Quiz]
   SET [Category] = @Category
      ,[Question] = @Question
      ,[Answer1] = @Answer1
      ,[Answer2] = @Answer2
      ,[Answer3] = @Answer3
      ,[Answer4] = @Answer4
	  ,[Correct] = @Correct
 WHERE Id = @Id
END