using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADHD_App.Models
{
    public class Exercise
    {
        public string Subject {get;set;}
        public int Progresslevel {get;set;}
        public string Type {get;set;}
        public List<QuestionAnswerPair> QuestionsAndAnswers { get; set; }
        public Exercise()
        {
            QuestionsAndAnswers = new List<QuestionAnswerPair>();
        }

        
    }

    public class QuestionAnswerPair
    {
        public string Question { get; set; }
        public string Answer { get; set; }
        public QuestionAnswerPair(string question, string answer)
        {
            Question = question;
            Answer = answer;
        }
    }

    public class SubjectProgress
    {
        public string Subject { get; set; }
        public int Progresslevel { get; set; }
    }
}