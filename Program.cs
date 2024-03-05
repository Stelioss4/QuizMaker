﻿using QuizMaker;
using System.IO;
using System.Net.Mime;
using System.Xml.Serialization;

public class Program
{

    public static void Main(string[] args)
    {
        const string DONE = "done";

        UIMethods.DisplayWelcomeMessag();
        string path = @"C:\Users\PC\source\repos\QuizMaker\QuestionsandAnswers.xml";
        string answers = "";

        QuestionsAndAnswers questionsanswers = new QuestionsAndAnswers();
        if (UIMethods.AskToPlayOrAddQuestions())
        {
            while (true)
            {
                string question = UIMethods.WriteTheQuestions();
                if (question.ToLower() == DONE)
                {
                    break;
                }
                answers = UIMethods.WriteTheAnswers();
                string CorrectAnswer = UIMethods.GiveTheCorrectAnswer();

                // Logic.AddQuestionsInTheList(questionsanswers);
                questionsanswers.questionsANDanswers.Add(question);
                questionsanswers.CorrectAnswer.Add(CorrectAnswer);
                Logic.SaveToHardDrive(path, questionsanswers);

            }
        }

        UIMethods.PlayWithExistedQuestions();
        while (true)
        {

            questionsanswers = Logic.LoadFromHardDrive(path);
            string randomQuestion = Logic.MakeRandomQuestion(questionsanswers);
            Console.WriteLine(randomQuestion);
            Console.WriteLine(answers);

            string userAnswer = UIMethods.AnswerTheQestion("Please choose one of the answers!");
            Logic.CompareTheAnswers();

            if (UIMethods.LeaveTheGame())
            {
                break;
            }
        }
    }
}


