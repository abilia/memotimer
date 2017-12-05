using System;
using Xamarin.Forms;

namespace MyFirstTest
{
    public class MainPageCode : ContentPage
    {
        public MainPageCode()
        {
            BackgroundColor = Color.Silver;

            Label header = new Label
            {
                Text = "Press button to start 2 min. 'alarm'",
                Font = Font.BoldSystemFontOfSize(20),
                HorizontalOptions = LayoutOptions.Center
            };

            Button button = new Button
            {
                Text = "Click Me!",
                Font = Font.SystemFontOfSize(NamedSize.Large),
                BorderWidth = 1,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            button.Clicked += BtnAlarm_Clicked;

            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            // Build the page.
            this.Content = new StackLayout
            {
                Children =
                {
                    header,
                    button
                }
            };
        }

        private void BtnAlarm_Clicked(object sender, EventArgs e)
        {
            DependencyService.Get<IFireAlarm>().PrepareAlarm();
        }
    }
}
