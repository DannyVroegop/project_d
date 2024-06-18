using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ADHD_App.Models;
using ADHD_App.Services;



namespace ADHD_App.Controllers
{
    [ApiController]
    [Route("api/ExerciseController")]
    public class ExerciseController : ControllerBase
    {
        private JsonFileHandler _json;
        public ExerciseController(JsonFileHandler json)
        {
            _json = json;
        }

        [HttpGet]
        public List<QuestionAnswerPair> Get()
        {
            var listOfQuestionAndAwnsers = _json.GetAllExercises();
            string vak = Request.Query["vak"];
            int progress = int.Parse(Request.Query["progress"]);
            listOfQuestionAndAwnsers = listOfQuestionAndAwnsers.FindAll(x => x.Subject == vak && x.Progresslevel == progress);


            string[] awnsers = new string[3];
            awnsers[0] = listOfQuestionAndAwnsers[0].QuestionsAndAnswers[0].Answer;
            awnsers[1] = listOfQuestionAndAwnsers[0].QuestionsAndAnswers[1].Answer;
            awnsers[2] = listOfQuestionAndAwnsers[0].QuestionsAndAnswers[2].Answer;
            Shuffle(awnsers);

            QuestionAnswerPair a1 = new QuestionAnswerPair(listOfQuestionAndAwnsers[0].QuestionsAndAnswers[0].Question, awnsers[0]);
            QuestionAnswerPair a2 = new QuestionAnswerPair(listOfQuestionAndAwnsers[0].QuestionsAndAnswers[1].Question, awnsers[1]);
            QuestionAnswerPair a3 = new QuestionAnswerPair(listOfQuestionAndAwnsers[0].QuestionsAndAnswers[2].Question, awnsers[2]);




            return new List<QuestionAnswerPair>
            {
                a1,
                a2,
                a3

            };
        }
    public static void Shuffle(string[] array)
    {
        Random rng = new Random();
        int n = array.Length;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            string value = array[k];
            array[k] = array[n];
            array[n] = value;
        }
    }
    }
}
