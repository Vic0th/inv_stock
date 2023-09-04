using System;
using System.Windows.Forms;

namespace Inventory_track
{
    static class Program
    {
        [STAThread]
        static void Main(){
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
