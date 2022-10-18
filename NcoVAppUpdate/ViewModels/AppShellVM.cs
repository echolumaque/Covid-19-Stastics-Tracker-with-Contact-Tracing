using Xamarin.Essentials;
using Xamarin.Forms;

namespace NcoVAppUpdate.ViewModels
{
    public class AppShellVM
    {
        public AppShellVM()
        {
            DeveloperCredits = new Command(OpenFBNiEcho);
            Credits = new Command(FreepikSite);
        }

        public Command Credits { get; }
        public Command DeveloperCredits { get; }

        private void OpenFBNiEcho()
        {
            Launcher.OpenAsync("https://www.facebook.com/TataEchooo");
        }

        private void FreepikSite()
        {
            Launcher.OpenAsync("https://www.freepik.com/");
        }
    }
}