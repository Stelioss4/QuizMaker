using QuizMaker;
public class Program
{
    public static void Main(string[] args)
    {
        UIMethods.DisplayWelcomeMessage();

        List<QuestionsAndAnswers> QnAList = UIMethods.LoadAndAddQnA();

        UIMethods.PlayTheQuiz(QnAList);
    }
}