using Microsoft.AspNetCore.Mvc;
using ADHD_App.Models;
using System.Text.Json;
using Newtonsoft.Json.Linq;
using ADHD_App.Services;
using System.Formats.Tar;


namespace ADHD_App.Controllers
{
    [ApiController]
    [Route("api/AwnserController")]
    public class AwnserController : ControllerBase
    {
        private JsonFileHandler _json;
        public AwnserController(JsonFileHandler json)
        {
            _json = json;
        }
        [HttpPost]
        public IActionResult Post([FromBody] JsonElement jsonPayload)
        {
            QuestionAnswerPair[] arr = new QuestionAnswerPair[jsonPayload.GetArrayLength()];
            for (int i = 0; i < jsonPayload.GetArrayLength(); i++)
            {
                JObject json = JObject.Parse(jsonPayload[i].ToString());

                QuestionAnswerPair pair = new QuestionAnswerPair((string)json["question"], (string)json["answer"]);
                arr[i] = pair;
            }
            var listOfQuestionAndAwnsers = _json.GetAllExercises();
            int score = 0;
            string vak = "";
            int currProgress = 0;
            foreach (var item in listOfQuestionAndAwnsers)
            {

                foreach (var question in item.QuestionsAndAnswers)
                {
                    foreach (var a in arr)
                    {
                        if (question.Question == a.Question)
                        {
                            if (question.Answer == a.Answer)
                            {
                                score++;
                                vak = item.Subject;
                                currProgress = item.Progresslevel;
                            }
                        }
                    }
                }
            }

            if (score >= 3)
            {
                _json.UpdateSubjectProgress(int.Parse(Request.Cookies["id"]), vak, currProgress + 1);
                return Ok("{\"result\": \"goed\"}");

            }
            return Ok("{\"result\": \"fout\"}");

        }
    }
}
