using OfLife;

Console.Clear();

var game = new Game(A.Map
    .WithWidth(120)
    .WithHeight(40)
    .WithExplosion());

while (true)
{
    Console.Clear();
    game.Draw();

    game.Cycle();

    Thread.Sleep(100);
}


