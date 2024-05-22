using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class CommandLetter
    {
        private char _letter;
        private static readonly char[] ValidLetters = { 'L', 'R', 'M'};

        public char Value
        {
            get => _letter;
            set
            {
                if (!IsValidLetter(value))
                {
                    throw new ArgumentException("Geçersiz yön! Yön olarak sadece L, R, M karakterlerini girebilirsiniz.");
                }
                _letter = value;
            }
        }

        public CommandLetter(char letter)
        {
            Value = letter;
        }

        private bool IsValidLetter(char letter)
        {
            return Array.Exists(ValidLetters, l => l == letter);
        }
    }
}
