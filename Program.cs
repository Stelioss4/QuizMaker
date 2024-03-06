using QuizMaker;
using System.Xml.Serialization;

public class Program
{

    public static void Main(string[] args)
    {
        const string DONE = "done";

        UIMethods.DisplayWelcomeMessag();

        string path = @"C:\Users\PC\source\repos\QuizMaker\Questions.xml";

        List<QuestionsAndAnswers> questionsAndAnswers = new List<QuestionsAndAnswers>();
        List<string> answers = new List<string>();

        if (UIMethods.AskToPlayOrAddQuestions())
        {
            while (true)
            {
                string questions = UIMethods.WriteTheQuestions();

                if (questions.ToLower() == DONE)
                {
                    break;
                }
                UIMethods.WriteTheAnswers();

                string CorrectAnswer = UIMethods.GiveTheCorrectAnswer();

                Logic.AddQuestionAndAnswers(questions, answers, CorrectAnswer);

                path = @"C:\Users\PC\source\repos\QuizMaker\Questions.xml";
                XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
                using (FileStream file = File.Create(path))
                {
                    serializer.Serialize(file, questionsAndAnswers);
                }
            }
        }

        UIMethods.PlayWithExistedQuestions();
        while (true)
        {

            List<QuestionsAndAnswers> LoadToPlay = Logic.LoadFromHardDrive(path);
            string randomQuestion = Logic.MakeRandomQuestion(questionsAndAnswers);

            if (UIMethods.LeaveTheGame())
            {
                break;
            }
        }
    }
}