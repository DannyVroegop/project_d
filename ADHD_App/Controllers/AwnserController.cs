using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ADHD_App.Models;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Text.Json;
using Newtonsoft.Json.Linq;

namespace ADHD_App.Controllers
{
    [ApiController]
    [Route("api/AwnserController")]
    public class AwnserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] JsonElement jsonPayload)
        {
            QuestionAnswerPair [] arr = new QuestionAnswerPair [2];
            for(int i = 0; i < jsonPayload.GetArrayLength(); i++)
            {
                JObject json = JObject.Parse(jsonPayload[i].ToString());

                QuestionAnswerPair pair = new QuestionAnswerPair((string)json["question"], (string)json["answer"]);
                arr[i] = pair;
            }
            


            // // Deserialize the JSON payload into a list of MyTuple objects
            // List<string[]> myTuples = JsonSerializer.Deserialize<List<string[]>>(jsonPayload.GetRawText());

            // // // Process the received data as needed
            // foreach (var tuple in myTuples)
            // {
            //      Console.WriteLine($"Question: {tuple[0]}, Answer: {tuple[1]}");
            //     // Do something with tuple.Item1 and tuple.Item2
            // }

            return Ok("Data received successfully.");
        }
    }
}
