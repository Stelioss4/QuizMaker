﻿using System.ComponentModel.Design;
using System.Drawing;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;

namespace QuizMaker
{
    public static class UIMethods
    {
        const int LOW_ANSWERS_LIMMIT = 0;
        const int ANSWER_COUNT_HELP = 1;
        const int UPPER_ANSWER_LIMMIT = 4;
        const string FIRST_ANSWER = "1";
        const string SECOND_ANSWER = "2";
        const string THIRD_ANSWER = "3";
        const string FOURTH_ANSWER = "4";
        public static void DisplayWelcomeMessage()
        {
            Console.WriteLine("HELLO! WELCOME ON QUIZ MAKER");
        }
        public static string WriteTheQuestions()
        {
            Console.WriteLine("Please write a question (type 'done' to finish):");

            return Console.ReadLine();
        }
        public static List<string> WriteTheAnswers()
        {
            Console.WriteLine("Please write four additional answers for the question!");
            List<string> answers = new List<string>();
            for (int i = LOW_ANSWERS_LIMMIT; i < UPPER_ANSWER_LIMMIT; i++)
            {
                Console.Write($"Enter answer {i + 1}: ");
                string answer = Console.ReadLine();
                answers.Add(answer);
            }
            return answers;
        }
        public static string GiveTheCorrectAnswer()
        {
            Console.WriteLine("choose the correct answer");
            string CorrectAnswer = Console.ReadLine();
            return CorrectAnswer;
        }

        public static bool AskToPlayOrAddQuestions()
        {
            Console.WriteLine("\nPress (SPACE) to add more questionsANDanswers or anything else to play!");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Console.Clear();
            {
                return keyInfo.Key == ConsoleKey.Spacebar;
            }
        }
        public static void DisplayMessageForPlay()
        {
            Console.Clear();
            Console.WriteLine("\nOK then, Lets play !\n");
        }
        public static bool LeaveTheGame()
        {
            Console.WriteLine("\nPress (ESCAPE) to leave the game or anything else to play!");
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            {
                return keyInfo.Key == ConsoleKey.Escape;
            }
        }
        public static string ReadCorrectAnswerInput()
        {
            while (true)
            {
                Console.WriteLine("Please choose one of the answers (1, 2, 3, or 4):");
                string userAnswer = Console.ReadLine();
                if (userAnswer == FIRST_ANSWER || userAnswer == SECOND_ANSWER || userAnswer == THIRD_ANSWER || userAnswer == FOURTH_ANSWER)
                {
                    Console.Clear();
                    return userAnswer;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 4.");
                }
            }
        }

        public static void OutputTheRandomQuestion(QuestionsAndAnswers randomContent)
        {
            if (randomContent == null)
            {
                Console.WriteLine("Sorry, no question available.");
                return;
            }

            Console.WriteLine(randomContent.Questions);

            if (randomContent.Answers == null || randomContent.Answers.Count == 0)
            {
                Console.WriteLine("Sorry, no answers available.");
                return;
            }

            int numberOfAnswer = ANSWER_COUNT_HELP;
            foreach (string answer in randomContent.Answers)
            {
                Console.WriteLine($"{numberOfAnswer++}: {answer}");
            }
        }

    }
}