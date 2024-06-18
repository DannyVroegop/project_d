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
        public List<Exercise> Get()
        {
            var subjectprogress = _json.GetAllPeople().Where(x => x.Id == int.Parse(Request.Cookies["id"])).Select(x => x.SubjectProgress);
            var listOfQuestionAndAwnsers = _json.GetAllExercises();
            List<Exercise> exercises = new List<Exercise>();

            foreach (var item in subjectprogress)
            {
                foreach (var item2 in item)
                {
           

                    Exercise add = listOfQuestionAndAwnsers.FirstOrDefault(x => x.Subject == item2.Subject && x.Progresslevel == item2.Progresslevel);

                    Exercise a1 = new Exercise(item2.Subject, item2.Progresslevel, add.Type);
                    exercises.Add(a1);
                }
            }





            return exercises;
            // List<SubjectProgress> questionsAndAnswers = new List<SubjectProgress>();

            // return new List<SubjectProgress>
            // {
            //     new QuestionAnswerPair { Question = "What is C#?", Answer = "A programming language." },
            //     new QuestionAnswerPair { Question = "What is ASP.NET?", Answer = "A web framework." },
            //     new QuestionAnswerPair { Question = "hallo", Answer = "doei" },

            // };
        }
        [HttpPost("updateProgress")]
        public IActionResult UpdateProgress([FromQuery] int userId, [FromQuery] string subject)
        {
            var result = _json.UpdateProgressLevel(userId, subject);
            if (result) return Ok();
            return BadRequest();
        }
    }
}
