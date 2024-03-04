using QuizMaker;
using System.IO;
using System.Net.Mime;

public class Program
{

    public static void Main(string[] args)
    {
        const string DONE = "done";
        const int MAX_ANSWERS = 4;

        UIMethods.DisplayWelcomeMessag();
        UIMethods.AskToPlayOrAddQuestions();

        Questions content = new Questions();
        Answers ansanswerContent = new Answers();

        string path = "";
        string answers = "";
        string CorrectAnswer = "";

        if (UIMethods.AskToPlayOrAddQuestions())
        {
            while (true)
            {
                string question = UIMethods.AddTheQuestions();
                if (question.ToLower() == DONE)
                {
                    break;
                }
                answers = UIMethods.AddTheAnswers();
                CorrectAnswer = UIMethods.GiveTheCorrectAnswer();

                content.questions.Add(question);
                ansanswerContent.answers.Add(answers);
                ansanswerContent.CorrectAnswers.Add(CorrectAnswer);

                Logic.SaveQuestionsToHardDrive(path, content);
                Logic.SaveAnswersToHardDrive(path, ansanswerContent);

            }
        }

        UIMethods.PlayWithExistedQuestions();
        while (true)
        {

            Logic.LoadQuestionsFromHardDrive(path , content);
            Logic.LoadAnswersFromHardDrive(path , ansanswerContent);
            string randomQuestion = Logic.MakeRandomQuestion(content);
            Console.WriteLine(randomQuestion);
            Console.WriteLine(answers);

            if (UIMethods.LeaveTheGame())
            {
                Console.WriteLine($"the correct answer is: {CorrectAnswer}");
                break;
            }
        }
    }
}


