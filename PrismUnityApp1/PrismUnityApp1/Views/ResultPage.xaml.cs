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



        private async System.Threading.Tasks.Task Button_ClickedAsync(object sender, System.EventArgs e)
        {
            var page = Navigation.NavigationStack[0];
            while (page.Navigation.NavigationStack.Count > 1)
            {
                await page.Navigation.PopAsync(false);
            }

            RootPageViewModel vm = BindingContext as RootPageViewModel;
            vm.IsResult = false;
        }

        /// <summary>
        /// 表示されたとき
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ContentPage_Appearing(object sender, System.EventArgs e)
        {
            RootPageViewModel vm = BindingContext as RootPageViewModel;
            vm.IsResult = true;
        }
    }
}
