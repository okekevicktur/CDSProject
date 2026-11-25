using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CDSProject
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SplashThread = new Thread(new ThreadStart(ShowSplash));
            SplashThread.SetApartmentState(ApartmentState.STA);
            SplashThread.IsBackground = true;
            SplashThread.Start();
            Thread.Sleep(5000);
            
            Application.Run(new LoginForm(string.Empty, string.Empty));
        }
        public static Thread SplashThread;
        public static Form SplashForm;

        private static void ShowSplash()
        {
            SplashForm = new FormSplashScreen();
            Application.Run(SplashForm);
        }



    }
}
