using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;

namespace QuizMaker
{
    public static class UIMethods
    {
        const int LOW_ANSWERS_LIMMIT = 0;
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
        public static List<string> WriteTheAnswers()
        {
            Console.WriteLine("Please write four additional answers for the question!");
            List<string> answers = new List<string>();

            for (int i = LOW_ANSWERS_LIMMIT; i < NUMBER_OF_ANSWERS; i++)
            {
                Console.Write($"Enter answer {i + 1}: ");
                string answer = Console.ReadLine();
                answers.Add(answer);
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
            Console.Clear();
            Console.WriteLine("\nOK then, Lets play !\n");
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
        public static string AnswerTheQestion()
        {
            Console.WriteLine("Please choose one of the answers!");
            string userAnswer = Console.ReadLine();
            return userAnswer;
        }
        public static void OutputTheRandomQuestion(QuestionsAndAnswers randomContent)
        {
            Console.WriteLine(randomContent.Questions);
            Console.WriteLine("Answers:");
            foreach (string answer in randomContent.Answers)
            {
                Console.WriteLine(answer);
            }
        }
    }
}

