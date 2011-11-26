using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Marker
{
    static class Program
    {
        [STAThread]
        static void Main(String[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainWindow mainWindow;

            if (args.Length > 0)
            {
                mainWindow = new MainWindow(args[0]);
            }
            else
            {
                mainWindow = new MainWindow();
            }

            Application.Run(mainWindow);
        }
    }
}
