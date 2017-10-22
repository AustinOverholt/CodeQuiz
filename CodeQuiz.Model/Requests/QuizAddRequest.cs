using System.ComponentModel.DataAnnotations;

namespace CodeQuiz.Model.Requests
{
    public class QuizAddRequest
    {
        [Required]
        public string Category { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        public string Answer1 { get; set; }

        [Required]
        public string Answer2 { get; set; }

        [Required]
        public string Answer3 { get; set; }

        [Required]
        public string Answer4 { get; set; }

        [Required]
        public int Correct { get; set; }
    }
}
