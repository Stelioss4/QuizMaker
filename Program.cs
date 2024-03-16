using QuizMaker;
using System.IO;

public class Program
{
    public static void Main(string[] args)
    {
        UIMethods.DisplayWelcomeMessage();

        Logic.LoadAndAddQnA();
       
        UIMethods.DisplayMessageForPlay();

        Logic.PlayTheQuiz();
    }
}