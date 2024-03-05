using System.Xml.Serialization;
namespace QuizMaker
{
    public static class Logic
    {
        public static void SaveToHardDrive(string path, QuestionsAndAnswers questionsanswers)
        {
            path = @"C:\Users\PC\source\repos\QuizMaker\QuestionsandAnswers.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(QuestionsAndAnswers));
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, questionsanswers);
            }
        }


        public static QuestionsAndAnswers LoadFromHardDrive(string path)
        {
            path = @"C:\Users\PC\source\repos\QuizMaker\QuestionsandAnswers.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(QuestionsAndAnswers));
            using (FileStream file = File.OpenRead(path))
            {
                return (QuestionsAndAnswers)serializer.Deserialize(file);

            }

        }

        public static string MakeRandomQuestion(QuestionsAndAnswers questions)
        {
            Random rng = new Random();
            if (questions.questionsANDanswers.Count == 0)
            {
                return "No questionsANDanswers available";
            }
            int randomIndex = rng.Next(0, questions.questionsANDanswers.Count);
            string randomQuestion = questions.questionsANDanswers[randomIndex];
            return randomQuestion;
        }
        //public static void AddQuestionsInTheList(QuestionsAndAnswers questionsanswers)
        //{
        //    string CorrectAnswer = "";
        //    string question = "";

        //    questionsanswers.questionsANDanswers.Add(question);
        //    questionsanswers.CorrectAnswer.Add(CorrectAnswer);
        //}
        public static void CompareTheAnswers()
        {
            string userAnswer = "";
            string CorrectAnswer = "";

            int points = 0;

            if (userAnswer.ToLower() == CorrectAnswer)
            {
                Console.WriteLine("Perfect!! You found the correct answer!!");
                points++;
            }
            else
            {
                Console.WriteLine($"Sorry your Answer is fauls. The correct answer is {CorrectAnswer}");
            }
            Console.WriteLine($"your points are: {points}!");
        }
    }
}


