using Android.App;
using Android.Content;
using NcoVAppUpdate.Droid;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(LocalNotif))]

namespace NcoVAppUpdate.Droid
{
    public class LocalNotif : InterfaceLocalNotif
    {
        public void Alarm()
        {
            AlarmManager manager = Application.Context.GetSystemService(Context.AlarmService) as AlarmManager;
            Intent myIntent = new Intent(Application.Context, typeof(NotifBroadcastReceiver));
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Application.Context, 0, myIntent, 0);
            manager.SetRepeating(AlarmType.RtcWakeup, DateTime.Now.Millisecond, AlarmManager.IntervalDay, pendingIntent);
        }
        public void CancelNotifications()
        {
            AlarmManager manager = Application.Context.GetSystemService(Context.AlarmService) as AlarmManager;
            Intent myIntent = new Intent(Application.Context, typeof(NotifBroadcastReceiver));
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Application.Context, 0, myIntent, 0);
            if (manager != null)
            {
                manager.Cancel(pendingIntent);
            }
        }
    }
}