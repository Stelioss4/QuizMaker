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
        public static int GiveTheCorrectAnswer()
        {
            Console.WriteLine("choose 1, 2, 3, 4 for the correct answer");
            while (true)
            {
                int CorrectAnswer = 0;
                if (int.TryParse(Console.ReadLine(), out CorrectAnswer) && CorrectAnswer < ANSWER_COUNT_HELP_HIGH)

                {
                    return CorrectAnswer;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                }
            }
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
        public static void DisplayMessageForPlay()
        {
            Console.Clear();
            Console.WriteLine("**********************");
            Console.WriteLine("\nOK then, Lets play !\n");
            Console.WriteLine("**********************");
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
        public static void DisplayGoodBuyMessage()
        {
            Console.WriteLine("oOK, Goodbuy!! See you next time!!");
        }
        public static void DesideToWriteMoreQnAOrNot()
        {
            Console.WriteLine("type (ESCAPE) to finish and play! Or anything else to enter more questions!");
        }
        public static void DesideToLeaveTheGameOrNot()
        {
            Console.WriteLine("\nPress (ESCAPE) to leave the game or anything else to play!\n");
            Console.WriteLine("************************************************************");
        }
        public static bool PressEscapeOrAnythingElse()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            {
                return keyInfo.Key == ConsoleKey.Escape;
            }
        }
        public static QuestionsAndAnswers AddQnAToObject()
        {
            QuestionsAndAnswers questionandAnswers = new QuestionsAndAnswers();

            questionandAnswers.Questions = WriteTheQuestions();
            questionandAnswers.Answers = WriteTheAnswers();
            questionandAnswers.CorrectAnswer = ReadCorrectAnswerInput();
            return questionandAnswers;
        }
    }
}