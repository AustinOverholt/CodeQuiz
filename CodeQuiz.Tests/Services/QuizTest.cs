using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeQuiz.Services;
using CodeQuiz.Model.Domain;
using System.Collections.Generic;

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
