using System.Xml.Serialization;
namespace QuizMaker
{
    public class Logic
    {
        public static void SaveToHardDrive(List<QuestionAndAnswers> QnAList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionAndAnswers>));
            using (FileStream file = File.Create(CONSTANTS.PATH))
            {
                serializer.Serialize(file, QnAList);
            }
        }

        public static List<QuestionAndAnswers> LoadFromHardDrive()
        {
            List<QuestionAndAnswers> QnAList = new List<QuestionAndAnswers>();
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionAndAnswers>));

            if (File.Exists(CONSTANTS.PATH))
            {
                using (FileStream file = File.OpenRead(CONSTANTS.PATH))
                {
                    QnAList = serializer.Deserialize(file) as List<QuestionAndAnswers>;
                }
            }
            return QnAList;
        }

        public static QuestionAndAnswers GetRandomQnAFromList(List<QuestionAndAnswers> QnAList, Random rng)
        {
            if (QnAList.Count == 0)
            {
                return null;
            }

            int randomIndex = rng.Next(0, QnAList.Count);
            QuestionAndAnswers randomContent = QnAList[randomIndex];
            return randomContent;
        }
        public static bool CompareAnswers(QuestionAndAnswers randomContent, int userAnswer)
        {
            return randomContent.CorrectAnswer == userAnswer;
        }
    }
}