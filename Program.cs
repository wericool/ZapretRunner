using System;
using System.Windows.Forms;

namespace ZapretRunner
{
    static class Program
    {
        public static bool StartedFromAutostart = false;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1 && args[1] == "/autostart")
                StartedFromAutostart = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
