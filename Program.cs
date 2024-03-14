using QuizMaker;

public class Program
{
    public static void Main(string[] args)
    {

        UIMethods.DisplayWelcomeMessage();

        QuestionsAndAnswers questionandAnswers = new QuestionsAndAnswers();
        List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();
        Random rng = new Random();

        if (UIMethods.AskToPlayOrAddQuestions())
        {
            QnAList = Logic.LoadFromHardDrive(QnAList);
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

            Logic.SaveToHardDrive(QnAList, questionandAnswers);
        }
        UIMethods.DisplayMessageForPlay();
        int points = 0;
        while (true)
        {
            QuestionsAndAnswers randomeContent = new QuestionsAndAnswers();

            QnAList = Logic.LoadFromHardDrive(QnAList);

            randomeContent = Logic.MakeRandomQuestion(QnAList, rng);

            UIMethods.OutputTheRandomQuestion(randomeContent);

            if (Logic.ChekIfNoQnALoaded(randomeContent) == false)
            {
                break;
            }

            int userAnswer = UIMethods.ReadCorrectAnswerInput();

            points = Logic.CompareTheAnswers(randomeContent, userAnswer, points);

            UIMethods.DesideToLeaveTheGameOrNot();
            if (UIMethods.PressEscapeOrAnythingElse())
            {
                UIMethods.DisplayGoodBuyMessage();
                break;
            }
        }
    }
}