using QuizMaker;

public class Program
{
    public static void Main(string[] args)
    {
        const string PLAY = "play";
        const string QUIT = "quit";
        const string ASK_QUESTIONS = "ask more questions";

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

                if (UIMethods.PressEscapeOrAnythingElse(PLAY, ASK_QUESTIONS))
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

            if (UIMethods.PressEscapeOrAnythingElse(QUIT, PLAY))
            {
                UIMethods.DisplayGoodBuyMessage();
                break;
            }
        }
    }
}