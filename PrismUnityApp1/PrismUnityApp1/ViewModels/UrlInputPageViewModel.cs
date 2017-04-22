using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SiwakeApp.ViewModels
{
    public class UrlInputPageViewModel : BindableBase, INavigationAware
    {
        public UrlInputPageViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;

            OKCommand = new Command(async () =>
            {
                var param = new NavigationParameters();
                param["QuestionUrl"] = QuestionUrl;

                await this.NavigationService.NavigateAsync("/RootPage", param);
            });
            CancelCommand = new Command(async () =>
            {
                await this.NavigationService.NavigateAsync("/RootPage");
            });
        }

        //プロパティ
        private INavigationService NavigationService { get; }

        private string questionUrl;
        public string QuestionUrl
        {
            get { return questionUrl; }
            set { SetProperty(ref questionUrl, value); }
        }

        //コマンド
        public ICommand OKCommand
        {
            get;
        }

        public ICommand CancelCommand
        {
            get;
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.ContainsKey("QuestionUrl"))
            {
                QuestionUrl = parameters["QuestionUrl"] as string;
            }
        }
    }
}
