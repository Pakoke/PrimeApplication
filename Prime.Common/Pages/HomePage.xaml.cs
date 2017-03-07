using Android.Widget;
using Plugin.Toasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Prime.Common.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }
        async void OnRotateAnimationButtonClicked(object sender, EventArgs e)
        {
            //var notificator = DependencyService.Get<IToastNotificator>();

            //var options = new NotificationOptions()
            //{
            //    Title = "Title",
            //    Description = "Description"
            //};

            //var result = await notificator.Notify(options);

            await Navigation.PushAsync(new ProductsGridPage());

        }
    }
}
