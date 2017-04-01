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
    public class QuestionPage2ViewModel : BindableBase, INavigationAware
    {
        public QuestionPage2ViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
            AnswerCommand = new Command(() =>
            {
                OnAnswer();
            });
        }

        //コマンド
        public ICommand AnswerCommand { get; }

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
                    QuestionPageName = SelectedQuestionSet.SetName;
                }
                else
                {
                    QuestionPageName = "トレーニング";
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

        private QuestionViewModel currentQuestionPage;
        public QuestionViewModel CurrentQuestionPage
        {
            get { return currentQuestionPage; }
            set { this.SetProperty(ref this.currentQuestionPage, value); }
        }

        private string questionPageName;
        public string QuestionPageName
        {
            get { return questionPageName; }
            set { this.SetProperty(ref this.questionPageName, value); }
        }
        
        public bool CheckPerQuestion
        {
            get
            {
                return (bool)StartOption["CheckPerQuestion"];
            }
        }
        public Dictionary<string, object> StartOption { get; private set; }


        // 回答
        private void OnAnswer()
        {
            //回答済みにする
            var before = CurrentQuestionPage.Answered;
            CurrentQuestionPage.Answered = true;

            if (CheckPerQuestion)
            {
                CurrentQuestionPage.Confirm();
            }

            //ページ遷移
            if (CheckPerQuestion && before || !CheckPerQuestion)
            {
                if (EnableRightPage())
                {
                    RightPage();
                }
                else
                {
                    GoToResult();
                }
            }
        }


        // カルーセルページ遷移
        public void RightPage()
        {
            int index = CurrentQuestionList.IndexOf(CurrentQuestionPage);
            if (index < CurrentQuestionList.Count - 1)
            {
                CurrentQuestionPage = CurrentQuestionList[index + 1];
            }
        }
        public bool EnableRightPage()
        {
            int index = CurrentQuestionList.IndexOf(CurrentQuestionPage);
            return index < CurrentQuestionList.Count - 1;
        }

        public void LeftPage()
        {
            int index = CurrentQuestionList.IndexOf(CurrentQuestionPage);
            if (index > 0)
            {
                CurrentQuestionPage = CurrentQuestionList[index - 1];
            }
        }
        public bool EnableLeftPage()
        {
            int index = CurrentQuestionList.IndexOf(CurrentQuestionPage);
            return index > 0;
        }

        // ナビゲーション
        public void GoToResult()
        {
            var param = new NavigationParameters();
            param["StartOption"] = StartOption;
            param["CurrentQuestionList"] = CurrentQuestionList;
            param["SelectedQuestionSet"] = SelectedQuestionSet;

            this.NavigationService.NavigateAsync("ResultPage", param);
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {
            if (Device.OS != TargetPlatform.Windows)
            {
                QuestionPageName = SelectedQuestionSet.SetName;
            }
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            CurrentQuestionList = parameters["CurrentQuestionList"] as ObservableCollection<QuestionViewModel>;
            SelectedQuestionSet = parameters["SelectedQuestionSet"] as QuestionSetInfo;
            StartOption = (Dictionary<string, object>)parameters["StartOption"];
        }
    }
}
