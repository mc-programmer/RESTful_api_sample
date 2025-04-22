using Blog.Console;

while (true)
{
    Console.WriteLine("blah");

    int x = int.Parse(Console.ReadLine() ?? "0");

    Console.WriteLine("blah");

    int y = int.Parse(Console.ReadLine() ?? "0");

    MathHelper asd = new MathHelper();

    var result = asd.Jam(x, y);

    Console.WriteLine(result);
}