using System.Collections.Generic;
using System.Web.Http;
using CodeQuiz.Model.Domain;
using CodeQuiz.Model.Requests;
using System.Net.Http;
using System;
using System.Net;
using CodeQuiz.Model.Responses;

namespace CodeQuiz.Controllers.Api
{
    [RoutePrefix("api/quiz")]
    public class QuizApiController : ApiController
    {
        private IQuizService _quizService;
        
        public QuizApiController(IQuizService QuizService)
        {
            _quizService = QuizService;
        }
        [Route(), HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                ItemsResponse<Quiz> resp = new ItemsResponse<Quiz>();
                resp.Items = _quizService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public int Insert(QuizAddRequest model)
        {
            throw new System.NotImplementedException();
        }

        public void Update(QuizUpdateRequest model)
        {
            throw new System.NotImplementedException();
        }
    }
}