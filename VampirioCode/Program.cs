using VampirioCode.SaveData;
using VampirioCode.Tests;

namespace VampirioCode
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Config.Initialize();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new App());
            //Application.Run(new TabTester());     // CALL Config.Initialize() before
            //Application.Run(new TabTester2());    // CALL Config.Initialize() before
            //Application.Run(new ScrollTester());  // CALL Config.Initialize() before
        }
    }
}