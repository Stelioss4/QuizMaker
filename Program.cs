using QuizMaker;

public class Program
{
    public static void Main(string[] args)
    {

        UIMethods.DisplayWelcomeMessage();

        QuestionsAndAnswers questionandAnswers = new QuestionsAndAnswers();
        List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();
        Random rng = new Random();

        QnAList = Logic.LoadFromHardDrive();
        if (UIMethods.AskToAddQuestions())
        {
            while (true)
            {
                questionandAnswers = UIMethods.AddQnAToObject();
                QnAList.Add(questionandAnswers);

                UIMethods.DesideToWriteMoreQnAOrNot();
                if (UIMethods.PressEscapeOrAnythingElse())
                {
                    break;
                }
            }

            Logic.SaveToHardDrive(QnAList);
        }
        UIMethods.DisplayMessageForPlay();

        int points = 0;

        while (true)
        {
            QuestionsAndAnswers randomeContent = new QuestionsAndAnswers();

            randomeContent = Logic.MakeRandomQuestion(QnAList, rng);

            UIMethods.OutputTheRandomQuestion(randomeContent);

            if (Logic.ChekIfNoQnALoaded(randomeContent) == false)
            {
                break;
            }

            int userAnswer = UIMethods.ReadCorrectAnswerInput();

            points = points + Logic.CompareTheAnswers(randomeContent, userAnswer);
            UIMethods.DisplayTotalPoints(points);

            UIMethods.DesideToLeaveTheGameOrNot();

            if (UIMethods.PressEscapeOrAnythingElse())
            {
                UIMethods.DisplayGoodBuyMessage();
                break;
            }
        }
    }
}