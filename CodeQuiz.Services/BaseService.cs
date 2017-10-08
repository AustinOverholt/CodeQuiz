using System.Configuration;

namespace CodeQuiz.Services
{
    public class BaseService
    {
        protected string connString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
    }
}
