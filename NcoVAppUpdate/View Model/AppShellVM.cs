using Xamarin.Essentials;
using Xamarin.Forms;

namespace NcoVAppUpdate
{
    public class AppShellVM
    {
        public AppShellVM()
        {
            DeveloperCredits = new Command(OpenFBNiEcho);
            Credits = new Command(FreepikSite);
        }  
        public Command DeveloperCredits { get; }
        void OpenFBNiEcho()
        {
            Launcher.OpenAsync("https://www.facebook.com/TataEchooo");
        }
        public Command Credits { get; }
        void FreepikSite()
        {
            Launcher.OpenAsync("https://www.freepik.com/");
        }
    }
}