using QuizMaker;
using System.Net.Mime;

public class Program
{

    public static void Main(string[] args)
    {
        const string DONE = "done";
        const int MAX_ANSWERS = 4; 

        UIMethods.DisplayWelcomeMessag();
        UIMethods.AskToPlayOrAddQuestions();

        QnAContent content = new QnAContent();

        string path = @"C:\Users\PC\source\repos\QuizMaker\questions.xml";
        string question = "";
        string answers = "";
        string CorrectAnswer = "";
        string randomQuestion = "";

        if (UIMethods.AskToPlayOrAddQuestions())
        {
            while (true)
            {
                question = UIMethods.AddTheQuestions();
                if (question.ToLower() == DONE)
                {
                    break;
                }
                answers = UIMethods.AddTheAnswers();
                CorrectAnswer = UIMethods.GiveTheCorrectAnswer();

                content.Questions.Add(question);
                content.Answers.Add(answers);
                content.CorrectAnswers.Add(CorrectAnswer);

                Logic.SaveToHardDrive(path, content);

            }
        }

        UIMethods.PlayWithExistedQuestions();
        while (true)
        {
            
            content = Logic.LoadFromHardDrive(path);
            randomQuestion = Logic.MakeRandomQuestion(content);

            Console.WriteLine(randomQuestion);
            for (int i = 0; i < MAX_ANSWERS; i++)
            {
                Console.WriteLine(answers);
            }
            if (Console.ReadLine() == "buy")
            {
                Console.WriteLine($"the correct answer is: {CorrectAnswer}");
                break;
            }
        }
    }
}


