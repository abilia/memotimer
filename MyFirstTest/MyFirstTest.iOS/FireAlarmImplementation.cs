using MyFirstTest;
using UIKit;
using Foundation;
using DependencyServiceSample.iOS;


[assembly: Xamarin.Forms.Dependency(typeof(FireAlarmImplementation))]
namespace DependencyServiceSample.iOS
{
    public class FireAlarmImplementation : IFireAlarm
    {
        public FireAlarmImplementation() { }
        public void PrepareAlarm()
        {
            UILocalNotification notification = new UILocalNotification();
            notification.FireDate = NSDate.FromTimeIntervalSinceNow(120);
            notification.AlertAction = "2 minutes due!";
            notification.AlertBody = "Something for you.....................";
            notification.SoundName = UILocalNotification.DefaultSoundName;
            UIApplication.SharedApplication.ScheduleLocalNotification(notification);
        }
    }
}
