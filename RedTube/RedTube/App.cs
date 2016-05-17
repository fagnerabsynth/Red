using RedTube.views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace RedTube
{
    public class App : Application
    {

        private static Procura Procurar;

        private static MasterDetailPage master;
        public App()
        {
            Procurar = new Procura();

            master = new MasterDetailPage() { Master = new Categoria(), Detail = new NavigationPage(Procurar)};

            MainPage = master;
        }



        public static void Categoria(String cat)
        {
            Procurar.Atualiza(cat);
        }




        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
