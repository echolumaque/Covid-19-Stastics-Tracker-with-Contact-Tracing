using Android;
using Android.App;
using Android.Content;
using Android.Media;
using Android.OS;
using Android.Support.V4.App;
using Newtonsoft.Json;
using RestSharp;
[assembly: UsesPermission(Manifest.Permission.ReceiveBootCompleted)]

namespace NcoVAppUpdate.Droid
{
    [BroadcastReceiver(Enabled = true)]
    [IntentFilter(new[] { Intent.ActionBootCompleted, Intent.ActionLockedBootCompleted })]
    public class NotifBroadcastReceiver : BroadcastReceiver
    {
        string TotalCases ="";
        string ActiveCases = "";
        string Recoveries = "";
        string Deaths = "";
        string NewTotalCases = "";
        string NewDeaths = "";
        string UpdateTime = "";
        public const string ID = "69421";

        private NotificationCompat.Builder mBuilder;

        NotificationCompat.BigTextStyle textStyle = new NotificationCompat.BigTextStyle();
        public override void OnReceive(Context context, Intent intent)
        {
            var sound = Android.Net.Uri.Parse(ContentResolver.SchemeAndroidResource + "://" + Android.App.Application.Context.PackageName + "/" + Resource.Raw.notification);
            var alarmAttributes = new AudioAttributes.Builder();
            mBuilder = new NotificationCompat.Builder(Application.Context, ID);
            mBuilder.SetSmallIcon(Resource.Drawable.ic_launcher);
            mBuilder.SetSound(sound)
                    .SetAutoCancel(true)
                    .SetPriority((int)NotificationPriority.Max)
                    .SetVibrate(new long[0])
                    .SetDefaults((int)NotificationDefaults.Sound | (int)NotificationDefaults.Vibrate)
                    .SetVisibility((int)NotificationVisibility.Public)
                    .SetSmallIcon(Resource.Drawable.ic_launcher)
                    .SetShowWhen(true);

            string longmessage = string.Format("COVID - 19 update at Philippines:\n\nAs of {1} GMT +06:00, there is {2} total cases of COVID - 19 with an active cases of {3}. Total recoveries is: {4} and total deaths is: {5}\n\nAdditional cases today: {6}\n New deaths today: {7}", "", UpdateTime, TotalCases, ActiveCases, Recoveries, Deaths, NewTotalCases, NewDeaths);
            textStyle.BigText(longmessage);
            textStyle.SetSummaryText("COVID - 19 update");
            mBuilder.SetStyle(textStyle);

            NotificationManager notificationManager = Application.Context.GetSystemService(Context.NotificationService) as NotificationManager;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
            {
                NotificationImportance importance = NotificationImportance.Max;
                NotificationChannel notificationChannel = new NotificationChannel(ID, "title", importance);
                notificationChannel.EnableLights(true);
                notificationChannel.EnableVibration(true);
                notificationChannel.SetSound(sound, alarmAttributes.Build());
                notificationChannel.SetShowBadge(true);
                notificationChannel.Importance = NotificationImportance.Max;
                notificationChannel.LockscreenVisibility = NotificationVisibility.Public;
                notificationChannel.ShouldVibrate();
                notificationChannel.ShouldShowLights();
                notificationChannel.SetVibrationPattern(new long[] { 100, 200, 300, 400, 500, 400, 300, 200, 400 });

                if (notificationManager != null)
                {
                    mBuilder.SetChannelId(ID);
                    notificationManager.CreateNotificationChannel(notificationChannel);
                }
            }
            notificationManager.Notify(0, mBuilder.Build());
        }

        public NotifBroadcastReceiver()
        {
            RestClient client = new RestClient(string.Format("https://covid-193.p.rapidapi.com/statistics?country={0}", "Philippines"));
            RestRequest request = new RestRequest(Method.GET);
            request.AddHeader("x-rapidapi-host", "covid-193.p.rapidapi.com");
            request.AddHeader("x-rapidapi-key", "d7b1359095msh2f3d1cf03fadfc9p17d1dcjsnb8086ea2665c");
            request.RequestFormat = DataFormat.Json;
            IRestResponse Response = client.Execute(request);
            CovidStats model = JsonConvert.DeserializeObject<CovidStats>(Response.Content);

            TotalCases =  model.Response[0].Cases.Total.ToString("#,###");
            ActiveCases = model.Response[0].Cases.Active.ToString("#,###");
            Recoveries =  model.Response[0].Cases.Recovered.ToString("#,###");
            Deaths =  model.Response[0].Deaths.Total.ToString("#,###");

            NewTotalCases = model.Response[0].Cases.New;
            NewDeaths = model.Response[0].Deaths.New;

            UpdateTime = model.Response[0].Time.ToString("MMMM dd, yyyy hh:mm:ss tt");
        }
    }
}