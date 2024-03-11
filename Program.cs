using QuizMaker;
using System.Xml.Serialization;

public class Program
{
    public static void Main(string[] args)
    {
        const string DONE = "done";
        const string PATH = "QuestionsandAnswers.xml";

        UIMethods.DisplayWelcomeMessage();

        QuestionsAndAnswers randomeContent = new QuestionsAndAnswers();
        List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();
        List<QuestionsAndAnswers> newQuestionsAndAnswers = new List<QuestionsAndAnswers>();
        Random rng = new Random();

        if (UIMethods.AskToPlayOrAddQuestions())
        {
            QnAList = Logic.LoadFromHardDrive();

            while (true)
            {
                string question = UIMethods.WriteTheQuestions();

                if (question.ToLower() == DONE)
                {
                    break;
                }

                List<string> answers = UIMethods.WriteTheAnswers();
                int CorrectAnswer = UIMethods.GiveTheCorrectAnswer();

                newQuestionsAndAnswers = Logic.AddQnAToAList(question, answers, CorrectAnswer);
                foreach (var QnA in newQuestionsAndAnswers)
                {
                    QnAList.Add(QnA);
                }
            }
            Logic.SaveToHardDrive(QnAList);
        }

        UIMethods.DisplayMessageForPlay();
        int points = 0;
        while (true)
        {
            QnAList = Logic.LoadFromHardDrive();

            randomeContent = Logic.MakeRandomQuestion(QnAList, rng);

            UIMethods.OutputTheRandomQuestion(randomeContent);

            if(UIMethods.DisplayNoQnALoaded(randomeContent) == false)
            {
                break;
            }

            int userAnswer = UIMethods.ReadCorrectAnswerInput();

            points = Logic.CompareTheAnswers(randomeContent, userAnswer, points);

            if (UIMethods.LeaveTheGame())
            {
                break;
            }



        }
    }
}