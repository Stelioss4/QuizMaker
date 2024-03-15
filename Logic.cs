using System.Xml.Serialization;
namespace QuizMaker
{
    public static class Logic
    {
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

        public static bool Exist(string PATH)
        {
            if (File.Exists(PATH))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
