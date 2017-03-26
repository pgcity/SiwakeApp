using Xamarin.Forms;

namespace SiwakeApp.Views
{
    public partial class QuestionPage2 : CarouselPage
    {
        public QuestionPage2()
        {
            InitializeComponent();

            if (Device.OS == TargetPlatform.Windows)
            {
                NavigationPage.SetHasNavigationBar(this, false);
            }
        }
    }
}
