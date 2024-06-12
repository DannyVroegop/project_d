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
            // Console.WriteLine(vak);
            // Console.WriteLine(progress);
            // foreach (var qa in listOfQuestionAndAwnsers)
            // {
            //     Console.WriteLine("hi");
            //     Console.WriteLine(listOfQuestionAndAwnsers[0].QuestionsAndAnswers[2].Question);

            //     foreach (var questionAndAnswer in qa.QuestionsAndAnswers)
            //     {
            //         Console.WriteLine($"Question: {questionAndAnswer.Question}, Answer: {questionAndAnswer.Answer}");
            //     }
            // }


            QuestionAnswerPair a1 = new QuestionAnswerPair(listOfQuestionAndAwnsers[0].QuestionsAndAnswers[0].Question, listOfQuestionAndAwnsers[0].QuestionsAndAnswers[0].Answer);
            QuestionAnswerPair a2 = new QuestionAnswerPair(listOfQuestionAndAwnsers[0].QuestionsAndAnswers[1].Question, listOfQuestionAndAwnsers[0].QuestionsAndAnswers[1].Answer);
            QuestionAnswerPair a3 = new QuestionAnswerPair(listOfQuestionAndAwnsers[0].QuestionsAndAnswers[2].Question, listOfQuestionAndAwnsers[0].QuestionsAndAnswers[2].Answer);

            // Print the questions and answers
            // foreach (var qa in listOfQuestionAndAwnsers)
            // {
            //     foreach (var questionAndAnswer in qa.QuestionsAndAnswers)
            //     {
            //         Console.WriteLine($"Question: {questionAndAnswer.Question}, Answer: {questionAndAnswer.Answer}");
            //     }


            // }

            // var temp = listOfQuestionAndAwnsers.Select(x => x.QuestionsAndAnswers);
            // return temp.ToList()[0];

            // List<QuestionAnswerPair> questionsAndAnswers = new List<QuestionAnswerPair>();

            return new List<QuestionAnswerPair>
            {
                a1,
                a2,
                a3

            };
        }
    }
}
