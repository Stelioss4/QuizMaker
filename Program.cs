using QuizMaker;

public class Program
{
    public static void Main(string[] args)
    {
        const string PLAY = "play";
        const string QUIT = "quit";

        UIMethods.DisplayWelcomeMessage();

        QuestionsAndAnswers questionandAnswers = new QuestionsAndAnswers();
        List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();
        Random rng = new Random();

        QnAList = Logic.LoadFromHardDrive();
        if (UIMethods.AskToAddQuestions())
        {
            Logic.AddQnAInAList();

            Logic.SaveToHardDrive(QnAList);
        }
        UIMethods.DisplayMessageForPlay();

        int points = 0;

        while (true)
        {
            QuestionsAndAnswers randomeContent = Logic.MakeRandomQuestion(QnAList, rng);

            UIMethods.OutputTheRandomQuestion(randomeContent);

            if (Logic.ChekIfNoQnALoaded(randomeContent) == false)
            {
                break;
            }

            int userAnswer = UIMethods.ReadCorrectAnswerInput();

            points = points + Logic.CompareTheAnswers(randomeContent, userAnswer);
            UIMethods.DisplayTotalPoints(points);

            if (UIMethods.PressEscapeOrAnythingElse(QUIT, PLAY))
            {
                UIMethods.DisplayGoodBuyMessage();
                break;
            }
        }
    }
}