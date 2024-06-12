using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ADHD_App.Models;
using Microsoft.VisualBasic;
using System.Collections.Generic;
using System.Text.Json;

namespace ADHD_App.Controllers
{
    [ApiController]
    [Route("api/AwnserController")]
    public class AwnserController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] JsonElement jsonPayload)
        {
            Console.WriteLine(jsonPayload);


            // // Deserialize the JSON payload into a list of MyTuple objects
             List<int[]> myTuples = JsonSerializer.Deserialize<List<int[]>>(jsonPayload.GetRawText());

            // // Process the received data as needed
            foreach (var tuple in myTuples)
            {
                 Console.WriteLine($"Question: {tuple[0]}, Answer: {tuple[1]}");
                // Do something with tuple.Item1 and tuple.Item2
            }

            return Ok("Data received successfully.");
        }
    }
}
