using CodeQuiz.Model.Domain;
using CodeQuiz.Model.Requests;
using System.Collections.Generic;

namespace CodeQuiz.Controllers.Api
{
    internal interface IQuizService
    {
        List<Quiz> SelectAll();
        int Insert(QuizAddRequest model);
        void Update(QuizUpdateRequest model);
        void Delete(int id);
    }
}