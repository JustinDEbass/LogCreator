using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogCreator
{
    static class Program
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(ErrorHandler);
            Application.ThreadException += new ThreadExceptionEventHandler(ErrorHandler);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());

            Environment.Exit(-1);
        }

        static void ErrorHandler(object sender, UnhandledExceptionEventArgs args)
        {
            var exception = (Exception)args.ExceptionObject;

            Logger.Error(exception);

            ShowExceptionDetails(exception);
        }

        static void ErrorHandler(object sender, ThreadExceptionEventArgs args)
        {
            var exception = args.Exception;

            Logger.Error(exception);

            ShowExceptionDetails(exception);
        }

        static void ShowExceptionDetails(Exception exception)
        {
            var message = $"При работе приложения возникла ошибка:\n{exception.Message}\n\nС более подробным описанием ошибки можно ознакомиться в каталоге \"Logs\".";

            MessageBox.Show(message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
