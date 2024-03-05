namespace QuizMaker
{
    public class QuestionsAndAnswers
    {
        public List<string> questionsANDanswers { get; set; }
        public List<string> CorrectAnswer { get; set; }
        public QuestionsAndAnswers()
        {
            questionsANDanswers = new List<string>();
            CorrectAnswer = new List<string>();
        }

    }
    
}



