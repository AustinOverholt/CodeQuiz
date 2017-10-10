using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuiz.Model.Requests
{
    public class QuizUpdateRequest : QuizAddRequest
    {
        public int Id { get; set; }
    }
}
