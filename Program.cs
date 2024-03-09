using QuizMaker;
using System.Xml.Serialization;

public class Program
{
    public static void Main(string[] args)
    {
        const string DONE = "done";
        const string PATH = "Questions.xml";

        UIMethods.DisplayWelcomeMessage();

        QuestionsAndAnswers randomeContent = new QuestionsAndAnswers();
        List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();
        Random rng = new Random();

        if (UIMethods.AskToPlayOrAddQuestions())
        {
            while (true)
            {
                string question = UIMethods.WriteTheQuestions();

                if (question.ToLower() == DONE)
                {
                    break;
                }

                List<string> answers = UIMethods.WriteTheAnswers();
                string CorrectAnswer = UIMethods.GiveTheCorrectAnswer();

                List<QuestionsAndAnswers> newQuestionsAndAnswers = Logic.AddQnAToAList(question, answers, CorrectAnswer);
                foreach (var QnA in newQuestionsAndAnswers)
                {
                    QnAList.Add(QnA);
                }
            }
            Logic.SaveToHardDrive(PATH, QnAList);
        }

        UIMethods.DisplayMessageForPlay();
        int points = 0;
        while (true)
        {
            QnAList = Logic.LoadFromHardDrive(PATH, QnAList);

            randomeContent = Logic.MakeRandomQuestion(QnAList , rng);

            UIMethods.OutputTheRandomQuestion(randomeContent);

            string userAnswer = UIMethods.ReadCorrectAnswerInput();

            if (randomeContent == null || randomeContent.Answers == null || randomeContent.Answers.Count == 0)
            {
                Console.WriteLine("Sorry, no Questions and Answers loaded.");
                break;
            }

            points = Logic.CompareTheAnswers(randomeContent, userAnswer, points);

            if (UIMethods.LeaveTheGame())
            {
                break;
            }
        }
    }
}