using System.Xml.Serialization;
namespace QuizMaker
{
    public class Logic
    {
        public static void SaveToHardDrive(List<QuestionsAndAnswers> QnAList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
            using (FileStream file = File.Create(CONSTANTS.PATH))
            {
                serializer.Serialize(file, QnAList);
            }
        }

        public static List<QuestionsAndAnswers> LoadFromHardDrive()
        {
            List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));

            if (File.Exists(CONSTANTS.PATH))
            {
                using (FileStream file = File.OpenRead(CONSTANTS.PATH))
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
            QuestionsAndAnswers randomContent = QnAList[randomIndex];
            return randomContent;
        }
    }
}