using System;
using System.Diagnostics;
using System.Xml.Serialization;
namespace QuizMaker
{
    public static class Logic
    {
        public static void SaveToHardDrive(string path, QnAContent content)
        {
            path = @"C:\Users\PC\source\repos\QuizMaker\questions.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(QnAContent));
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, content);
            }
        }
        public static QnAContent LoadFromHardDrive(string path)
        {
            path = @"C:\Users\PC\source\repos\QuizMaker\bin\Debug\net8.0\questions.xml";
            QnAContent content;
            XmlSerializer serializer = new XmlSerializer(typeof(QnAContent));
            using (FileStream file = File.OpenRead(path))
            {
                content = serializer.Deserialize(file) as QnAContent;
            }
            return content;
        }

        public static string MakeRandomQuestion(QnAContent content)
        {
            if (content.Questions.Count == 0)
            {
                Console.WriteLine("No questions available.");
                return null;
            }
            Random rand = new Random();
            int randomIndex = rand.Next(0, content.Questions.Count); string randomQuestion = content.Questions[randomIndex];

            return randomQuestion;
        }
    }
}


