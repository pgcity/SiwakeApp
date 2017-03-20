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

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new QuestionPage(), true);

            RootPageViewModel vm = BindingContext as RootPageViewModel;
            vm.ResetPage();
            vm.IsPresented = false;
        }
    }
}
