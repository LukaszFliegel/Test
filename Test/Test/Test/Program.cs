using System;

namespace Test
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            using (AlphaGame game = new AlphaGame())
            {
                game.Run();
            }
        }
    }
#endif
}

