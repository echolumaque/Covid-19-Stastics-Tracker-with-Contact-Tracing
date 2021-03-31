using Xamarin.Forms;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Distribute;

namespace NcoVAppUpdate
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("Mjc0OTkwQDMxMzgyZTMxMmUzMGRSbEpoT2ZGOVppVVg5Y3ZJRm1SS01KU2d0eDZ4bTRSSVhBRllOTk1yd0E9");
        }

        protected override void OnStart()
        {
            AppCenter.Start("62472e61-0328-4252-a786-af51bb9b47ab",  typeof(Analytics), typeof(Crashes), typeof(Distribute));
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
