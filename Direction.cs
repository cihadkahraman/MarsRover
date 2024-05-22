using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Direction
    {
        private char _direction;
        private static readonly char[] ValidDirections = { 'N', 'W', 'S', 'E' };

        public char Value
        {
            get => _direction;
            set
            {
                if (!IsValidDirection(value))
                {
                    throw new ArgumentException("Geçersiz yön! Yön olarak sadece N, W, S, E karakterlerini girebilirsiniz.");
                }
                _direction = value;
            }
        }

        public Direction(char direction)
        {
            Value = direction;
        }

        private bool IsValidDirection(char direction)
        {
            return Array.Exists(ValidDirections, d => d == direction);
        }
    }
}
