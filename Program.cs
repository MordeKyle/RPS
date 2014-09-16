using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RPS
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Program: Console RPS game with rockPaperScissors class
              Author: Kyle McBride A02609917
              Date: 09/15/2014
              Description: A console game that plays rock paper scissors with the user.*/
            const string resultFile = "../../Results.txt";
            string userChoice;
            string computerChoice;
            string userInput;
            string result;
            const string clear = "Clear";
            const string exit = "Exit";
            const string win = "You Win!";
            const string lose = "You Lose!";
            const string draw = "Draw.";

            while (true)
            {
                Console.WriteLine("Wins: " + readHistory(resultFile, win));
                Console.WriteLine("Loses: " + readHistory(resultFile, lose));
                Console.WriteLine("Draws: " + readHistory(resultFile, draw) + "\n");
                splash();
                userInput = Console.ReadLine();
                userChoice = inputHandler(userInput);
                computerChoice = computerInput();

                if (userChoice == exit)
                {
                    Environment.Exit(0);
                }
                else if (userChoice == clear)
                {
                    clearHistory(resultFile);
                }
                else if (userChoice == "inputError")
                {
                    Console.Clear();
                    Console.WriteLine("***Please type the number of your selection and strike the return key.***\n");
                }
                else
                {
                    rockPaperScissors rockPaperScissors = new rockPaperScissors();
                    result = rockPaperScissors.playGame(userChoice, computerChoice);
                    recordHistory(resultFile, result);
                    Console.Clear();
                    printResults(result, userChoice, computerChoice);


                }
            }
        }
        static void splash() //splash screen
        {
            Console.WriteLine("Please make a selection and press the return key:");
            Console.WriteLine("1. Rock");
            Console.WriteLine("2. Paper");
            Console.WriteLine("3. Scissors");
            Console.WriteLine("4. Clear Play History");
            Console.WriteLine("5. Exit");
        }
        static void inputError() //prompt user to re enter selection
        {
            Console.Clear();
            Console.WriteLine("Please type the number that reflect the selection you want to make, then strike the return key.");
        }
        static string inputHandler(string m_userInput) //assign the user input to a game value or event
        {
            string m_result;
            if (m_userInput == "1")
            {
                m_result = "Rock";
            }
            else if (m_userInput == "2")
            {
                m_result = "Paper";
            }
            else if (m_userInput == "3")
            {
                m_result = "Scissors";
            }
            else if (m_userInput == "4")
            {
                m_result = "Clear";
            }
            else if (m_userInput == "5")
            {
                m_result = "Exit";
            }
            else
            {
                m_result = "inputError";
            }
            return m_result;
        }
        static string computerInput() //assign generated random to a game value
        {
            string m_result;
            int m_random;

            m_random = generateRandom();

            if (m_random == 1)
            {
                m_result = "Rock";
            }
            else if (m_random == 2)
            {
                m_result = "Paper";
            }
            else
            {
                m_result = "Scissors";
            }
            return m_result;
        }
        static int generateRandom() //generate random integer
        {
            int m_result;
            Random rand = new Random();
            m_result = rand.Next(3) + 1;
            return m_result;
        }
        static int readHistory(string m_resultFile, string m_result) //reads and prints result file
        {
            //declaring output
            int resultTotal = 0;

            //declaring streamreader
            StreamReader inputFile;
            //streamreading the results file
            inputFile = File.OpenText(m_resultFile);

            string readLine;

            while (inputFile.EndOfStream == false) //loop to count how many times win, lose, or draw is in the file
            {
                readLine = inputFile.ReadLine();

                if (readLine == m_result) //checks to se if each line is equal to win, lose, or draw
                {
                    ++resultTotal; //if so, add 1 to the counter
                }
            }
            inputFile.Close();

            return resultTotal; //output the counter, as it is equal to how many wins, loses, or draws
        }
        static void printResults(string m_result, string m_userChoice, string m_computerChoice) //prints result of games
        {
            Console.Clear();
            Console.WriteLine("You chose: " + m_userChoice);
            Console.WriteLine("The Computer Chose: " + m_computerChoice);
            Console.WriteLine(m_result);
            Console.WriteLine("\n");
        }
        static void recordHistory(string m_resultFile, string m_result) //write results of game to result file
        {
            StreamWriter outputFile;
            outputFile = File.AppendText(m_resultFile);
            outputFile.WriteLine(m_result);
            outputFile.Close();
        }
        static void clearHistory(string m_resultFile) //clear out the result file
        {
            Console.Clear();
            Console.WriteLine("Are you sure you want to reset the result history?" + "\n" + "Y or N");
            string confirm = Console.ReadLine();
            while ((confirm != "y") && (confirm != "Y") && (confirm != "n") && (confirm != "N"))
            {
                Console.WriteLine("Type Y or N and hit the return key. \n");
                confirm = Console.ReadLine();
            }
            if ((confirm == "y") || (confirm == "Y"))
            {
                File.WriteAllText(m_resultFile, string.Empty);
            }
            else if ((confirm == "n") || (confirm == "N"))
            {
                Console.Clear();
            }
        }
    }
}
