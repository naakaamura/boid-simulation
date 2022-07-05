namespace BoidSimulation
{
    public static class Program
    {
        public static void Main()
        {
            Bootstrap.Initialize_FNA();

            using BoidGame game = new();
            game.Run();
        }
    }
}