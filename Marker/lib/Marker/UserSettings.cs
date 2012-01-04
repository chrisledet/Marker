using System;
using System.Text;
using System.Drawing;

namespace Marker
{
    class UserSettings
    {
        public static void SaveWindowSize(Size size)
        {
            Properties.Settings.Default.MainWindowSize = size;
            Properties.Settings.Default.Save();
        }

        public static Size LoadWindowSize()
        {
            return Properties.Settings.Default.MainWindowSize;
        }
    }
}
