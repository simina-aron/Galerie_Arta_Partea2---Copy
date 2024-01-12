using System;
using Galerie_Arta_Partea2.Data;
using System.IO;

namespace Galerie_Arta_Partea2
{
    public partial class App : Application
    {
        static Programare_vizualizare_database database;
        public static Programare_vizualizare_database Database
        {
            get
            {
                if (database == null)
                {
                    database = new
                    Programare_vizualizare_database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.
                    LocalApplicationData), "ProgramareVizualizare.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}
