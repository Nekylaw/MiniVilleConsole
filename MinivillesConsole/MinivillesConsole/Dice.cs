namespace MinivillesConsole
{
    internal class Dice
    {
        private readonly Random _random = new();

        public int Throw()
        {
            return _random.Next(1,7);
        }
    }
}
