using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Eje2_2.Controller;
using System.IO;

namespace Eje2_2
{
    public partial class App : Application
    {
        static SQLiFirmasController db;
        public static SQLiFirmasController dbFirmas
        {
            get
            {
                if (db == null)
                {
                    String FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "dbFirmas.db3");
                    db = new SQLiFirmasController(FolderPath);
                }

                return db;
            }
        }
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
