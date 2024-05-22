using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarsRover
{
    public class MoveService
    {

        public MoveResult ProcessCommand(Coordinates coordinates, Direction direction,Coordinates rectangleTopRightCoordinates, List<CommandLetter> commandLetters)
        {
            foreach (var letter in commandLetters)
            {
                if (letter.Value == 'L' || letter.Value == 'R')
                {
                    direction.Value = Turn(direction.Value, letter.Value);
                }
                else if (letter.Value == 'M')
                {
                    coordinates.UpdateCoordinates(direction.Value, rectangleTopRightCoordinates.X, rectangleTopRightCoordinates.Y);
                }
            }
            var result = new MoveResult();
            result.Coordinates = new Coordinates(coordinates.X, coordinates.Y);
            result.Direction = new Direction(direction.Value);
            return result;
        }

        public char Turn(char direction, char turnCommand)
        {
            string directions = "NWSE";
            int idx = directions.IndexOf(direction);

            if (turnCommand == 'L')
            {
                idx = (idx + 1) % 4; // Sola dönüş
            }
            else if (turnCommand == 'R')
            {
                idx = (idx + 3) % 4; // Sağa dönüş (dönüşü tersine çeviririz)
            }

            return directions[idx];
        }
    }
}
