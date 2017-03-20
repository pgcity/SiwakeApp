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
    }
}
