using QuizMaker;
public class Program
{
    public static void Main(string[] args)
    {
        const string QUIT = "quit";
        const string PLAY = "play";
        const string PATH = "QuestionsandAnswers.xml";

        Random rng = new Random();

        UIMethods.DisplayWelcomeMessage();

        List<QuestionsAndAnswers> QnAList = Logic.LoadFromHardDrive();

        UIMethods.AddQnA(QnAList);

        UIMethods.DisplayMessageForPlay();

        
        int points = 0;

        do
        {
            QuestionsAndAnswers randomeContent = Logic.MakeRandomQuestion(QnAList, rng);

            if (randomeContent == null || !File.Exists(PATH))
            {
                UIMethods.DisplayEmptyQnAMessage();
                UIMethods.DisplayGoodBuyMessage();
                break;
            }

            UIMethods.OutputQnA(randomeContent);

            int userAnswer = UIMethods.ReadCorrectAnswerInput();

            points = points + UIMethods.CompareTheAnswers(randomeContent, userAnswer);
            UIMethods.DisplayTotalPoints(points);

            if (UIMethods.AskToContinueOrQuit(QUIT, PLAY))
            {
                UIMethods.DisplayGoodBuyMessage();
                break;
            }
        }
        while (QnAList != null);
    }
}