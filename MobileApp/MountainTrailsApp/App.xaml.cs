using MountainTrailsApp.Data;
using MountainTrailsApp.Models;
using System;
using System.IO;
using MountainTrailsApp.Models;


namespace MountainTrailsApp
{
    public partial class App : Application
    {
        static TrailsDatabase database;
        public static User CurrentUser { get; set; }

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

            MainPage = new NavigationPage(new LoginPage());

        }
    }
}
