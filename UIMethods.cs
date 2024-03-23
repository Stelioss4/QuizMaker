namespace QuizMaker
{
    public static class UIMethods
    {
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("HELLO! WELCOME ON QUIZ MAKER");
        }

        public static string ReadQuestions()
        {
            Console.Clear();
            Console.WriteLine("Please write a question: ");

            return Console.ReadLine();
        }

        public static List<string> ReadAnswers()
        {
            Console.WriteLine("Please write four additional answers for the question!");
            List<string> answers = new List<string>();
            for (int i = CONSTANTS.LOW_ANSWERS_LIMIT; i < CONSTANTS.UPPER_ANSWER_LIMIT; i++)
            {
                Console.Write($"Enter answer {i + 1}: ");
                string answer = Console.ReadLine();
                answers.Add(answer);
            }
            return answers;
        }

        public static int ReadCorrectAnswer()
        {
            Console.WriteLine($"Please choose one of the answers ({CONSTANTS.ANSWER_COUNT_HELP_LOW} to {CONSTANTS.UPPER_ANSWER_LIMIT}):");
            while (true)
            {
                int CorrectAnswer = 0;

                if (int.TryParse(Console.ReadLine(), out CorrectAnswer) && CorrectAnswer < CONSTANTS.ANSWER_COUNT_HELP_HIGH)
                {
                    Console.Clear();
                    return CorrectAnswer;
                }
               
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
               
            }
        }

        public static bool AskToAddQuestions()
        {
            Console.WriteLine("\nPress (ENTER) to add more questionsANDanswers or anything else to play!");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            return keyInfo.Key == ConsoleKey.Enter;
        }

        public static void DisplayPlayMessage()
        {
            Console.Clear();
            Console.WriteLine("**********************");
            Console.WriteLine("OK then, Lets play! !");
            Console.WriteLine("**********************\n");
        }

        public static int ReadUsersCorrectAnswer()
        {
            Console.WriteLine($"Please choose one of the answers ({CONSTANTS.ANSWER_COUNT_HELP_LOW} to {CONSTANTS.UPPER_ANSWER_LIMIT}):");
            while (true)
            {
                int userAnswer = 0;

                if (int.TryParse(Console.ReadLine(), out userAnswer) && userAnswer < CONSTANTS.ANSWER_COUNT_HELP_HIGH)
                {
                    return userAnswer;
                }

                Console.WriteLine($"Invalid input. Please enter a number between {CONSTANTS.ANSWER_COUNT_HELP_LOW} and {CONSTANTS.UPPER_ANSWER_LIMIT}.");

            }
        }

        public static void OutputQnA(QuestionAndAnswers randomContent)
        {
            if (randomContent == null)
            {
                return;
            }

            Console.WriteLine(randomContent.Question);

            if (randomContent.Answers == null || randomContent.Answers.Count == 0)
            {
                Console.WriteLine("Sorry, no answers available.");
                return;
            }

            int numberOfAnswer = CONSTANTS.ANSWER_COUNT_HELP_LOW;
            foreach (string answer in randomContent.Answers)
            {
                Console.WriteLine($"{numberOfAnswer++}: {answer}");
            }
        }

        public static bool AskToContinueOrQuit()
        {
            Console.WriteLine($"Press (SPACE) to play or anything else to quit. . .");
            Console.WriteLine("********************************************************\n");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            return keyInfo.Key == ConsoleKey.Spacebar;
        }

        public static QuestionAndAnswers ReadQnA()
        {
            QuestionAndAnswers questionandAnswers = new QuestionAndAnswers();

            questionandAnswers.Question = ReadQuestions();
            questionandAnswers.Answers = ReadAnswers();
            questionandAnswers.CorrectAnswer = ReadCorrectAnswer();
            return questionandAnswers;
        }

        public static void DisplayTotalPoints(int points)
        {
            Console.WriteLine($"your points are: {points}!!\n");
        }

        public static void DisplayGoodBuyMessage()
        {
            Console.WriteLine("Goodbuy then!! See you next time!!");
        }

        public static List<QuestionAndAnswers> AppendQnA(List<QuestionAndAnswers> QnAList)
        {

            while (true)
            {
                QuestionAndAnswers questionandAnswers = ReadQnA();
                QnAList.Add(questionandAnswers);

                if (AskToContinueOrQuit())
                {
                    break;
                }
            }
            return QnAList;
        }

        public static int DisplayAnswerComparison(QuestionAndAnswers randomContent, int userAnswer)
        {
            int points = 0;
            Console.Clear();
            if (Logic.CompareAnswers(randomContent, userAnswer))
            {
                Console.WriteLine($"Perfect!! The correct answer is number {randomContent.CorrectAnswer}: {randomContent.Answers[randomContent.CorrectAnswer - CONSTANTS.ANSWER_COUNT_HELP_LOW]}!!!\n");
                points++;
            }
            else
            {
                Console.WriteLine($"Sorry.. The correct answer is number {randomContent.CorrectAnswer}: {randomContent.Answers[randomContent.CorrectAnswer - CONSTANTS.ANSWER_COUNT_HELP_LOW]}\n");
            }
            return points;
        }

        public static void DisplayEmptyQnAMessage()
        {
            Console.Clear();
            Console.WriteLine("Sorry, no question available. Please restart the program and follow the instructions to add some QnA content.");
        }
    }
}