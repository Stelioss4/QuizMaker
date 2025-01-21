using QuizMaker;
public class Program
{
    public static void Main(string[] args)
    {

        Random rng = new Random();

        UIMethods.DisplayWelcomeMessage();

        List<QuestionAndAnswers> QnAList = Logic.LoadFromHardDrive();

        bool AddedQuestions = false;

        if (UIMethods.AskToAddQuestions())
        {
            QnAList = UIMethods.AppendQnA(QnAList);
            AddedQuestions = true;
        }
        if(AddedQuestions)
        {
            Logic.SaveToHardDrive(QnAList);
        }

        UIMethods.DisplayPlayMessage();

        int points = 0;

        do
        {
            QuestionAndAnswers randomContent = Logic.GetRandomQnAFromList(QnAList, rng);

            if (randomContent.Question == null || randomContent.Answers.Count == 0 || !File.Exists(CONSTANTS.PATH))
            {
                UIMethods.DisplayEmptyQnAMessage();
                break;
            }

            UIMethods.OutputQnA(randomContent);

            int userAnswer = UIMethods.ReadUsersCorrectAnswer();

            points += UIMethods.DisplayAnswerComparison(randomContent, userAnswer);
            UIMethods.DisplayTotalPoints(points);

            if (!UIMethods.AskToContinueOrQuit())
            {
                break;
            }
        }
        while (QnAList != null);

        UIMethods.DisplayGoodBuyMessage();
    }
}