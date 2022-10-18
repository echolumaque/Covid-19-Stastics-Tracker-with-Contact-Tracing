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
        public App(IPlatformInitializer initializer) : base(initializer)
        {
            MainPage = new AppShell();
            SyncfusionLicenseProvider.RegisterLicense("NzQyNDk1QDMyMzAyZTMzMmUzMFVGcnNZSWZMMWkrU2VBa1VGQ3ZrYnc3YURLajRxZ21rWWcvSzkzNW9NWkE9");
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();
            //await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();

            //containerRegistry.RegisterForNavigation<NavigationPage>();
            //containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
        }
    }
}