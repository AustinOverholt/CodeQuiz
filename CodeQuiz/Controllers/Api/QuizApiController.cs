using CodeQuiz.Model.Domain;
using CodeQuiz.Model.Requests;
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

        // Get By Id

        [Route(), HttpPost]
        public HttpResponseMessage Post(QuizAddRequest model)
        {
            if (!ModelState.IsValid) // checks if input is valid
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState); // if not sends error
            }
            try
            {
                ItemResponse<int> resp = new ItemResponse<int>(); // instantiates an item for id
                resp.item = quizService.Insert(model); // inserts http post model into insert service
                return Request.CreateResponse(HttpStatusCode.OK, resp); // if good returns status code and response
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex); // exception handled here
            }
        }
    }
}