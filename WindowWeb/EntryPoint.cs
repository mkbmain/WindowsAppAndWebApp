using System;
using System.Threading.Tasks;

namespace WindowWeb
{
    public class EntryPoint
    {
        [STAThread]
        public static void Main(string[] arg)
        {
            System.Windows.Forms.Application.Run(new Window());
        }
    }
}