using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace SiwakeApp.ViewModels
{
    public class ResultPageViewModel : BindableBase, INavigationAware
    {
        public ResultPageViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;

            EndCommand = new Command(async () =>
            {
                await GoToFirstAsync();
            });
        }

        //コマンド
        public ICommand EndCommand { get; }

        //プロパティ
        private INavigationService NavigationService { get; }

        private QuestionSetInfo selectedQuestionSet;
        public QuestionSetInfo SelectedQuestionSet
        {
            get
            {
                return selectedQuestionSet;
            }
            set
            {
                this.SetProperty(ref selectedQuestionSet, value);

                if (Device.OS != TargetPlatform.Windows)
                {
                    ResultPageName = SelectedQuestionSet.SetName + " 結果発表";
                }
                else
                {
                    ResultPageName = "結果発表";
                }
            }
        }

        private ObservableCollection<QuestionViewModel> currentQuestionList;
        public ObservableCollection<QuestionViewModel> CurrentQuestionList
        {
            get
            {
                return currentQuestionList;
            }
            set
            {
                this.SetProperty(ref currentQuestionList, value);
            }
        }

        //ページタイトル
        private string resultPageName;
        public string ResultPageName
        {
            get { return resultPageName; }
            set { this.SetProperty(ref this.resultPageName, value); }
        }

        public object StartOption { get; private set; }

        //ナビゲーション
        //最初に戻る
        private async System.Threading.Tasks.Task GoToFirstAsync()
        {
            var param = new NavigationParameters();
            param["SelectedQuestionSet"] = SelectedQuestionSet;
            param["PrevPage"] = "ResultPage";
            param["StartOption"] = StartOption;

            await this.NavigationService.NavigateAsync("/RootPage", param);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            CurrentQuestionList = parameters["CurrentQuestionList"] as ObservableCollection<QuestionViewModel>;
            SelectedQuestionSet = parameters["SelectedQuestionSet"] as QuestionSetInfo;
            StartOption = parameters["StartOption"];

            //全問採点済みにする
            foreach(var question in CurrentQuestionList)
            {
                question.Confirmed = true;
            }
        }



    }
}
