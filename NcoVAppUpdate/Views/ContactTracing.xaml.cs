using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NcoVAppUpdate
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactTracing : ContentPage
    {
        public ContactTracing()
        {
            InitializeComponent();
            bottomSheet.IsVisible = false;
        }
        private void Button_Clicked(object sender, EventArgs e) //BOTTOM DRAWER open
        {
            bottomSheet.IsVisible = true;
            var finalTranslation = Math.Max(Math.Min(0, -1000), -Math.Abs(getProportionCoordinate(.40)));
            bottomSheet.TranslateTo(bottomSheet.X, finalTranslation, 250, Easing.CubicInOut);

            bottomSheetSELFREPORT.IsVisible = false;
            var finalTranslations = Math.Max(Math.Min(0, -1000), -Math.Abs(getProportionCoordinate(0)));
            bottomSheetSELFREPORT.TranslateTo(bottomSheet.X, finalTranslations, 250, Easing.CubicInOut);
        }
        private async void btnSEARCH_Clicked(object sender, EventArgs e) // filtered cases doh
        {
            try
            {
                //var finalTranslation = Math.Max(Math.Min(0, -1000), -Math.Abs(getProportionCoordinate(.05)));
                //await bottomSheet.TranslateTo(bottomSheet.X, finalTranslation, 250, Easing.CubicInOut);

                //const string connString = "mongodb://echo:koekoe15@cluster0-shard-00-00-jwnsw.mongodb.net:27017,cluster0-shard-00-01-jwnsw.mongodb.net:27017,cluster0-shard-00-02-jwnsw.mongodb.net:27017/FilteredDeomographics?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority";
                //var client = new MongoClient(connString);
                //IMongoDatabase db = client.GetDatabase("FilteredDeomographics");
                //IMongoCollection<DOHData> collection = db.GetCollection<DOHData>("FilteredDeomographics");

                //List<DOHData> AllTriage = await collection.AsQueryable().ToListAsync<DOHData>();

                //var filter = from filtered in AllTriage
                //             where filtered.Region.Equals(pckrREGION.SelectedItem.ToString())
                //             select filtered;

                //foreach (DOHData FilteredCases in filter)
                //{
                //    var infos = string.Format("Region: {0}\nTotal Cases: {1}\nActive Cases: {2}\nRecovered: {3}\nDied: {4}\nAsymptomatic: {5}\nMild: {6}\nSevere: {7}\nCritical: {8}\nNot admitted: {9}\nMale: {10}\nFemale: {11}"
                //                    , FilteredCases.Region, FilteredCases.TotalCases, FilteredCases.ActiveCases, FilteredCases.Recovered, FilteredCases.Died, FilteredCases.Asymptomatic, FilteredCases.Mild, FilteredCases.Severe,
                //                    FilteredCases.Critical, FilteredCases.NotAdmitted, FilteredCases.Male, FilteredCases.Female);
                //    var AllCovidPins = new Pin
                //    {
                //        Label = FilteredCases.Region,
                //        Type = PinType.Place,
                //        Position = new Position(FilteredCases.Latitude, FilteredCases.Longitude)
                //    };
                //    mapCONTACTTRACING.Pins.Add(AllCovidPins);
                //    AllCovidPins.InfoWindowClicked += async (s, args) =>
                //    {
                //        await DisplayAlert(AllCovidPins.Label, infos.ToString(), "Okay");
                //    };
                //}
                //todo: here
            }
            catch (Exception)
            {
                await DisplayAlert("", "Please check your internet connection.", "Okay");
            }
        } //filtered cases from doh
        private async void btnSHOWALL_Clicked(object sender, EventArgs e) // all cases doh
        {
            try
            {
                //var finalTranslation = Math.Max(Math.Min(0, -1000), -Math.Abs(getProportionCoordinate(.05)));
                //await bottomSheet.TranslateTo(bottomSheet.X, finalTranslation, 250, Easing.CubicInOut);

                //const string connString = "mongodb://echo:koekoe15@cluster0-shard-00-00-jwnsw.mongodb.net:27017,cluster0-shard-00-01-jwnsw.mongodb.net:27017,cluster0-shard-00-02-jwnsw.mongodb.net:27017/FilteredDeomographics?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority";
                //var client = new MongoClient(connString);
                //IMongoDatabase db = client.GetDatabase("FilteredDeomographics");
                //IMongoCollection<DOHData> collection = db.GetCollection<DOHData>("FilteredDeomographics");

                //List<DOHData> AllTriage = await collection.AsQueryable().ToListAsync<DOHData>();

                //foreach (var ShowAllTriage in AllTriage)
                //{
                //    var infos = string.Format("Region: {0}\nTotal Cases: {1}\nActive Cases: {2}\nRecovered: {3}\nDied: {4}\nAsymptomatic: {5}\nMild: {6}\nSevere: {7}\nCritical: {8}\nNot admitted: {9}\nMale: {10}\nFemale: {11}"
                //                    , ShowAllTriage.Region, ShowAllTriage.TotalCases, ShowAllTriage.ActiveCases, ShowAllTriage.Recovered, ShowAllTriage.Died, ShowAllTriage.Asymptomatic, ShowAllTriage.Mild, ShowAllTriage.Severe,
                //                    ShowAllTriage.Critical, ShowAllTriage.NotAdmitted, ShowAllTriage.Male, ShowAllTriage.Female);
                //    var AllCovidPins = new Pin
                //    {
                //        Label = ShowAllTriage.Region,
                //        Type = PinType.Place,
                //        Position = new Position(ShowAllTriage.Latitude, ShowAllTriage.Longitude)
                //    };
                //    mapCONTACTTRACING.Pins.Add(AllCovidPins);
                //    AllCovidPins.InfoWindowClicked += async (s, args) =>
                //    {
                //        await DisplayAlert(AllCovidPins.Label, infos.ToString(), "Okay");
                //    };
                //}
                //todo: here
            }
            catch (Exception)
            {
                await DisplayAlert("", "Please check your internet connection.", "Okay");
            }
        }
        private async void BtnRemoveRegionalPins_Clicked(object sender, EventArgs e)
        {
            var finalTranslation = Math.Max(Math.Min(0, -1000), -Math.Abs(getProportionCoordinate(.05)));
            await bottomSheet.TranslateTo(bottomSheet.X, finalTranslation, 250, Easing.CubicInOut);

            mapCONTACTTRACING.Pins.Clear();
        }

        private void Button_Clicked_1(object sender, EventArgs e) // self report open
        {
            bottomSheetSELFREPORT.IsVisible = true;
            var finalTranslation = Math.Max(Math.Min(0, -1000), -Math.Abs(getProportionCoordinate(.70)));
            bottomSheetSELFREPORT.TranslateTo(bottomSheet.X, finalTranslation, 250, Easing.CubicInOut);
        }
        private async void BtnPatients_Clicked(object sender, EventArgs e)
        {
            try
            {
                //var finalTranslation = Math.Max(Math.Min(0, -1000), -Math.Abs(getProportionCoordinate(.05)));
                //await bottomSheetSELFREPORT.TranslateTo(bottomSheetSELFREPORT.X, finalTranslation, 250, Easing.CubicInOut);

                //const string connString = "mongodb://echo:koekoe15@cluster0-shard-00-00-jwnsw.mongodb.net:27017,cluster0-shard-00-01-jwnsw.mongodb.net:27017,cluster0-shard-00-02-jwnsw.mongodb.net:27017/NCoVCases?ssl=true&replicaSet=Cluster0-shard-0&authSource=admin&retryWrites=true&w=majority";
                //var client = new MongoClient(connString);
                //IMongoDatabase db = client.GetDatabase("NCoVCases");
                //IMongoCollection<Bayanihan> collection = db.GetCollection<Bayanihan>("Triages");

                //List<Bayanihan> AllTriage = await collection.AsQueryable().ToListAsync<Bayanihan>();

                //foreach (Bayanihan FilteredCases in AllTriage)
                //{
                //    var infos = string.Format("Test result: {0}\nSymptoms: {1}", FilteredCases.Triage, FilteredCases.Symptoms);
                //    var CovidPatients = new Pin
                //    {
                //        Label = FilteredCases.Triage,
                //        Type = PinType.Place,
                //        Position = new Position(FilteredCases.Latitude, FilteredCases.Longitude)
                //    };
                //    mapCONTACTTRACING.Pins.Add(CovidPatients);
                //    CovidPatients.InfoWindowClicked += async (s, args) =>
                //    {
                //        await DisplayAlert(CovidPatients.Label, infos.ToString(), "Okay");
                //    };
                //}
                //todo here
            }
            catch (Exception)
            {
                await DisplayAlert("", "Please check your internet connection.", "Okay");
            }
        }
        private async void BtnRemovePatients_Clicked(object sender, EventArgs e)
        {
            var finalTranslation = Math.Max(Math.Min(0, -1000), -Math.Abs(getProportionCoordinate(.05)));
            await bottomSheetSELFREPORT.TranslateTo(bottomSheetSELFREPORT.X, finalTranslation, 250, Easing.CubicInOut);

            mapCONTACTTRACING.Pins.Clear();

        }
        public double getProportionCoordinate(double proportion)
        {
            return proportion * Height;
        }
    }
}