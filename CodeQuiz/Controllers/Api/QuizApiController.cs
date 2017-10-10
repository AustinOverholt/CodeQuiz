using System.Collections.Generic;
using System.Web.Http;
using CodeQuiz.Model.Domain;
using CodeQuiz.Model.Requests;

namespace CodeQuiz.Controllers.Api
{
    [RoutePrefix("api/quiz")]
    public class QuizApiController : ApiController, IQuizService
    {
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(QuizAddRequest model)
        {
            throw new System.NotImplementedException();
        }

        public List<Quiz> SelectAll()
        {
            throw new System.NotImplementedException();
        }

        public void Update(QuizUpdateRequest model)
        {
            throw new System.NotImplementedException();
        }
    }
}