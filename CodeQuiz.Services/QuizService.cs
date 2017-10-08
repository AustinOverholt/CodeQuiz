using CodeQuiz.Model.Domain;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace CodeQuiz.Services
{
    public class QuizService : BaseService
    {
        // Select All Quizzes
        public List<Quiz> SelectAll()
        {
            List<Quiz> quizList = new List<Quiz>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Quiz_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Quiz model = Mapper(reader);
                        quizList.Add(model);
                    }
                }
                conn.Close();
            }
            return quizList;
        }

        // Insert Quiz

        // Mapper
        private Quiz Mapper(SqlDataReader reader)
        {
            Quiz model = new Quiz();
            int index = 0;

            model.Id = reader.GetInt32(index++);
            model.Category = reader.GetString(index++);
            model.Question = reader.GetString(index++);
            model.Answer1 = reader.GetString(index++);
            model.Answer2 = reader.GetString(index++);
            model.Answer3 = reader.GetString(index++);
            model.Answer4 = reader.GetString(index++);

            return model;
        }

    }
}
