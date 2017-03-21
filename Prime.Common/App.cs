using DLToolkit.Forms.Controls;
using Prime.Common.Helpers;
using Prime.Common.Models;
using Prime.Common.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamvvm;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Prime.Common
{
    public class App : Application
    {
        public static uint AnimationSpeed = 250;
        public static int DelaySpeed = 300;
        //public IHUDProvider _hud;
        static App _instance;

        public static App Instance
        {
            get
            {
                return _instance;
            }
        }

        public Theming Theming
        {
            get;
            set;
        } = new Theming();

        public App()
        {
            _instance = this;

            FlowListView.Init();

            var factory = new XamvvmFormsFactory(this);
            factory.RegisterNavigationPage<MainNavigationPageModel>(() => this.GetPageAsNewInstance<MainPageModel>());
            XamvvmCore.SetCurrentFactory(factory);
            MainPage = this.GetPageFromCache<MainNavigationPageModel>() as Page;
            //MainPage = new NavigationPage(new HomePage());
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
