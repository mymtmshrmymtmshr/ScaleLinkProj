namespace ScaleLink;

using System.Windows;

static class Program
{
    [STAThread]
    static void Main()
    {
        var app = new Application();
        app.Run(new Forms.MainWindow());
    }
}