﻿using QuizMaker;
public class Program
{
    public static void Main(string[] args)
    {

        Random rng = new Random();

        UIMethods.DisplayWelcomeMessage();

        List<QuestionAndAnswers> QnAList = Logic.LoadFromHardDrive();

        bool AddedQuestions = false;

        if (UIMethods.AskToAddQuestions())
        {
            QnAList = UIMethods.AppendQnA(QnAList);
            AddedQuestions = true;
        }
        if(AddedQuestions)
        {
            Logic.SaveToHardDrive(QnAList);
        }

        UIMethods.DisplayPlayMessage();

        int points = 0;

        do
        {
            QuestionAndAnswers randomContent = Logic.MakeRandomQuestion(QnAList, rng);

            if (randomContent == null || !File.Exists(CONSTANTS.PATH))
            {
                UIMethods.DisplayEmptyQnAMessage();
                break;
            }

            UIMethods.OutputQnA(randomContent);

            int userAnswer = UIMethods.ReadUsersCorrectAnswer();

            points += UIMethods.DisplayAnswerComparison(randomContent, userAnswer);
            UIMethods.DisplayTotalPoints(points);

            if (UIMethods.AskToContinueOrQuit("quit", "play"))
            {
                break;
            }
        }
        while (QnAList != null);

        UIMethods.DisplayGoodBuyMessage();
    }
}