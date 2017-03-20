using SiwakeApp.ViewModels;
using Xamarin.Forms;

namespace SiwakeApp.Views
{
    public partial class QuestionPage : CarouselPage
    {
        public QuestionPage()
        {
            InitializeComponent();
            
            if(Device.OS == TargetPlatform.Windows)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }

        private void Answer_Clicked(object sender, System.EventArgs e)
        {
            RootPageViewModel vm = BindingContext as RootPageViewModel;
            if (vm.EnableRightPage())
            {
                vm.RightPage();
            }
            else
            {
                Navigation.PushAsync(new ResultPage());
            }
            
        }
    }
}
