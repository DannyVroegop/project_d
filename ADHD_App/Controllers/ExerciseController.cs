using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ADHD_App.Models;

namespace ADHD_App.Controllers
{
    [ApiController]
    [Route("api/ExerciseController")]
    public class ExerciseController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<QuestionAnswerPair> Get()
        {
            List<QuestionAnswerPair> questionsAndAnswers = new List<QuestionAnswerPair>();
            
            return new List<QuestionAnswerPair>
            {
                new QuestionAnswerPair { Question = "What is C#?", Answer = "A programming language." },
                new QuestionAnswerPair { Question = "What is ASP.NET?", Answer = "A web framework." },
                new QuestionAnswerPair { Question = "hallo", Answer = "doei" },

            };
        }
    }
}
