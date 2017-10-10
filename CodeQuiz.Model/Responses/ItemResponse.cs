using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeQuiz.Model.Responses
{
    public class ItemResponse<T> : SuccessResponse
    {
        public T item { get; set; }
    }
}
