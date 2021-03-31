using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NcoVAppUpdate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UpdatedPage : ContentPage
    {
        public UpdatedPage()
        {
            InitializeComponent();
            GetCountryNames();
        }
        private async void Button_Clicked(object sender, EventArgs e)
        {
            await SparkLines(ComboBoxCountries.SelectedItem.ToString());
        }
        void GetCountryNames()
        {
            try
            {
                string[] countries;
                countries = new string[188]
                    { 
                        "Afghanistan",
                        "Albania",
                        "Algeria"
                        ,"Andorra"
                        ,"Angola"
                        ,"Antigua-and-Barbuda"
                        ,"Argentina"
                        ,"Armenia"
                        ,"Aruba"
                        ,"Australia"
                        ,"Austria"
                        ,"Azerbaijan"
                        ,"Bahamas"
                        ,"Bahrain"
                        ,"Bangladesh"
                        ,"Barbados"
                        ,"Belarus"
                        ,"Belgium"
                        ,"Benin"
                        ,"Bermuda"
                        ,"Bhutan"
                        ,"Bolivia"
                        ,"Bosnia-and-Herzegovina"
                        ,"Brazil"
                        ,"Brunei-"
                        ,"Bulgaria"
                        ,"Burkina-Faso"
                        ,"Cabo-Verde"
                        ,"Cambodia"
                        ,"Cameroon"
                        ,"Canada"
                        ,"CAR"
                        ,"Cayman-Islands"
                        ,"Chad"
                        ,"Channel-Islands"
                        ,"Chile"
                        ,"China"
                        ,"Colombia"
                        ,"Congo"
                        ,"Costa-Rica"
                        ,"Croatia"
                        ,"Cuba"
                        ,"Cura&ccedil;ao"
                        ,"Cyprus"
                        ,"Czechia"
                        ,"Denmark"
                        ,"Diamond-Princess-"
                        ,"Djibouti"
                        ,"Dominican-Republic"
                        ,"DRC"
                        ,"Ecuador"
                        ,"Egypt"
                        ,"El-Salvador"
                        ,"Equatorial-Guinea"
                        ,"Eritrea"
                        ,"Estonia"
                        ,"Eswatini"
                        ,"Ethiopia"
                        ,"Faeroe-Islands"
                        ,"Fiji"
                        ,"Finland"
                        ,"France"
                        ,"French-Guiana"
                        ,"French-Polynesia"
                        ,"Gabon"
                        ,"Gambia"
                        ,"Georgia"
                        ,"Germany"
                        ,"Ghana"
                        ,"Gibraltar"
                        ,"Greece"
                        ,"Greenland"
                        ,"Guadeloupe"
                        ,"Guam"
                        ,"Guatemala"
                        ,"Guinea"
                        ,"Guyana"
                        ,"Haiti"
                        ,"Honduras"
                        ,"Hong-Kong"
                        ,"Hungary"
                        ,"Iceland"
                        ,"India"
                        ,"Indonesia"
                        ,"Iran"
                        ,"Iraq"
                        ,"Ireland"
                        ,"Isle-of-Man"
                        ,"Israel"
                        ,"Italy"
                        ,"Ivory-Coast"
                        ,"Jamaica"
                        ,"Japan"
                        ,"Jordan"
                        ,"Kazakhstan"
                        ,"Kenya"
                        ,"Kuwait"
                        ,"Kyrgyzstan"
                        ,"Latvia"
                        ,"Lebanon"
                        ,"Liberia"
                        ,"Liechtenstein"
                        ,"Lithuania"
                        ,"Luxembourg"
                        ,"Macao"
                        ,"Madagascar"
                        ,"Malaysia"
                        ,"Maldives"
                        ,"Malta"
                        ,"Martinique"
                        ,"Mauritania"
                        ,"Mauritius"
                        ,"Mayotte"
                        ,"Mexico"
                        ,"Moldova"
                        ,"Monaco"
                        ,"Mongolia"
                        ,"Montenegro"
                        ,"Montserrat"
                        ,"Morocco"
                        ,"Namibia"
                        ,"Nepal"
                        ,"Netherlands"
                        ,"New-Caledonia"
                        ,"New-Zealand"
                        ,"Nicaragua"
                        ,"Niger"
                        ,"Nigeria"
                        ,"North-Macedonia"
                        ,"Norway"
                        ,"Oman"
                        ,"Pakistan"
                        ,"Palestine"
                        ,"Panama"
                        ,"Papua-New-Guinea"
                        ,"Paraguay"
                        ,"Peru"
                        ,"Philippines"
                        ,"Poland"
                        ,"Portugal"
                        ,"Puerto-Rico"
                        ,"Qatar"
                        ,"Romania"
                        ,"Russia"
                        ,"Rwanda"
                        ,"S.-Korea"
                        ,"Saint-Lucia"
                        ,"Saint-Martin"
                        ,"San-Marino"
                        ,"Saudi-Arabia"
                        ,"Senegal"
                        ,"Serbia"
                        ,"Seychelles"
                        ,"Singapore"
                        ,"Sint-Maarten"
                        ,"Slovakia"
                        ,"Slovenia"
                        ,"Somalia"
                        ,"South-Africa"
                        ,"Spain"
                        ,"Sri-Lanka"
                        ,"St.-Barth"
                        ,"St.-Vincent-Grenadines"
                        ,"Sudan"
                        ,"Suriname"
                        ,"Sweden"
                        ,"Switzerland"
                        ,"Taiwan"
                        ,"Tanzania"
                        ,"Thailand"
                        ,"Timor-Leste"
                        ,"Togo"
                        ,"Trinidad-and-Tobago"
                        ,"Tunisia"
                        ,"Turkey"
                        ,"U.S.-Virgin-Islands"
                        ,"UAE"
                        ,"Uganda"
                        ,"UK"
                        ,"Ukraine"
                        ,"Uruguay"
                        ,"USA"
                        ,"Uzbekistan"
                        ,"Vatican-City"
                        ,"Venezuela"
                        ,"Vietnam"
                        ,"Zambia"
                        ,"Zimbabwe"
                    };
                List<string> countryNames = new List<string>();
                for (int i = 0; i < countries.Count(); i++)
                {
                    countryNames.Add(countries[i]);
                    countryNames.Sort();
                    ComboBoxCountries.ComboBoxSource = countryNames;
                }
            }
            catch (Exception)
            {
                DisplayAlert("", "Please relaunch the application.", "Okay");
            }
        }

        async Task SparkLines(string country)
        {
            try
            {
                RestClient client1 = new RestClient(string.Format("https://covid-193.p.rapidapi.com/history?day=2020-03-23&country={0}", country));
                RestRequest request1 = new RestRequest(Method.GET);
                request1.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
                request1.AddHeader("x-rapidapi-key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c");
                IRestResponse response1 = await client1.ExecuteAsync(request1);
                SparkLineData1 sparkline1 = JsonConvert.DeserializeObject<SparkLineData1>(response1.Content);

                RestClient client2 = new RestClient(string.Format("https://covid-193.p.rapidapi.com/history?day=2020-04-30&country={0}", country));
                RestRequest request2 = new RestRequest(Method.GET);
                request2.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
                request2.AddHeader("x-rapidapi-key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c");
                IRestResponse response2 = await client2.ExecuteAsync(request2);
                SparkLineData3 sparkline2 = JsonConvert.DeserializeObject<SparkLineData3>(response2.Content);

                RestClient client3 = new RestClient(string.Format("https://covid-193.p.rapidapi.com/history?day=2020-05-29&country={0}", country));
                RestRequest request3 = new RestRequest(Method.GET);
                request3.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
                request3.AddHeader("x-rapidapi-key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c");
                IRestResponse response3 = await client3.ExecuteAsync(request3);
                SparkLineData5 sparkline3 = JsonConvert.DeserializeObject<SparkLineData5>(response3.Content);

                RestClient client4 = new RestClient(string.Format("https://covid-193.p.rapidapi.com/history?day=2020-06-30&country={0}", country));
                RestRequest request4 = new RestRequest(Method.GET);
                request4.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
                request4.AddHeader("x-rapidapi-key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c");
                IRestResponse response4 = await client4.ExecuteAsync(request4);
                SparkLineData7 sparkline4 = JsonConvert.DeserializeObject<SparkLineData7>(response4.Content);

                DateTime yesterday = DateTime.Now.AddDays(-7);

                RestClient client5 = new RestClient(string.Format("https://covid-193.p.rapidapi.com/history?day={0}&country={1}", yesterday.ToString("yyyy-MM-dd"), country));
                RestRequest request5 = new RestRequest(Method.GET);
                request5.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
                request5.AddHeader("x-rapidapi-key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c");
                IRestResponse response5 = await client5.ExecuteAsync(request5);
                SparkLineData8 sparkline5 = JsonConvert.DeserializeObject<SparkLineData8>(response5.Content);

                TotalCasesModelss = new List<TotalCasesModel>()
                {
                    new TotalCasesModel { TotalCases = sparkline1.response[0].Cases.Total},
                    new TotalCasesModel { TotalCases = sparkline2.response[0].Cases.Total},
                    new TotalCasesModel { TotalCases = sparkline3.response[0].Cases.Total},
                    new TotalCasesModel { TotalCases = sparkline4.response[0].Cases.Total},
                    new TotalCasesModel { TotalCases = sparkline5.response[0].Cases.Total}
                };
                ActiveCasesModelss = new List<ActiveCasesModel>()
                {
                    new ActiveCasesModel { ActiveCases = sparkline1.response[0].Cases.Active },
                    new ActiveCasesModel { ActiveCases = sparkline2.response[0].Cases.Active },
                    new ActiveCasesModel { ActiveCases = sparkline3.response[0].Cases.Active },
                    new ActiveCasesModel { ActiveCases = sparkline4.response[0].Cases.Active },
                    new ActiveCasesModel { ActiveCases = sparkline5.response[0].Cases.Active }
                };
                TotalRecoveriesModelss = new List<TotalRecoveriesModel>()
                {
                    new TotalRecoveriesModel { TotalRecoveries = sparkline1.response[0].Cases.Recovered},
                    new TotalRecoveriesModel { TotalRecoveries = sparkline2.response[0].Cases.Recovered},
                    new TotalRecoveriesModel { TotalRecoveries = sparkline3.response[0].Cases.Recovered},
                    new TotalRecoveriesModel { TotalRecoveries = sparkline4.response[0].Cases.Recovered},
                    new TotalRecoveriesModel { TotalRecoveries = sparkline5.response[0].Cases.Recovered}
                };
                TotalDeathsModelss = new List<TotalDeathsModel>()
                {
                    new TotalDeathsModel { TotalDeaths = sparkline1.response[0].Deaths.Total},
                    new TotalDeathsModel { TotalDeaths = sparkline2.response[0].Deaths.Total},
                    new TotalDeathsModel { TotalDeaths = sparkline3.response[0].Deaths.Total},
                    new TotalDeathsModel { TotalDeaths = sparkline4.response[0].Deaths.Total},
                    new TotalDeathsModel { TotalDeaths = sparkline5.response[0].Deaths.Total}
                };
                sparklineTOTAL.ItemsSource = TotalCasesModelss;
                sparklineTOTAL.YBindingPath = "TotalCases";

                sparkLINEACTIVE.ItemsSource = ActiveCasesModelss;
                sparkLINEACTIVE.YBindingPath = "ActiveCases";

                sparkLINERECOVER.ItemsSource = TotalRecoveriesModelss;
                sparkLINERECOVER.YBindingPath = "TotalRecoveries";

                sparklineDEATH.ItemsSource = TotalDeathsModelss;
                sparklineDEATH.YBindingPath = "TotalDeaths";
            }
            catch (AggregateException)
            {
                await DisplayAlert("", "Please check your netowrk connection", "Okay");
            }
            catch (IndexOutOfRangeException)
            {
                await DisplayAlert("", "The selected country doesn't have a COVID 19 cases or has low cases", "Okay");
            }
            catch (ArgumentOutOfRangeException)
            {
                await DisplayAlert("", "The selected country doesn't have a COVID 19 cases or has low cases", "Okay");
            }
        }
        public List<TotalCasesModel> TotalCasesModelss { get; set; }
        public List<ActiveCasesModel> ActiveCasesModelss { get; set; }
        public List<TotalRecoveriesModel> TotalRecoveriesModelss { get; set; }
        public List<TotalDeathsModel> TotalDeathsModelss { get; set; }
    }
}