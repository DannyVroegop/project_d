using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ADHD_App.Models;
using ADHD_App.Services;


namespace ADHD_App.Controllers
{
    [ApiController]
    [Route("api/SubjectAndProgressController")]
    public class SubjectAndProgressController : ControllerBase
    {
        private JsonFileHandler _json;
        public SubjectAndProgressController(JsonFileHandler json)
        {
            _json = json;
        }

        [HttpGet]
        public IEnumerable<List<SubjectProgress>> Get()
        {
            var subjectprogress = _json.GetAllPeople().Where(x => x.Id == int.Parse(Request.Cookies["id"])).Select(x => x.SubjectProgress);
            return subjectprogress;
            // List<SubjectProgress> questionsAndAnswers = new List<SubjectProgress>();
            
            // return new List<SubjectProgress>
            // {
            //     new QuestionAnswerPair { Question = "What is C#?", Answer = "A programming language." },
            //     new QuestionAnswerPair { Question = "What is ASP.NET?", Answer = "A web framework." },
            //     new QuestionAnswerPair { Question = "hallo", Answer = "doei" },

            // };
        }
    }
}
