using System;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Xml.Serialization;
namespace QuizMaker
{
    public static class Logic
    {
        public static void SaveQuestionsToHardDrive(string path, Questions content)
        {
            path = @"C:\Users\PC\source\repos\QuizMaker\questions.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Questions));
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, content);
            }
        }
        public static void SaveAnswersToHardDrive(string path, Answers answerContent)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Answers));
            using (FileStream file = File.Create(path))
            {
                serializer.Serialize(file, answerContent);
            }
        }

        public static void LoadQuestionsFromHardDrive(string path , Questions content)
        {
            path = @"C:\Users\PC\source\repos\QuizMaker\questions.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Questions));
            using (FileStream file = File.OpenRead(path))
            {
                content = serializer.Deserialize(file) as Questions;
            }
           
        }
        public static void LoadAnswersFromHardDrive(string path, Answers answerContent)
        {
            path = @"C:\Users\PC\source\repos\QuizMaker\questions.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(Answers));
            using (FileStream file = File.OpenRead(path))
            {
                answerContent = serializer.Deserialize(file) as Answers;
            }
           
        }

        public static string MakeRandomQuestion(Questions content)
        {
            if (content.questions.Count == 0)
            {
                Console.WriteLine("No questions available.");
                return null;
            }
            Random rand = new Random();
            int randomIndex = rand.Next(0, content.questions.Count); string randomQuestion = content.questions[randomIndex];

            return randomQuestion;
        }
    }
}


