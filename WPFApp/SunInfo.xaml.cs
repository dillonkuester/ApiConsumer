using System;
using System.Windows;
using DemoLibrary;

namespace WPFApp
{
    /// <summary>
    /// Interaction logic for SunInfo.xaml
    /// </summary>
    public partial class SunInfo : Window
    {
        public SunInfo()
        {
            InitializeComponent();
        }

        private async void LoadSunInfo_Click(object sender, RoutedEventArgs e)
        {
            var sunInfo = await SunProcessor.LoadSunInformation();
            sunriseText.Text = $"Sunrise is at { sunInfo.Sunrise.ToLocalTime().ToShortTimeString() }";
            sunsetText.Text = $"Sunset is at { sunInfo.Sunset.ToLocalTime().ToShortTimeString() }";

        }
    }
}
