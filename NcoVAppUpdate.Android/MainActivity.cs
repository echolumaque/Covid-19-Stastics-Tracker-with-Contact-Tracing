using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using AndroidX.Core.View;
using Prism;
using Prism.Ioc;
using Xamarin;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;
using Platform = Xamarin.Essentials.Platform;

namespace NcoVAppUpdate.Droid
{
    [Activity(Label = "SARS NCoV 2019 Tracker",
        Icon = "@mipmap/ic_launcher",
        Theme = "@style/MainTheme",
        MainLauncher = true,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class MainActivity : FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            //AppCenter.Start("62472e61-0328-4252-a786-af51bb9b47ab", typeof(Analytics), typeof(Crashes), typeof(Distribute));

            Platform.Init(this, savedInstanceState);
            Forms.Init(this, savedInstanceState);
            FormsMaterial.Init(this, savedInstanceState);
            FormsMaps.Init(this, savedInstanceState);

            Window.AddFlags(WindowManagerFlags.DrawsSystemBarBackgrounds);
            Window.ClearFlags(WindowManagerFlags.TranslucentStatus);
            Window.SetStatusBarColor(Color.ParseColor("#212835"));
            //Window.SetNavigationBarColor(isLightMode ? Color.ParseColor("#E6E6E6") : Color.Black);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.M)
            {
                WindowCompat.GetInsetsController(Window, Window.DecorView).AppearanceLightStatusBars = false;
                WindowCompat.GetInsetsController(Window, Window.DecorView).AppearanceLightNavigationBars = false;
            }

            LoadApplication(new App(new AndroidInitializer()));
        }

        //private const int RequestLocationId = 0;
        //private readonly string[] LocationPermissions =
        //{
        //     Manifest.Permission.AccessCoarseLocation,
        //     Manifest.Permission.AccessFineLocation
        //};

        //protected override void OnStart()
        //{
        //    base.OnStart();

        //    if ((int)Build.VERSION.SdkInt >= 23)
        //    {
        //        if (CheckSelfPermission(Manifest.Permission.AccessFineLocation) != Permission.Granted)
        //        {
        //            RequestPermissions(LocationPermissions, RequestLocationId);
        //        }
        //        else
        //        {
        //            // Permissions already granted - display a message.
        //        }
        //    }
        //}

        //public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Permission[] grantResults)
        //{
        //    if (requestCode == RequestLocationId)
        //    {
        //        if ((grantResults.Length == 1) && (grantResults[0] == (int)Permission.Granted))
        //        {
        //            // Permissions granted - display a message.
        //        }
        //    }
        //    else
        //    {
        //        base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        //    }
        //}
    }

    public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // Register any platform specific implementations
        }
    }
}