using System;
using System.Xml.Serialization;
namespace QuizMaker
{
    public class QnAContent
    {
        public List<string> Questions { get; set; }
        public List<string> Answers { get; set; }
        public List<string> CorrectAnswers { get; set; }
        public QnAContent()
        {
            Questions = new List<string>();
            Answers = new List<string>();
            CorrectAnswers = new List<string>();
        }

        public override string ToString()
        {
            QnAContent content = new QnAContent();
            return $"{content.Questions}{content.Answers}{content.CorrectAnswers}";
        }

    }

}

































