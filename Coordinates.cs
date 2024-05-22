using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class Coordinates
    {
        private int _x;
        private int _y;

        public int X
        {
            get => _x;
            set
            {
                if (!IsNumber(value))
                {
                    throw new ArgumentException("Geçersiz koordinat! Koordinat olarak sadece tam sayı değerlerini girebilirsiniz.");
                }
                _x = value;
            }
        }

        public int Y
        {
            get => _y;
            set
            {
                if (!IsNumber(value))
                {
                    throw new ArgumentException("Geçersiz koordinat! Koordinat olarak sadece tam sayı değerlerini girebilirsiniz.");
                }
                _y = value;
            }
        }

        public Coordinates(int x, int y)
        {
            X = x;
            Y = y;
        }

        private bool IsNumber(int value)
        {
            return value.GetType() == typeof(int);
        }

        public void UpdateCoordinates(char direction, int surfaceWidth, int surfaceHeight)
        {
            switch (direction)
            {
                case 'N':
                    Y = Math.Min(Y + 1, surfaceHeight);
                    break;
                case 'S':
                    Y = Math.Max(Y - 1, 0);
                    break;
                case 'E':
                    X = Math.Min(X + 1, surfaceWidth);
                    break;
                case 'W':
                    X = Math.Max(X - 1, 0);
                    break;
            }
        }
    }
}
