using CodeQuiz.Model.Domain;
using CodeQuiz.Model.Requests;
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

        // Select By Category
        public List<Quiz> SelectByCategory(string Category)
        {
            List<Quiz> quizList = new List<Quiz>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Quiz_SelectByCategory", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Category", Category);
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

        // Select By Id
        public Quiz SelectById(int Id)
        {
            Quiz singleQuiz = new Quiz();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Quiz_SelectById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", Id);
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                         singleQuiz = Mapper(reader);
                    }
                }
                conn.Close();
            }
            return singleQuiz;
        }

        // Insert Quiz
        public int Insert(QuizAddRequest model)
        {
            int id = 0;

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Quiz_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Category", model.Category);
                    cmd.Parameters.AddWithValue("@Question", model.Question);
                    cmd.Parameters.AddWithValue("@Answer1", model.Answer1);
                    cmd.Parameters.AddWithValue("@Answer2", model.Answer2);
                    cmd.Parameters.AddWithValue("@Answer3", model.Answer3);
                    cmd.Parameters.AddWithValue("@Answer4", model.Answer4);
                    cmd.Parameters.AddWithValue("@Correct", model.Correct);

                    SqlParameter parm = new SqlParameter("@Id", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);

                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;
                }
                conn.Close();
            }
            return id;
        }

        // Quiz Update 
        public void Update(QuizUpdateRequest model)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Quiz_Update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@Category", model.Category);
                    cmd.Parameters.AddWithValue("@Question", model.Question);
                    cmd.Parameters.AddWithValue("@Answer1", model.Answer1);
                    cmd.Parameters.AddWithValue("@Answer2", model.Answer2);
                    cmd.Parameters.AddWithValue("@Answer3", model.Answer3);
                    cmd.Parameters.AddWithValue("@Answer4", model.Answer4);
                    cmd.Parameters.AddWithValue("@Correct", model.Correct);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        // Quiz Delete
        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("dbo.Quiz_Delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

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
            model.Correct = reader.GetInt32(index++);

            return model;
        }
    }
}
