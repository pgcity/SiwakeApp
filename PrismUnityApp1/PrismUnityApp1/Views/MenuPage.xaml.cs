using SiwakeApp.ViewModels;
using Xamarin.Forms;

namespace SiwakeApp.Views
{
    public partial class MenuPage : ContentPage
    {
        private RootPageViewModel ViewModel => this.BindingContext as RootPageViewModel;

        public MenuPage()
        {
            InitializeComponent();
        }

        private void ListViewMenu_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            this.ViewModel.PageChange(e.SelectedItem as QuestionSetInfo);
        }
    }
}
