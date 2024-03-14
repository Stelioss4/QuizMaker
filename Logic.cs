using System.Xml.Serialization;
namespace QuizMaker
{
    public static class Logic
    {
        const string PATH = "qweQuestionsandAnswers.xml";

        public static void SaveToHardDrive(List<QuestionsAndAnswers> QnAList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
            using (FileStream file = File.Create(PATH))
            {
                serializer.Serialize(file, QnAList);
            }
        }
        public static List<QuestionsAndAnswers> LoadFromHardDrive(List<QuestionsAndAnswers> QnAList)
        {
            while (true)
            {
                XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
                try
                {
                    using (FileStream file = File.OpenRead(PATH))
                    {
                        QnAList = serializer.Deserialize(file) as List<QuestionsAndAnswers>;
                    }
                }
                catch (FileNotFoundException)
                {
                    QnAList = new List<QuestionsAndAnswers>();
                }
                return QnAList;
            }
        }
        public static QuestionsAndAnswers MakeRandomQuestion(List<QuestionsAndAnswers> QnAList, Random rng)
        {
            QuestionsAndAnswers randomeContent = new QuestionsAndAnswers();
            if (QnAList.Count == 0)
            {
                return null;
            }
            int randomIndex = rng.Next(0, QnAList.Count);
            randomeContent = QnAList[randomIndex];
            return randomeContent;
        }
        
        public static int CompareTheAnswers(QuestionsAndAnswers randomQuestion, int userAnswer, int points)
        {
            if (randomQuestion.CorrectAnswer == userAnswer)
            {
                points++;
                Console.WriteLine($"Perfect!! The correct answer is: {randomQuestion.CorrectAnswer}!!!\n");
            }
            else
            {
                Console.WriteLine($"Sorry.. The correct answer is: {randomQuestion.CorrectAnswer}\n");
            }
            Console.WriteLine($"your points are: {points}!!");
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
       
    }
}
