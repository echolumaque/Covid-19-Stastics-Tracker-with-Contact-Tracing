using NcoVAppUpdate.Models;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.ObjectModel;

namespace NcoVAppUpdate.View_Model
{
    public class HomePageViewModel : ViewModelBase
    {
        private static HttpClient _httpClient;

        public HomePageViewModel(INavigationService navigationService) : base(navigationService)
        {
            _httpClient = new HttpClient();
            SelectedCountryChangedCmd = new AsyncCommand(GetCovidCaseValueByCountry, allowsMultipleExecutions: false);
        }

        public string ActiveCases { get; set; }
        public List<Sparkline> ActiveCasesSparkline { get; set; }
        public ObservableCollection<string> Countries { get; set; }
        public string Deaths { get; set; }
        public bool IsBusy { get; set; }
        public string NewCases { get; set; }
        public string NewDeaths { get; set; }
        public string Recoveries { get; set; }
        public string SelectedCountry { get; set; }
        public IAsyncCommand SelectedCountryChangedCmd { get; }
        public string TotalCases { get; set; }
        public List<Sparkline> TotalCasesSparkline { get; set; }
        public List<Sparkline> TotalDeathsSparkline { get; set; }
        public List<Sparkline> TotalRecoveriesSparkline { get; set; }
        public string UpdateTime { get; set; }

        private async Task<TEntity> GetRestResponseFor<TEntity>(string requestUri)
        {
            var requestMessage = await _httpClient.SendAsync(new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(requestUri),
                Headers =
                {
                    { "X-RapidAPI-Key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c" },
                    { "X-RapidAPI-Host", "covid-193.p.rapidapi.com" },
                },
            }).ConfigureAwait(false);
            requestMessage.EnsureSuccessStatusCode();
            var deserializedResponse = await requestMessage.Content.ReadFromJsonAsync<TEntity>().ConfigureAwait(false);

            return deserializedResponse;
        }

        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            ActiveCases = TotalCases = Deaths = Recoveries = "0";
            NewCases = NewDeaths = "+0";
            var countriesResponse = await GetRestResponseFor<Countries>("https://covid-193.p.rapidapi.com/countries");
            Countries = new ObservableCollection<string>(countriesResponse.Response);
            SelectedCountry = Countries[166];

            await GetCovidCaseValueByCountry();
        }

        private async Task GetCovidCaseValueByCountry()
        {
            IsBusy = true;
            var dateNow = DateTime.Today.AddDays(1);
            var datesLastWeek = Enumerable.Range(0, 7).Select(_ => dateNow = dateNow.AddDays(-1));

            var casesList = new List<CovidCases>();
            foreach (var dates in datesLastWeek)
            {
                var requestUrl = $"https://covid-193.p.rapidapi.com/history?country={SelectedCountry}&day={dates.Year}-{dates.Month}-{dates.Day}";
                casesList.Add(await GetRestResponseFor<CovidCases>(requestUrl));
            }

            ActiveCases = $"{casesList[0].Response.First().Cases.Active:n0}";
            TotalCases = $"{casesList[0].Response.First().Cases.Total:n0}";
            NewCases = SanitizedNewCaseValues(casesList[0].Response.First().Cases.New);
            Deaths = $"{casesList[0].Response.First().Deaths.Total:n0}";
            NewDeaths = SanitizedNewCaseValues(casesList[0].Response.First().Deaths.New);
            Recoveries = $"{casesList[0].Response.First().Cases.Recovered:n0}";
            UpdateTime = casesList[0].Response.First().Time.ToString("MMMM dd, yyyy | hh:mm tt zzz");

            var activeCasesSparkline = new List<Sparkline>();
            var totalCasesSparkline = new List<Sparkline>();
            var totalDeathsSparkline = new List<Sparkline>();
            var totalRecoveriesSparkline = new List<Sparkline>();
            foreach (var item in casesList)
            {
                activeCasesSparkline.Add(new Sparkline { Dummy = 0, Value = item.Response.First().Cases.Active });
                totalCasesSparkline.Add(new Sparkline { Dummy = 0, Value = item.Response.First().Cases.Total });
                totalDeathsSparkline.Add(new Sparkline { Dummy = 0, Value = item.Response.First().Deaths.Total });
                totalRecoveriesSparkline.Add(new Sparkline { Dummy = 0, Value = item.Response.First().Cases.Recovered });
            }

            ActiveCasesSparkline = activeCasesSparkline;
            TotalCasesSparkline = totalCasesSparkline;
            TotalDeathsSparkline = totalDeathsSparkline;
            TotalRecoveriesSparkline = totalRecoveriesSparkline;
            IsBusy = false;
        }

        private string SanitizedNewCaseValues(string caseValue)
        {
            return string.IsNullOrWhiteSpace(caseValue) ? "+ 0" : caseValue;
        }
    }
}