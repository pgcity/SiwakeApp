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

            await this.NavigationService.NavigateAsync("/RootPage");
        }

        protected override void RegisterTypes()
        {
            Container.RegisterTypeForNavigation<RootPage>();
            Container.RegisterTypeForNavigation<StartPage>();
            Container.RegisterTypeForNavigation<ResultPage>();
            Container.RegisterTypeForNavigation<NavigationPage>();
            Container.RegisterTypeForNavigation<QuestionPage2>();
            Container.RegisterTypeForNavigation<UrlInputPage>();
        }
    }
}
