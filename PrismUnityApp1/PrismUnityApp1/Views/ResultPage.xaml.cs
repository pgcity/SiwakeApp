using SiwakeApp.ViewModels;
using Xamarin.Forms;

namespace SiwakeApp.Views
{
    public partial class ResultPage : ContentPage
    {
        public ResultPage()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.Windows)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }
    }
}
