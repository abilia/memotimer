using MyFirstTest;
using Xamarin.Forms;
using DependencyServiceSample.Droid;
using Android.App;
using Android.Content;


[assembly: Xamarin.Forms.Dependency(typeof(FireAlarmImplementation))]
namespace DependencyServiceSample.Droid
{
    public class FireAlarmImplementation : Java.Lang.Object, IFireAlarm
    {
        public FireAlarmImplementation() { }

        public void PrepareAlarm()
        {
            Intent alarmIntent = new Intent(Forms.Context, typeof(MyFirstTest.Droid.AlarmReceiver));
            alarmIntent.PutExtra("message", "2 minutes due!");
            alarmIntent.PutExtra("title", "Something for you......................");
            PendingIntent pendingIntent = PendingIntent.GetBroadcast(Forms.Context, 0, alarmIntent, PendingIntentFlags.UpdateCurrent);
            AlarmManager alarmManager = (AlarmManager)Forms.Context.GetSystemService(Context.AlarmService);
            
            alarmManager.Set(AlarmType.ElapsedRealtime, Android.OS.SystemClock.ElapsedRealtime() + 120 * 1000, pendingIntent);
        }
    }
}