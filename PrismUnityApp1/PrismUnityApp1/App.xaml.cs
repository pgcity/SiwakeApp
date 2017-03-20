using Prism.Unity;
using SiwakeApp.Views;
using Xamarin.Forms;

namespace SiwakeApp
{
    public partial class App : PrismApplication
    {
        public App(IPlatformInitializer initializer = null) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await this.NavigationService.NavigateAsync("/RootPage/NavigationPage/StartPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<RootPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<StartPage>();
            Container.RegisterTypeForNavigation<QuestionPage>();
            Container.RegisterTypeForNavigation<ResultPage>();
        }
    }
}
