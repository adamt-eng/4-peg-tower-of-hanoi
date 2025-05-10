using System;
using System.Windows.Forms;

namespace Four_Peg_Tower_of_Hanoi;

internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}