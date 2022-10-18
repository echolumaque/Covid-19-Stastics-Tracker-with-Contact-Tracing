using Prism.Navigation;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace NcoVAppUpdate.View_Model
{
    public class HomePageViewModel : ViewModelBase
    {
        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
        }

        public ObservableCollection<TotalCasesModel> TotalCases { get; set; }
        public ObservableCollection<ActiveCasesModel> ActiveCases { get; set; }
        public ObservableCollection<TotalRecoveriesModel> TotalRecoveries { get; set; }
        public ObservableCollection<TotalDeathsModel> TotalDeaths { get; set; }
        public ObservableCollection<string> Countries { get; set; }
        public string SelectedCountry { get; set; }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            Countries = new ObservableCollection<string>
            {

            };
        }

        private async Task SparkLines(string country)
        {
            //try
            //{
            //    RestClient client1 = new RestClient(string.Format("https://covid-193.p.rapidapi.com/history?day=2020-03-23&country={0}", country));
            //    RestRequest request1 = new RestRequest(Method.GET);
            //    request1.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
            //    request1.AddHeader("x-rapidapi-key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c");
            //    IRestResponse response1 = await client1.ExecuteAsync(request1);
            //    SparkLineData1 sparkline1 = JsonConvert.DeserializeObject<SparkLineData1>(response1.Content);

            //    RestClient client2 = new RestClient(string.Format("https://covid-193.p.rapidapi.com/history?day=2020-04-30&country={0}", country));
            //    RestRequest request2 = new RestRequest(Method.GET);
            //    request2.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
            //    request2.AddHeader("x-rapidapi-key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c");
            //    IRestResponse response2 = await client2.ExecuteAsync(request2);
            //    SparkLineData3 sparkline2 = JsonConvert.DeserializeObject<SparkLineData3>(response2.Content);

            //    RestClient client3 = new RestClient(string.Format("https://covid-193.p.rapidapi.com/history?day=2020-05-29&country={0}", country));
            //    RestRequest request3 = new RestRequest(Method.GET);
            //    request3.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
            //    request3.AddHeader("x-rapidapi-key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c");
            //    IRestResponse response3 = await client3.ExecuteAsync(request3);
            //    SparkLineData5 sparkline3 = JsonConvert.DeserializeObject<SparkLineData5>(response3.Content);

            //    RestClient client4 = new RestClient(string.Format("https://covid-193.p.rapidapi.com/history?day=2020-06-30&country={0}", country));
            //    RestRequest request4 = new RestRequest(Method.GET);
            //    request4.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
            //    request4.AddHeader("x-rapidapi-key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c");
            //    IRestResponse response4 = await client4.ExecuteAsync(request4);
            //    SparkLineData7 sparkline4 = JsonConvert.DeserializeObject<SparkLineData7>(response4.Content);

            //    DateTime yesterday = DateTime.Now.AddDays(-7);

            //    RestClient client5 = new RestClient(string.Format("https://covid-193.p.rapidapi.com/history?day={0}&country={1}", yesterday.ToString("yyyy-MM-dd"), country));
            //    RestRequest request5 = new RestRequest(Method.GET);
            //    request5.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
            //    request5.AddHeader("x-rapidapi-key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c");
            //    IRestResponse response5 = await client5.ExecuteAsync(request5);
            //    SparkLineData8 sparkline5 = JsonConvert.DeserializeObject<SparkLineData8>(response5.Content);

            //    TotalCasesModelss = new List<TotalCasesModel>()
            //    {
            //        new TotalCasesModel { TotalCases = sparkline1.response[0].Cases.Total},
            //        new TotalCasesModel { TotalCases = sparkline2.response[0].Cases.Total},
            //        new TotalCasesModel { TotalCases = sparkline3.response[0].Cases.Total},
            //        new TotalCasesModel { TotalCases = sparkline4.response[0].Cases.Total},
            //        new TotalCasesModel { TotalCases = sparkline5.response[0].Cases.Total}
            //    };
            //    ActiveCasesModelss = new List<ActiveCasesModel>()
            //    {
            //        new ActiveCasesModel { ActiveCases = sparkline1.response[0].Cases.Active },
            //        new ActiveCasesModel { ActiveCases = sparkline2.response[0].Cases.Active },
            //        new ActiveCasesModel { ActiveCases = sparkline3.response[0].Cases.Active },
            //        new ActiveCasesModel { ActiveCases = sparkline4.response[0].Cases.Active },
            //        new ActiveCasesModel { ActiveCases = sparkline5.response[0].Cases.Active }
            //    };
            //    TotalRecoveriesModelss = new List<TotalRecoveriesModel>()
            //    {
            //        new TotalRecoveriesModel { TotalRecoveries = sparkline1.response[0].Cases.Recovered},
            //        new TotalRecoveriesModel { TotalRecoveries = sparkline2.response[0].Cases.Recovered},
            //        new TotalRecoveriesModel { TotalRecoveries = sparkline3.response[0].Cases.Recovered},
            //        new TotalRecoveriesModel { TotalRecoveries = sparkline4.response[0].Cases.Recovered},
            //        new TotalRecoveriesModel { TotalRecoveries = sparkline5.response[0].Cases.Recovered}
            //    };
            //    TotalDeathsModelss = new List<TotalDeathsModel>()
            //    {
            //        new TotalDeathsModel { TotalDeaths = sparkline1.response[0].Deaths.Total},
            //        new TotalDeathsModel { TotalDeaths = sparkline2.response[0].Deaths.Total},
            //        new TotalDeathsModel { TotalDeaths = sparkline3.response[0].Deaths.Total},
            //        new TotalDeathsModel { TotalDeaths = sparkline4.response[0].Deaths.Total},
            //        new TotalDeathsModel { TotalDeaths = sparkline5.response[0].Deaths.Total}
            //    };
            //    sparklineTOTAL.ItemsSource = TotalCasesModelss;
            //    sparklineTOTAL.YBindingPath = "TotalCases";

            //    sparkLINEACTIVE.ItemsSource = ActiveCasesModelss;
            //    sparkLINEACTIVE.YBindingPath = "ActiveCases";

            //    sparkLINERECOVER.ItemsSource = TotalRecoveriesModelss;
            //    sparkLINERECOVER.YBindingPath = "TotalRecoveries";

            //    sparklineDEATH.ItemsSource = TotalDeathsModelss;
            //    sparklineDEATH.YBindingPath = "TotalDeaths";
            //}
            //catch (AggregateException)
            //{
            //    await DisplayAlert("", "Please check your netowrk connection", "Okay");
            //}
            //catch (IndexOutOfRangeException)
            //{
            //    await DisplayAlert("", "The selected country doesn't have a COVID 19 cases or has low cases", "Okay");
            //}
            //catch (ArgumentOutOfRangeException)
            //{
            //    await DisplayAlert("", "The selected country doesn't have a COVID 19 cases or has low cases", "Okay");
            //}
        }
    }
}