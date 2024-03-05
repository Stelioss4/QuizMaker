using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace QuizMaker
{
    public static class UIMethods
    {
        const int NUMBER_OF_ANSWERS = 4;
        public static void DisplayWelcomeMessag()
        {
            Console.WriteLine("HELLO! WELCOME ON QUIZ MAKER");
        }
        public static string WriteTheQuestions()
        {
            Console.WriteLine("Please write a question (type 'done' to finish):");

            return Console.ReadLine();
        }
        public static string WriteTheAnswers()
        {
            Console.WriteLine("Please write four additional answers for the question!");
            string answers = "";
            while (true)
            {
                try
                {
                    for (int i = 0; i < NUMBER_OF_ANSWERS; i++)
                    {
                        answers += Console.ReadLine() + "\n";
                    }
                    break;
                }
                catch (System.NullReferenceException)
                {
                    Console.WriteLine("exepte null");
                }
            }
            return answers;
        }
        public static string GiveTheCorrectAnswer()
        {
            Console.WriteLine("choose the correct answer");
            string CorrectAnswer = Console.ReadLine();
            return CorrectAnswer;
        }

        public static bool AskToPlayOrAddQuestions()
        {
            Console.WriteLine("\nPress (SPACE) to add more questionsANDanswers or anything else to play!");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();
            {
                return keyInfo.Key == ConsoleKey.Spacebar;
            }
        }
        public static void PlayWithExistedQuestions()
        {
            Console.WriteLine("OK then, Lets play !");
        }
        public static bool LeaveTheGame()
        {
            Console.WriteLine("\nPress (ESCAPE) to leave the game or anything else to play!");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();
            {
                return keyInfo.Key == ConsoleKey.Escape;
            }

        }
        public static string AnswerTheQestion(string userAnswer)
        {
            Console.WriteLine("Please choose one of the answers!");
            userAnswer = Console.ReadLine();
            return userAnswer;
        }
    }
}

