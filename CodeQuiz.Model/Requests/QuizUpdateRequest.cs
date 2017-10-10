using System.ComponentModel.DataAnnotations;

namespace CodeQuiz.Model.Requests
{
    public class QuizUpdateRequest : QuizAddRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
