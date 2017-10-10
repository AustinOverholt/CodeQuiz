using CodeQuiz.Model.Domain;
using CodeQuiz.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuiz.Services.Interfaces
{
    public interface IQuizService
    {
        List<Quiz> SelectAll();
        int Insert(QuizAddRequest model);
        void Update(QuizUpdateRequest model);
        void Delete(int id);
    }
}
