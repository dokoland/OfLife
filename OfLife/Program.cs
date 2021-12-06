// See https://aka.ms/new-console-template for more information
using OfLife;

Console.Clear();
var map = new GameMap(140, 40);
map.InitPentominoR();

while (1 == 1)
{
    

    //for (int i = 0; i < 130; i++)
    {
        Console.Clear();
        //Console.WriteLine($"{i}. Iteration ");
        map.Draw();
        map.Cycle();

        //Console.ReadLine();
        Thread.Sleep(100);
    }
}


