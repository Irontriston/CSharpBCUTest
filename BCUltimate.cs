

namespace Battle_Cats_Ultimate_Test
{
    public class BCUltimate
    {
        public static bool Does60FPS;
        public static Random Rand;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        void Main()
        {
            Rand = new Random();
            Does60FPS = false;
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
        }
    }
}