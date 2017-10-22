CREATE PROCEDURE [dbo].[Quiz_Insert]
	@Category nvarchar(128),
	@Question nvarchar(max),
	@Answer1 nvarchar(max),
	@Answer2 nvarchar(max),
	@Answer3 nvarchar(max),
	@Answer4 nvarchar(max),
	@Correct int,
	@Id int OUTPUT
/*
Select * From 
dbo.Quiz

Declare  @_id int = 0
Declare  @_category nvarchar(128) = 'test category',
		 @_question nvarchar(max) = 'test question',
		 @_answer1 nvarchar(max) = 'answer 1',
		 @_answer2 nvarchar(max) = 'answer 2',
		 @_answer3 nvarchar(max) = 'answer 3',
		 @_answer4 nvarchar(max) = 'answer 4',
		 @_correct int = 1
Execute dbo.Quiz_Insert
		 @_category,
		 @_question,
		 @_answer1,
		 @_answer2,
		 @_answer3,
		 @_answer4, 
		 @_correct,
		 @_id OUTPUT


Select * From 
dbo.Quiz
*/
AS
BEGIN
INSERT INTO [dbo].[Quiz]
           ([Category]
           ,[Question]
           ,[Answer1]
           ,[Answer2]
           ,[Answer3]
           ,[Answer4]
		   ,[Correct])
     VALUES
           (@Category
           ,@Question
           ,@Answer1 
           ,@Answer2 
           ,@Answer3 
           ,@Answer4
		   ,@Correct)
	SET @Id = SCOPE_IDENTITY()
END
