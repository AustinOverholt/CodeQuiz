using CodeQuiz.Model.Domain;
using CodeQuiz.Model.Requests;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CodeQuiz.Services.Interfaces
{
    public interface IQuizService
    {
        List<Quiz> SelectAll();
        List<Quiz> SelectByCategory(string Category);
        Quiz SelectById(int Id);
        int Insert(QuizAddRequest model);
        void Update(QuizUpdateRequest model);
        void Delete(int id);
    }
}
