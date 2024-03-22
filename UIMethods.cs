namespace QuizMaker
{
    public static class UIMethods
    {

        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("HELLO! WELCOME ON QUIZ MAKER");
        }

        public static string ReadTheQuestions()
        {
            Console.Clear();
            Console.WriteLine("Please write a question: ");

            return Console.ReadLine();
        }

        public static List<string> ReadTheAnswers()
        {
            Console.WriteLine("Please write four additional answers for the question!");
            List<string> answers = new List<string>();
            for (int i = CONSTANTS.LOW_ANSWERS_LIMMIT; i < CONSTANTS.UPPER_ANSWER_LIMMIT; i++)
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
                if (int.TryParse(Console.ReadLine(), out CorrectAnswer) && CorrectAnswer < CONSTANTS.ANSWER_COUNT_HELP_HIGH)

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
                if (int.TryParse(Console.ReadLine(), out userAnswer) && userAnswer < CONSTANTS.ANSWER_COUNT_HELP_HIGH)
                {
                    for (int i = CONSTANTS.ANSWER_COUNT_HELP_LOW; i < CONSTANTS.ANSWER_COUNT_HELP_HIGH; i++)
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

        public static void OutputQnA(QuestionsAndAnswers randomContent)
        {
            if (randomContent == null)
            {
                return;
            }

            Console.WriteLine(randomContent.Questions);

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

        public static bool AskToContinueOrQuit(string play, string quit)
        {
            Console.WriteLine($"Press (SPACE) to {play} or anything else to {quit}. . .");
            Console.WriteLine("********************************************************\n");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            return keyInfo.Key == ConsoleKey.Spacebar;
        }

        public static QuestionsAndAnswers ReadQnA()
        {
            QuestionsAndAnswers questionandAnswers = new QuestionsAndAnswers();

            questionandAnswers.Questions = ReadTheQuestions();
            questionandAnswers.Answers = ReadTheAnswers();
            questionandAnswers.CorrectAnswer = ReadTheCorrectAnswer();
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

        public static List<QuestionsAndAnswers> AddQnAInAList(List<QuestionsAndAnswers> QnAList)
        {

            while (true)
            {
                QuestionsAndAnswers questionandAnswers = ReadQnA();
                QnAList.Add(questionandAnswers);

                if (AskToContinueOrQuit(CONSTANTS.PLAY, CONSTANTS.ASK_QUESTIONS))
                {
                    break;
                }
            }
            return QnAList;
        }

        public static int CompareTheAnswers(QuestionsAndAnswers randomContent, int userAnswer)
        {
            int points = 0;

            if (randomContent == null)
            {
                DisplayEmptyQnAMessage();
                return 0;
            }
            if (randomContent.CorrectAnswer == userAnswer)
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