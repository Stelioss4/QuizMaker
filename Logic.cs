using System.Text;
using System.Xml.Serialization;
namespace QuizMaker
{
    public static class Logic
    {
        const string QUIT = "quit";
        const string PLAY = "play";
        const string ASK_QUESTIONS = "ask more questions";
        const string PATH = "QuestionsandAnswers.xml";

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
        public static int CompareTheAnswers(QuestionsAndAnswers randomQuestion, int userAnswer)
        {
            int points = 0;
            if (randomQuestion.CorrectAnswer == userAnswer)
            {
                Console.WriteLine($"Perfect!! The correct answer is: {randomQuestion.CorrectAnswer}!!!\n");
                points++;
            }
            else
            {
                Console.WriteLine($"Sorry.. The correct answer is: {randomQuestion.CorrectAnswer}\n");
            }
            return points;
        }
        public static bool ChekIfNoQnALoaded(QuestionsAndAnswers randomeContent)
        {
            if (randomeContent == null || randomeContent.Answers == null || randomeContent.Answers.Count == 0)
            {
                return false;
            }
            return true;
        }
        public static void AddQnAInAList()
        {
            QuestionsAndAnswers questionandAnswers = new QuestionsAndAnswers();
            List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();
            while (true)
            {
                questionandAnswers = UIMethods.AddQnAToObject();
                QnAList.Add(questionandAnswers);

                if (UIMethods.PressEscapeOrAnythingElse(PLAY, ASK_QUESTIONS))
                {
                    break;
                }
            }
        }

        public static void PlayTheQuiz()
        {
            List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();
            Random rng = new Random();
            int points = 0;
            while (true)
            {
                QuestionsAndAnswers randomeContent = Logic.MakeRandomQuestion(QnAList, rng);

                UIMethods.OutputTheRandomQuestion(randomeContent);

                if (!File.Exists(PATH))//Logic.ChekIfNoQnALoaded(randomeContent) == false)
                {
                    break;
                }

                int userAnswer = UIMethods.ReadCorrectAnswerInput();

                points = points + Logic.CompareTheAnswers(randomeContent, userAnswer);
                UIMethods.DisplayTotalPoints(points);

                if (UIMethods.PressEscapeOrAnythingElse(QUIT, PLAY))
                {
                    UIMethods.DisplayGoodBuyMessage();
                    break;
                }
            }
        }
        public static void LoadAndAddQnA()
        {
            List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();

            QnAList = Logic.LoadFromHardDrive();
            if (UIMethods.AskToAddQuestions())
            {
                Logic.AddQnAInAList();

                Logic.SaveToHardDrive(QnAList);
            }
        }
    }
}
