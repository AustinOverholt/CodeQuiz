using CodeQuiz.Model.Domain;
using CodeQuiz.Model.Responses;
using CodeQuiz.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CodeQuiz.Controllers.Api
{
    [RoutePrefix("api/quiz")]
    public class QuizApiController : ApiController
    {
        QuizService quizService = new QuizService();

        [Route(), HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                ItemsResponse<Quiz> resp = new ItemsResponse<Quiz>();
                resp.Items = quizService.SelectAll();
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}