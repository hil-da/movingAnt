using System;
namespace movingAnt
{
    class Program
    {
        struct grid
        {
            public bool active;
            public int visited;
        }
        
        static void Main(string[] args)
        {
            int xSize;
            int ySize;
            int xPos = 0;
            int yPos = 0;
            int stepCount = 0;
            
            Console.WriteLine("Number of Rows?");
            while (!int.TryParse(Console.ReadLine(), out xSize) || xSize < 0) { Console.WriteLine("(!) Error: enter a real number"); }
            
            Console.WriteLine("Number of Columns?");
            while (!int.TryParse(Console.ReadLine(), out ySize) || ySize < 0) { Console.WriteLine("(!) Error: enter a real number"); }
            
            grid[,] capArray = new grid[xSize, ySize];

            while (true)
            {
                Random ranStep = new Random();
                switch (ranStep.Next(1, 4))
                {
                    case 1:
                        xPos++;
                        stepCount++;
                        break;
                    case 2:
                        yPos++;
                        stepCount++;
                        break;
                    case 3:
                        xPos--;
                        stepCount++;
                        break;
                    case 4:
                        yPos--;
                        stepCount++;
                        break;
                }
            }
        }
    }
}