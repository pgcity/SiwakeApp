using SiwakeApp.ViewModels;
using Xamarin.Forms;

namespace SiwakeApp.Views
{
    public partial class StartPage : ContentPage
    {
        private RootPageViewModel ViewModel => this.BindingContext as RootPageViewModel;

        public StartPage()
        {
            InitializeComponent();
        }

        private void ContentPage_Appearing(object sender, System.EventArgs e)
        {
            if (Device.OS == TargetPlatform.Windows)
            {
                var vm = BindingContext as StartPageViewModel;
                if(vm != null)
                {
                    vm.RootViewModel.IsPresented = true;
                }
            }
        }
    }
}
