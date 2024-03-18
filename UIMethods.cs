namespace QuizMaker
{
    public static class UIMethods
    {
        const int LOW_ANSWERS_LIMMIT = 0;
        const int ANSWER_COUNT_HELP_LOW = 1;
        const int ANSWER_COUNT_HELP_HIGH = 5;
        const int UPPER_ANSWER_LIMMIT = 4;

        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("HELLO! WELCOME ON QUIZ MAKER");
        }
        public static string WriteTheQuestions()
        {
            Console.Clear();
            Console.WriteLine("Please write a question: ");

            return Console.ReadLine();
        }
        public static List<string> WriteTheAnswers()
        {
            Console.WriteLine("Please write four additional answers for the question!");
            List<string> answers = new List<string>();
            for (int i = LOW_ANSWERS_LIMMIT; i < UPPER_ANSWER_LIMMIT; i++)
            {
                Console.Write($"Enter answer {i + 1}: ");
                string answer = Console.ReadLine();
                answers.Add(answer);
            }
            return answers;
        }
        public static int ReadTheCorrectAnswer()
        {
            Console.WriteLine("choose 1, 2, 3, 4 for the correct answer");
            while (true)
            {
                int CorrectAnswer = 0;
                if (int.TryParse(Console.ReadLine(), out CorrectAnswer) && CorrectAnswer < ANSWER_COUNT_HELP_HIGH)

                {
                    Console.Clear();
                    return CorrectAnswer;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                }
            }
        }
        public static bool AskToAddQuestions()
        {
            Console.WriteLine("\nPress (ENTER) to add more questionsANDanswers or anything else to play!");

            ConsoleKeyInfo keyInfo = Console.ReadKey();
            return keyInfo.Key == ConsoleKey.Enter;
        }
        public static void DisplayMessageForPlay()
        {
            Console.Clear();
            Console.WriteLine("**********************");
            Console.WriteLine("OK then, Lets play! !");
            Console.WriteLine("**********************\n");
        }
        public static int ReadCorrectAnswerInput()
        {
            Console.WriteLine("Please choose one of the answers (1, 2, 3, or 4):");
            while (true)
            {
                int userAnswer = 0;
                if (int.TryParse(Console.ReadLine(), out userAnswer) && userAnswer < ANSWER_COUNT_HELP_HIGH)
                {
                    for (int i = ANSWER_COUNT_HELP_LOW; i < ANSWER_COUNT_HELP_HIGH; i++)
                    {
                        if (userAnswer == i)
                        {
                            Console.Clear();
                            return userAnswer;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                }
            }
        }
        public static void OutputTheRandomQuestion(QuestionsAndAnswers randomContent)
        {
            if (randomContent == null)
            {
                Console.WriteLine("Sorry, no question available.");
                return;
            }

            Console.WriteLine(randomContent.Questions);

            if (randomContent.Answers == null || randomContent.Answers.Count == 0)
            {
                Console.WriteLine("Sorry, no answers available.");
                return;
            }

            int numberOfAnswer = ANSWER_COUNT_HELP_LOW;
            foreach (string answer in randomContent.Answers)
            {
                Console.WriteLine($"{numberOfAnswer++}: {answer}");
            }
        }
        public static bool PressSpacebarOrAnythingElse(string play, string quit)
        {
            Console.WriteLine($"Press (SPACE) to {play} or anything else to {quit}. . .");
            Console.WriteLine("********************************************************\n");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            return keyInfo.Key == ConsoleKey.Spacebar;
        }
        public static QuestionsAndAnswers AddQnAToObject()
        {
            QuestionsAndAnswers questionandAnswers = new QuestionsAndAnswers();

            questionandAnswers.Questions = WriteTheQuestions();
            questionandAnswers.Answers = WriteTheAnswers();
            questionandAnswers.CorrectAnswer = ReadTheCorrectAnswer();
            return questionandAnswers;
        }
        public static void DisplayTotalPoints(int points)
        {
            Console.WriteLine($"your points are: {points}!!\n");
        }
        public static void DisplayGoodBuyMessage()
        {
            Console.Clear();
            Console.WriteLine("OK, Goodbuy!! See you next time!!");
        }
    }
}