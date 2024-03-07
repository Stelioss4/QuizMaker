﻿using QuizMaker;
using System.Xml.Serialization;

public class Program
{

    public static void Main(string[] args)
    {
        const string DONE = "done";

        UIMethods.DisplayWelcomeMessag();

        string path = @"C:\Users\PC\source\repos\QuizMaker\Questions.xml";

        QuestionsAndAnswers randomeContent = new QuestionsAndAnswers();
        QuestionsAndAnswers questionAnswers = new QuestionsAndAnswers();
        List<QuestionsAndAnswers> QnAList = new List<QuestionsAndAnswers>();

        if (UIMethods.AskToPlayOrAddQuestions())
        {
            while (true)
            {
                string question = UIMethods.WriteTheQuestions();

                if (question.ToLower() == DONE)
                {
                    break;
                }

                List<string> answers = UIMethods.WriteTheAnswers();
                string CorrectAnswer = UIMethods.GiveTheCorrectAnswer();

                List<QuestionsAndAnswers> newQuestionsAndAnswers = Logic.AddQnAToAList(question, answers, CorrectAnswer);
                foreach (var QnA in newQuestionsAndAnswers)
                {
                    QnAList.Add(QnA);
                }

                Logic.SaveToHardDrive(path, QnAList);

            }
        }
        UIMethods.PlayWithExistedQuestions();
        while (true)
        {
            QnAList = Logic.LoadFromHardDrive(path);

            randomeContent = Logic.MakeRandomQuestion(QnAList);

            UIMethods.OutputTheRandomQuestion(randomeContent);

            string userAnswer = UIMethods.AnswerTheQestion();


            if (UIMethods.LeaveTheGame())
            {
                break;
            }
        }

    }
}