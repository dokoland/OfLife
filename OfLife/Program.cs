// See https://aka.ms/new-console-template for more information
using OfLife;

Console.Clear();
var game = new Game(A.Map
    .WithWidth(120)
    .WithHeight(40)
    .WithPentominoR());

while (true)
{
    Console.Clear();
    //Console.WriteLine($"{i}. Iteration ");
    game.Draw();
    game.Cycle();

    Thread.Sleep(100);
}


