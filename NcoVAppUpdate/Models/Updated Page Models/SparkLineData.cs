using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NcoVAppUpdate
{
    public partial class SparkLineData1
    {
        [JsonProperty("response")]
        public List<Response> response { get; set; }
        public partial class Response
        {
            [JsonProperty("cases")]
            public Cases Cases { get; set; }

            [JsonProperty("deaths")]
            public Deaths Deaths { get; set; }
        }

        public partial class Cases
        {
            [JsonProperty("active")]
            public int Active { get; set; }
            [JsonProperty("recovered")]
            public int Recovered { get; set; }
            [JsonProperty("total")]
            public int Total { get; set; }
        }
        public partial class Deaths
        {
            [JsonProperty("total")]
            public int Total { get; set; }
        }
    }
    public partial class SparkLineData2
    {
        [JsonProperty("response")]
        public List<Response> response { get; set; }
        public partial class Response
        {
            [JsonProperty("cases")]
            public Cases Cases { get; set; }

            [JsonProperty("deaths")]
            public Deaths Deaths { get; set; }
        }

        public partial class Cases
        {
            [JsonProperty("active")]
            public int Active { get; set; }
            [JsonProperty("recovered")]
            public int Recovered { get; set; }
            [JsonProperty("total")]
            public int Total { get; set; }
        }
        public partial class Deaths
        {
            [JsonProperty("total")]
            public int Total { get; set; }
        }
    }
    public partial class SparkLineData3
    {
        [JsonProperty("response")]
        public List<Response> response { get; set; }
        public partial class Response
        {
            [JsonProperty("cases")]
            public Cases Cases { get; set; }

            [JsonProperty("deaths")]
            public Deaths Deaths { get; set; }
        }

        public partial class Cases
        {
            [JsonProperty("active")]
            public int Active { get; set; }
            [JsonProperty("recovered")]
            public int Recovered { get; set; }
            [JsonProperty("total")]
            public int Total { get; set; }
        }
        public partial class Deaths
        {
            [JsonProperty("total")]
            public int Total { get; set; }
        }
    }
    public partial class SparkLineData4
    {
        [JsonProperty("response")]
        public List<Response> response { get; set; }
        public partial class Response
        {
            [JsonProperty("cases")]
            public Cases Cases { get; set; }

            [JsonProperty("deaths")]
            public Deaths Deaths { get; set; }
        }

        public partial class Cases
        {
            [JsonProperty("active")]
            public int Active { get; set; }
            [JsonProperty("recovered")]
            public int Recovered { get; set; }
            [JsonProperty("total")]
            public int Total { get; set; }
        }
        public partial class Deaths
        {
            [JsonProperty("total")]
            public int Total { get; set; }
        }
    }
    public partial class SparkLineData5
    {
        [JsonProperty("response")]
        public List<Response> response { get; set; }
        public partial class Response
        {
            [JsonProperty("cases")]
            public Cases Cases { get; set; }

            [JsonProperty("deaths")]
            public Deaths Deaths { get; set; }
        }

        public partial class Cases
        {
            [JsonProperty("active")]
            public int Active { get; set; }
            [JsonProperty("recovered")]
            public int Recovered { get; set; }
            [JsonProperty("total")]
            public int Total { get; set; }
        }
        public partial class Deaths
        {
            [JsonProperty("total")]
            public int Total { get; set; }
        }
    }
    public partial class SparkLineData6
    {
        [JsonProperty("response")]
        public List<Response> response { get; set; }
        public partial class Response
        {
            [JsonProperty("cases")]
            public Cases Cases { get; set; }

            [JsonProperty("deaths")]
            public Deaths Deaths { get; set; }
        }

        public partial class Cases
        {
            [JsonProperty("active")]
            public int Active { get; set; }
            [JsonProperty("recovered")]
            public int Recovered { get; set; }
            [JsonProperty("total")]
            public int Total { get; set; }
        }
        public partial class Deaths
        {
            [JsonProperty("total")]
            public int Total { get; set; }
        }
    }
    public partial class SparkLineData7
    {
        [JsonProperty("response")]
        public List<Response> response { get; set; }
        public partial class Response
        {
            [JsonProperty("cases")]
            public Cases Cases { get; set; }

            [JsonProperty("deaths")]
            public Deaths Deaths { get; set; }
        }

        public partial class Cases
        {
            [JsonProperty("active")]
            public int Active { get; set; }
            [JsonProperty("recovered")]
            public int Recovered { get; set; }
            [JsonProperty("total")]
            public int Total { get; set; }
        }
        public partial class Deaths
        {
            [JsonProperty("total")]
            public int Total { get; set; }
        }
    }
    public partial class SparkLineData8
    {
        [JsonProperty("response")]
        public List<Response> response { get; set; }
        public partial class Response
        {
            [JsonProperty("cases")]
            public Cases Cases { get; set; }

            [JsonProperty("deaths")]
            public Deaths Deaths { get; set; }
        }

        public partial class Cases
        {
            [JsonProperty("active")]
            public int Active { get; set; }
            [JsonProperty("recovered")]
            public int Recovered { get; set; }
            [JsonProperty("total")]
            public int Total { get; set; }
        }
        public partial class Deaths
        {
            [JsonProperty("total")]
            public int Total { get; set; }
        }
    }

    public class TotalCasesModel
    {
        public int TotalCases { get; set; }
    }
    public class ActiveCasesModel
    {
        public int ActiveCases { get; set; }
    }
    public class TotalRecoveriesModel
    {
        public int TotalRecoveries { get; set; }
    }
    public class TotalDeathsModel
    {
        public int TotalDeaths { get; set; }
    }
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<TotalCasesModel> TotalCasesModelss { get; set; }
        public List<ActiveCasesModel> ActiveCasesModelss { get; set; }
        public List<TotalRecoveriesModel> TotalRecoveriesModelss { get; set; }
        public List<TotalDeathsModel> TotalDeathsModelss { get; set; }
        string totalCases;
        public string TotalCases
        {
            get => totalCases;
            set
            {
                if (totalCases != value)
                {
                    totalCases = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalCases"));
                }
            }
        }
        string activeCases;
        public string ActiveCases
        {
            get => activeCases;
            set
            {
                if (activeCases != value)
                {
                    activeCases = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("ActiveCases"));
                }
            }
        }
        string recoveries;
        public string Recoveries
        {
            get => recoveries;
            set 
            {
                if (recoveries != value)
                {
                    recoveries = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Recoveries"));
                }
            }
        }
        string deaths;
        public string TotalDeaths
        {
            get => deaths;
            set
            {
                if (deaths != value)
                {
                    deaths = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("TotalDeaths"));
                }
            }
        }
        string newCases;
        public string NewCases
        {
            get => newCases;
            set
            {
                if (newCases != value)
                {
                    newCases = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NewCases"));
                }
            }
        }
        string newDeaths;
        public string NewDeaths
        {
            get => newDeaths;
            set
            {
                if (newDeaths != value)
                {
                    newDeaths = value;
                    PropertyChanged.Invoke(this, new PropertyChangedEventArgs("NewDeaths"));
                }
            }
        }
        string updateTime;
        public string UpdateTime
        {
            get => updateTime;
            set
            {
                if (updateTime != value)
                {
                    updateTime = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UpdateTime"));
                }
            }
        }
        bool isBusy;
        public bool IsBusy
        {
            get => isBusy;
            set
            {
                if (isBusy != value)
                {
                    isBusy = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("IsBusy"));
                }
            }
        }
        public ViewModel()
        {
            Notify = new Command(async () => await SendNotif());
            SearchCountry = new Command(async () => await CountryStatsAsync());
        }
 
        public Command Notify { get; }
        async Task SendNotif()
        {
            bool answer = await Application.Current.MainPage.DisplayAlert("", "Do you wamt to get daily notifications for Philippines' COVID - 19 tally?", "Yes", "Cancel notifications");
            if (answer)
            {
                DependencyService.Get<InterfaceLocalNotif>().Alarm();
            }
            if (!answer)
            {
                DependencyService.Get<InterfaceLocalNotif>().CancelNotifications();

            }
        }


        object selectedItem;
        public object SelectedItem
        {
            get => selectedItem;
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("SelectedItem"));
                }
            }
        }

        public Command SearchCountry { get; }
        async Task CountryStatsAsync()
        {
            try
            {
                IsBusy = true;
                RestClient client = new RestClient(string.Format("https://covid-193.p.rapidapi.com/statistics?country={0}", SelectedItem.ToString()));
                RestRequest request = new RestRequest(Method.GET);
                request.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
                request.AddHeader("x-rapidapi-key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c");
                request.RequestFormat = DataFormat.Json;
                IRestResponse Response = await client.ExecuteAsync(request);
                CovidStats model = JsonConvert.DeserializeObject<CovidStats>(Response.Content);

                TotalCases = model.Response[0].Cases.Total.ToString("#,###");
                ActiveCases = model.Response[0].Cases.Active.ToString("#,###");
                Recoveries = model.Response[0].Cases.Recovered.ToString("#,###");
                TotalDeaths = model.Response[0].Deaths.Total.ToString("#,###");
                UpdateTime = "Last update: " +  model.Response[0].Time.ToString("MMMM dd, yyyy hh: mm:ss tt") + " GMT +06:00";
                NewCases = model.Response[0].Cases.New;
                NewDeaths = model.Response[0].Deaths.New;

                await Task.Delay(6000);
                IsBusy = false;
            }
            catch (Exception)
            {
                await Application.Current.MainPage.DisplayAlert("", "Please check your internet connection.", "Okay");
            }
        }
    }
}