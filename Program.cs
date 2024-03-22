using QuizMaker;
public class Program
{
    public static void Main(string[] args)
    {

        Random rng = new Random();

        UIMethods.DisplayWelcomeMessage();

        List<QuestionsAndAnswers> QnAList = Logic.LoadFromHardDrive();

        bool AddedQuestions = false;

        if (UIMethods.AskToAddQuestions())
        {
            QnAList = UIMethods.AddQnAInAList(QnAList);
            AddedQuestions = true;
        }
        if(AddedQuestions)
        {
            Logic.SaveToHardDrive(QnAList);
        }

        UIMethods.DisplayMessageForPlay();

        int points = 0;

        do
        {
            QuestionsAndAnswers randomContent = Logic.MakeRandomQuestion(QnAList, rng);

            if (randomContent == null || !File.Exists(CONSTANTS.PATH))
            {
                UIMethods.DisplayEmptyQnAMessage();
                UIMethods.DisplayGoodBuyMessage();
                break;
            }

            UIMethods.OutputQnA(randomContent);

            int userAnswer = UIMethods.ReadCorrectAnswerInput();

            points += UIMethods.CompareTheAnswers(randomContent, userAnswer);
            UIMethods.DisplayTotalPoints(points);

            if (UIMethods.AskToContinueOrQuit(CONSTANTS.QUIT, CONSTANTS.PLAY))
            {
                break;
            }
        }
        while (QnAList != null);

        UIMethods.DisplayGoodBuyMessage();
    }
}