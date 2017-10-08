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
        [TestMethod]
        public void SelectQuizTest()
        {
            QuizService svc = new QuizService();
            List<Quiz> model = svc.SelectAll();
            Assert.IsNotNull(model);
        }
    }
}
