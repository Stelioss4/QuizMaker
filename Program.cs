using QuizMaker;
using System.IO;
public class Program
{
    public static void Main(string[] args)
    {
        const string QUIT = "quit";
        const string PLAY = "play";
        const string PATH = "QuestionsandAnswers.xml";

        Random rng = new Random();

        UIMethods.DisplayWelcomeMessage();

        List<QuestionsAndAnswers> QnAList = UIMethods.LoadAndAddQnA();

        UIMethods.DisplayMessageForPlay();

        int points = 0;

        while (true)
        {
            QuestionsAndAnswers randomeContent = Logic.MakeRandomQuestion(QnAList, rng);

            UIMethods.OutputQnA(randomeContent);

            if (!File.Exists(PATH))
            {
                break;
            }

            int userAnswer = UIMethods.ReadCorrectAnswerInput();

            points = points + UIMethods.CompareTheAnswers(randomeContent, userAnswer);
            UIMethods.DisplayTotalPoints(points);

            if (UIMethods.AskToContinueOrQuit(QUIT, PLAY))
            {
                UIMethods.DisplayGoodBuyMessage();
                break;
            }
        }
    }
}