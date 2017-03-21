using Android.App;
using Android.Widget;
using Android.OS;
using Prime.Common;
using Xamarin.Forms;
using Plugin.Toasts;
using FFImageLoading.Forms.Droid;

namespace Prime.Droid
{
    [Activity(Label = "Prime.Droid", MainLauncher = true, Icon = "@drawable/icon",ConfigurationChanges =Android.Content.PM.ConfigChanges.ScreenSize|Android.Content.PM.ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            DependencyService.Register<ToastNotification>(); // Register your dependency

            // If you are using Android you must pass through the activity
            ToastNotification.Init(this);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            CachedImageRenderer.Init();
            LoadApplication(new App());
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);

        }
    }


}

