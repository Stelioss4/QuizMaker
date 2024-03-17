using QuizMaker;
using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        UIMethods.DisplayWelcomeMessage();

        List<QuestionsAndAnswers> QnAList = Logic.LoadAndAddQnA();

        Logic.PlayTheQuiz(QnAList);
        
    }
}