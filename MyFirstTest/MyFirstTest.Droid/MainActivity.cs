using Android.App;
using Android.Content.PM;
using Android.OS;

using Android.Content;
using Android.Support.V4.App;
using Android.Media;

namespace MyFirstTest.Droid
{
    [Activity(Label = "MyFirstTest", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }
    }

    [BroadcastReceiver]
    public class AlarmReceiver : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            var message = intent.GetStringExtra("message");
            var title = intent.GetStringExtra("title");

            var notIntent = new Intent(context, typeof(MainActivity));
            notIntent.AddFlags(ActivityFlags.NewTask);
            var contentIntent = PendingIntent.GetActivity(context, 0, notIntent, PendingIntentFlags.CancelCurrent);
            var manager = NotificationManagerCompat.From(context);

            var style = new NotificationCompat.BigTextStyle();
            style.BigText(message);
            
            //Generate a notification with just short text and small icon
            var builder = new NotificationCompat.Builder(context)
                .SetDefaults(1|2) // sound and vibrate
                .SetSound(RingtoneManager.GetDefaultUri(RingtoneType.Alarm))
                .SetContentIntent(contentIntent)
                .SetSmallIcon(Resource.Drawable.icon)
                .SetContentTitle(title)
                .SetContentText(message)
                .SetStyle(style)
                .SetWhen(Java.Lang.JavaSystem.CurrentTimeMillis())
                .SetAutoCancel(true);
            var notification = builder.Build();
            manager.Notify(0, notification);

            // Will pull up app...
            context.StartActivity(notIntent);
            //Toast.MakeText(context, message, ToastLength.Short).Show();
        }
    }
}

