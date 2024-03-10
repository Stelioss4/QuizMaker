using System.Xml.Serialization;
namespace QuizMaker
{
    public static class Logic
    {

        public static void SaveToHardDrive(string path, List<QuestionsAndAnswers> QnAList)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, QnAList);
            }
        }
        public static List<QuestionsAndAnswers> LoadFromHardDrive(string path, List<QuestionsAndAnswers> QnAList)
        {
            while (true)
            {

                XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
                try
                {
                    using (FileStream file = File.OpenRead(path))
                    {
                        QnAList = (List<QuestionsAndAnswers>)serializer.Deserialize(file);
                    }

                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("sorry no xml files didected. . .");

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
        public static List<QuestionsAndAnswers> AddQnAToAList(string questions, List<string> answers, int CorrectAnswer)
        {
            QuestionsAndAnswers questionAnswers = new QuestionsAndAnswers();
            List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();

            questionAnswers.Questions = questions;

            foreach (string answer in answers)
            {
                questionAnswers.Answers.Add(answer);
            }

            questionAnswers.CorrectAnswer = CorrectAnswer;

            QnAList.Add(questionAnswers);

            return QnAList;
        }
        public static int CompareTheAnswers(QuestionsAndAnswers randomQuestion, int userAnswer, int points)
        {
            if (randomQuestion.Answers.Count == 0)
            {
                Console.WriteLine("Sorry no Questions and Answers loaded");
            }
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
    }
}

