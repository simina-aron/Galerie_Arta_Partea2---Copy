using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using System;

namespace Galerie_Arta_Partea2
{
    internal class Program : MauiApplication
    {
        protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();

        static void Main(string[] args)
        {
            var app = new Program();
            app.Run(args);
        }
    }
}
