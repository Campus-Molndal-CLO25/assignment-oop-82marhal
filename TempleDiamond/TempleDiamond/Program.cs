namespace TempleDiamond

{
    internal class Program
    {
        public static MainGame CurrentGame { get; set; }    
        
        static void Main(string[] args)
        {
            MainGame game = new MainGame();
            game.Start();
        }
    }
}