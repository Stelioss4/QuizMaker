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
    }
}
//if (int.TryParse(Console.ReadLine(), out CorrectAnswer) && CorrectAnswer < ANSWER_COUNT_HELP_HIGH)

//{
//    Console.Clear();
//    return CorrectAnswer;
//}
//else
//{
//    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
//}