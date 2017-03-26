using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace SiwakeApp.ViewModels
{
    class StartPageViewModel : BindableBase, INavigationAware
    {
        public StartPageViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;

            StartCommand = new Command(async () => {
                GetCurrentQuestionList(SelectedQuestionSet.Questions);

                var navigationParam = new NavigationParameters();
                navigationParam["SelectedQuestionSet"] = SelectedQuestionSet;
                navigationParam["CurrentQuestionList"] = CurrentQuestionList;
                await navigationService.NavigateAsync("QuestionPage2", navigationParam);

                RootViewModel.IsPresented = false;
            });
        }

        // コマンド
        public ICommand StartCommand { get; }

        // プロパティ
        private INavigationService NavigationService { get; }

        // 問題セット
        private QuestionSetInfo selectedQuestionSet;
        public QuestionSetInfo SelectedQuestionSet {
            get
            {
                return selectedQuestionSet;
            }
            set
            {
                this.SetProperty(ref selectedQuestionSet, value);
                selectedQuestionSet = value;

                if (Device.OS != TargetPlatform.Windows)
                {
                    StartPageName = selectedQuestionSet.SetName;
                }
            }
        }

        // ページ名
        private string startPageName = "開始";
        public string StartPageName
        {
            get { return startPageName; }
            set { this.SetProperty(ref this.startPageName, value); }
        }

        public ObservableCollection<QuestionViewModel> CurrentQuestionList { get; private set; }
        public bool? MenuIsPresented { get; private set; }
        public RootPageViewModel RootViewModel { get; private set; }

        // メソッド

        /// <summary>
        /// 問題リストから、問題ページリストを作成
        /// </summary>
        /// <param name="questions"></param>
        private void GetCurrentQuestionList(List<QuestionInfo> questions)
        {
            int cnt = 0;
            CurrentQuestionList = new ObservableCollection<QuestionViewModel>();
            foreach (var question in questions)
            {
                CurrentQuestionList.Add(
                     new QuestionViewModel(question) { Number = ++cnt });
            }
        }

        //ナビゲーション
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            RootViewModel = parameters["RootPageViewModel"] as RootPageViewModel;
            SelectedQuestionSet = parameters["SelectedQuestionSet"] as QuestionSetInfo;
        }
    }
}
