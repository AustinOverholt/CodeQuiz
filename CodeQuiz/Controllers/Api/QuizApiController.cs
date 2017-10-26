using CodeQuiz.Model.Domain;
using CodeQuiz.Model.Requests;
using CodeQuiz.Model.Responses;
using CodeQuiz.Services;
using CodeQuiz.Services.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Collections.Generic;

namespace CodeQuiz.Controllers.Api
{
    [RoutePrefix("api/quiz")]
    public class QuizApiController : ApiController
    {
        private IQuizService _quizService;
        public QuizApiController(IQuizService quizService)
        {
            _quizService = quizService;
        }

        public QuizApiController()
        {
            _quizService = new QuizService();
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

        [Route("{category}"), HttpGet]
        public HttpResponseMessage GetByCategory(string category)
        {
            try
            {
                ItemsResponse<Quiz> resp = new ItemsResponse<Quiz>();
                resp.Items = _quizService.SelectByCategory(category);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                ItemResponse<Quiz> resp = new ItemResponse<Quiz>();
                resp.item = _quizService.SelectById(id);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

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
                resp.item = _quizService.Insert(model); // inserts http post model into insert service
                return Request.CreateResponse(HttpStatusCode.OK, resp); // if good returns status code and response
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex); // exception handled here
            }
        }

        [Route(), HttpPut] // Sets api endpoint and http type
        public HttpResponseMessage Update(QuizUpdateRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
            try
            {
                SuccessResponse resp = new SuccessResponse();
                _quizService.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                SuccessResponse resp = new SuccessResponse();
                _quizService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, resp);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}