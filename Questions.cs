using System;
using System.Xml.Serialization;
namespace QuizMaker
{
    public class Questions
    {
        public List<string> questions { get; set; }
      
        public Questions()
        {
            questions = new List<string>();
            
        }

        public override string ToString()
        {
            Questions content = new Questions();
            return $"{content.questions}";
        }

    }

}

































