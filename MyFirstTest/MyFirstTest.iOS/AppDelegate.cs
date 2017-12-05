using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

namespace MyFirstTest.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        private UIViewController viewController;
        private UIWindow window;
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();

            viewController = new UIViewController();
            window = new UIWindow();
            window.RootViewController = viewController;
            window.MakeKeyAndVisible();
            
            if (options != null)
            {
                // check for a local notification
                if (options.ContainsKey(UIApplication.LaunchOptionsLocalNotificationKey))
                {
                    var localNotification = options[UIApplication.LaunchOptionsLocalNotificationKey] as UILocalNotification;
                    if (localNotification != null)
                    {
                        UIAlertController okayAlertController = UIAlertController.Create(localNotification.AlertAction, localNotification.AlertBody, UIAlertControllerStyle.Alert);
                        okayAlertController.AddAction(UIAlertAction.Create("OK", UIAlertActionStyle.Default, null));
                        viewController.PresentViewController(okayAlertController, true, null);

                        // reset our badge
                        UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
                    }
                }
            }

            if (UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
            {
                var notificationSettings = UIUserNotificationSettings.GetSettingsForTypes(
                    UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound, null
                );
                UIApplication.SharedApplication.RegisterUserNotificationSettings(notificationSettings);
            }

            LoadApplication(new App());
            return base.FinishedLaunching(app, options);
        }

        
        public override void ReceivedLocalNotification(UIApplication application, UILocalNotification notification)
        {
            // show an alert
            UIAlertView alert = new UIAlertView() { Title = notification.AlertAction, Message = notification.AlertBody };
            alert.AddButton("OK");
            alert.Show();

            // reset our badge
            UIApplication.SharedApplication.ApplicationIconBadgeNumber = 0;
        }
    }
}
