using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuizMaker
{
    public class Answers
    {
        public List<string> answers { get; set; }
        public List<string> CorrectAnswers { get; set; }
        public Answers()
        {
            answers = new List<string>();
            CorrectAnswers = new List<string>();
        }
        public override string ToString()
        {
            return $"{answers} {CorrectAnswers}";
        }
    }
}
