using System;

namespace MarsRover
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MoveService moveService = new MoveService();
            MoveResult moveResult = new MoveResult();

            try
            {
                Console.WriteLine("Yüzeyin boyutlarını girin (x y):");
                var surfaceSize = Console.ReadLine().Split(' ');
                int surfaceWidth = int.Parse(surfaceSize[0]);
                int surfaceHeight = int.Parse(surfaceSize[1]);

                if (surfaceSize.Length > 2)
                {
                    Console.WriteLine("2 karakterden fazla koordinat girdiniz, işlemlerde sadece ilk iki karakter hesaba katılacaktır. Bilginize.");
                }

                Coordinates surfaceTopRight = new Coordinates(int.Parse(surfaceSize[0]), int.Parse(surfaceSize[1]));

                for (int i = 1; i <= 2; i++)
                {


                    Console.WriteLine($"{i}. robot için başlangıç konumunu giriniz (x y yön):");
                    var initialPosition = Console.ReadLine().Split(' ');

                    if (initialPosition.Length > 3)
                    {
                        Console.WriteLine("3 karakterden fazla konum bilgisi girdiniz, işlemlerde sadece ilk üç karakter hesaba katılacaktır. Bilginize.");
                    }

                    Coordinates robotInitialCoodinates = new Coordinates(int.Parse(initialPosition[0]), int.Parse(initialPosition[1]));
                    Direction robotDirection = new Direction(char.Parse(initialPosition[2]));

                    Console.WriteLine($"{i}. robot için hareket komutlarını giriniz):");
                    var commands = Console.ReadLine().ToCharArray();

                    List<CommandLetter> commandList = new List<CommandLetter>();

                    foreach (char c in commands)
                    {
                        CommandLetter move = new CommandLetter(c);
                        commandList.Add(move);
                    }

                    moveResult = moveService.ProcessCommand(robotInitialCoodinates, robotDirection, surfaceTopRight, commandList);

                    Console.WriteLine($"{i}. robotun son konumu (x y yön): {moveResult.Coordinates.X} {moveResult.Coordinates.Y} {moveResult.Direction.Value}");
                }
                Console.WriteLine("Program tamamlandı, çıkmak için bir tuşa basın.");
                Console.ReadKey();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            } 
        }
    }
}