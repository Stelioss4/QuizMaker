using System.Xml.Serialization;
namespace QuizMaker
{
    public static class Logic
    {
        const string QUIT = "quit";
        const string PLAY = "play";
        const string ASK_QUESTIONS = "ask more questions";
        const string PATH = "QuestionsandAnswers.xml";
        const int ANSWER_COUNT_HELP_LOW = 1;

        public static void SaveToHardDrive(List<QuestionsAndAnswers> QnAList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
            using (FileStream file = File.Create(PATH))
            {
                serializer.Serialize(file, QnAList);
            }
        }
        public static List<QuestionsAndAnswers> LoadFromHardDrive()
        {
            List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));

            if (File.Exists(PATH))
            {
                using (FileStream file = File.OpenRead(PATH))
                {
                    QnAList = serializer.Deserialize(file) as List<QuestionsAndAnswers>;
                }
            }
            return QnAList;
        }
        public static QuestionsAndAnswers MakeRandomQuestion(List<QuestionsAndAnswers> QnAList, Random rng)
        {
            if (QnAList.Count == 0)
            {
                return null;
            }
            int randomIndex = rng.Next(0, QnAList.Count);
            QuestionsAndAnswers randomeContent = QnAList[randomIndex];
            return randomeContent;
        }
        public static int CompareTheAnswers(QuestionsAndAnswers randomeContent, int userAnswer)
        {
            int points = 0;
            if (randomeContent.CorrectAnswer == userAnswer)
            {
                Console.WriteLine($"Perfect!! The correct answer is number {randomeContent.CorrectAnswer}: {randomeContent.Answers[randomeContent.CorrectAnswer - ANSWER_COUNT_HELP_LOW]}!!!\n");
                points++;
            }
            else
            {
                
                Console.WriteLine($"Sorry.. The correct answer is number {randomeContent.CorrectAnswer}: {randomeContent.Answers[randomeContent.CorrectAnswer - ANSWER_COUNT_HELP_LOW]}\n");
            }
            return points;
        }
        public static List<QuestionsAndAnswers> AddQnAInAList(List<QuestionsAndAnswers> QnAList)
        {
          
            while (true)
            {
                QuestionsAndAnswers questionandAnswers = UIMethods.AddQnAToObject();
                QnAList.Add(questionandAnswers);

                if (UIMethods.PressSpacebarOrAnythingElse(PLAY, ASK_QUESTIONS))
                {
                    break;
                }
            }
            return QnAList;
        }
        public static void PlayTheQuiz(List<QuestionsAndAnswers> QnAList)
        {
            Random rng = new Random();
            int points = 0;
            UIMethods.DisplayMessageForPlay();
            while (true)
            {
                QuestionsAndAnswers randomeContent = Logic.MakeRandomQuestion(QnAList, rng);

                UIMethods.OutputTheRandomQuestion(randomeContent);

                if (!File.Exists(PATH))
                {
                    break;
                }

                int userAnswer = UIMethods.ReadCorrectAnswerInput();

                points = points + Logic.CompareTheAnswers(randomeContent, userAnswer);
                UIMethods.DisplayTotalPoints(points);

                if (UIMethods.PressSpacebarOrAnythingElse(QUIT, PLAY))
                {
                    UIMethods.DisplayGoodBuyMessage();
                    break;
                }
            }
        }
        public static List<QuestionsAndAnswers> LoadAndAddQnA()
        {
            List<QuestionsAndAnswers> QnAList = LoadFromHardDrive();
            if (UIMethods.AskToAddQuestions())
            {
               QnAList = AddQnAInAList(QnAList);

                SaveToHardDrive(QnAList);
            }
            return QnAList;
        }
    }
}
