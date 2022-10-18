using NcoVAppUpdate.View_Model;
using NcoVAppUpdate.Views;
using Prism;
using Prism.Ioc;
using Syncfusion.Licensing;
using Xamarin.Forms;

[assembly: ExportFont("SF-Compact-Text-Medium.otf", Alias = "Medium")]
[assembly: ExportFont("SF-UI-Display-Bold.otf", Alias = "Bold")]
[assembly: ExportFont("SF-UI-Display-Regular.otf", Alias = "Regular")]
namespace NcoVAppUpdate
{
    public partial class App
    {
        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            SyncfusionLicenseProvider.RegisterLicense("NzQyNDk1QDMyMzAyZTMzMmUzMFVGcnNZSWZMMWkrU2VBa1VGQ3ZrYnc3YURLajRxZ21rWWcvSzkzNW9NWkE9");
            await NavigationService.NavigateAsync("NavigationPage/HomePage");
            ((NavigationPage)Application.Current.MainPage).BarBackgroundColor = Color.FromHex("#212835");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
        }
    }
}