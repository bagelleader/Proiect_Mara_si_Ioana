using System;
using System.IO;
using MountainTrailsApp.Data;

namespace MountainTrailsApp
{
    public partial class App : Application
    {
        static TrailsDatabase database;

        public static TrailsDatabase Database
        {
            get
            {
                if (database == null)
                {
                    var dbPath = Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                        "trails.db3");

                    database = new TrailsDatabase(dbPath);
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
