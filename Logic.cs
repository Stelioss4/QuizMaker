﻿using System.Xml.Serialization;
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


        public static List<QuestionsAndAnswers> LoadFromHardDrive(string path)
        {
            path = @"C:\Users\PC\source\repos\QuizMaker\Questions.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(List<QuestionsAndAnswers>));
            using (FileStream file = File.OpenRead(path))
            {
                return (List<QuestionsAndAnswers>)serializer.Deserialize(file);
            }
        }



        public static string MakeRandomQuestion(List<QuestionsAndAnswers> questionsAndAnswers)
        {
            Random rng = new Random();
            if (questionsAndAnswers.Count == 0)
            {
                return "No questions AND answers available";
            }
            int randomIndex = rng.Next(0, questionsAndAnswers.Count);
            string randomQuestion = questionsAndAnswers[randomIndex].Questions;
            return randomQuestion;
        }

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
        public static List<QuestionsAndAnswers> AddQnAToAList(string questions, List<string> answers, string CorrectAnswer)
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
       
    }
}

