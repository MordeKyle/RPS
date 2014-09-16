using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPS
{
    class rockPaperScissors
    {
        public string playGame(string m_userChoice, string m_computerChoice)
        {
            const string rock = "Rock";
            const string paper = "Paper";
            const string scissors = "Scissors";
            string draw = "Draw.";
            string win = "You Win!";
            string lose = "You Lose!";
            string result;

            if (m_userChoice == m_computerChoice)
            {
                result = draw;
            }
            else if (m_userChoice == rock)
            {
                if (m_computerChoice == paper)
                {
                    result = lose;
                }
                else
                {
                    result = win;
                }
            }
            else if (m_userChoice == paper)
            {
                if (m_computerChoice == scissors)
                {
                    result = lose;
                }
                else
                {
                    result = win;
                }
            }
            else
            {
                if (m_computerChoice == rock)
                {
                    result = lose;
                }
                else
                {
                    result = win;
                }
            }
            return result;
        }
    }
}
