using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeQuiz.Services;
using CodeQuiz.Model.Domain;
using System.Collections.Generic;
using CodeQuiz.Model.Requests;

namespace CodeQuiz.Tests
{
    [TestClass]
    public class QuizTest
    {
        //Instantiate Quiz Service
        QuizService svc = new QuizService();

        [TestMethod]
        public void SelectQuizTest()
        {
            List<Quiz> model = svc.SelectAll();
            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void SelectCatQuizTest()
        {
            List<Quiz> model = svc.SelectByCategory("C#");
            Assert.IsNotNull(model);
        }

        [TestMethod] 
        public void InsertQuizTest()
        {
            //string Category = "C#";
            //string Question = "?";
            //string Answer1 = "Idk";
            //string Answer2 = "Idk";
            //string Answer3 = "Idk";
            //string Answer4 = "IK";
            //string Correct = "4";

            QuizAddRequest model = new QuizAddRequest();

            model.Category = "C#";
            model.Question = "?";
            model.Answer1 = "IDK";
            model.Answer2 = "IDK";
            model.Answer3 = "IDK";
            model.Answer4 = "IK";
            model.Correct = 4;

            svc.Insert(model);

            Assert.IsNotNull(model);
        }

        [TestMethod]
        public void DeleteQuizTest()
        {

        }

        [TestMethod]
        public void UpdateQuizTest()
        {

        }
    }
}
