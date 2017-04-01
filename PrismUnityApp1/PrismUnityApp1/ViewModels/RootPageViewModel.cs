using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System;
using System.Collections.Generic;
using Prism.Commands;
using System.Windows.Input;

namespace SiwakeApp.ViewModels
{
    public class RootPageViewModel : BindableBase, INavigationAware
    {
        //コンストラクタ
        public RootPageViewModel(INavigationService navigationService)
        {
            this.NavigationService = navigationService;
            Menus = new ObservableCollection<QuestionSetInfo>(QuestionModel.Questions);
        }

        //コマンド

        //プロパティ
        private QuestionModel QuestionModel { get; set; } = new QuestionModel();

        public ObservableCollection<QuestionSetInfo> Menus { get; }

        private INavigationService NavigationService { get; }

        private bool isPresented;
        public bool IsPresented
        {
            get { return this.isPresented; }
            set { this.SetProperty(ref this.isPresented, value); }
        }

        // 選択した問題セット
        private QuestionSetInfo selectedItem;
        public QuestionSetInfo SelectedItem {
            get { return selectedItem; }
            set { this.SetProperty(ref this.selectedItem, value);
                ResetPage();
            }
        }

        public ObservableCollection<QuestionViewModel> CurrentQuestionList { get; set; }

        private QuestionViewModel currentQuestionPage;
        public QuestionViewModel CurrentQuestionPage
        {
            get { return currentQuestionPage; }
            set { this.SetProperty(ref this.currentQuestionPage, value); }
        }

        //結果ページに行けるか
        private bool isResult;
        public bool IsResult
        {
            get { return isResult; }
            set { this.SetProperty(ref this.isResult, value); }
        }

        public object StartOption { get; private set; }

        public void ResetPage()
        {
            //CurrentQuestionPage = CurrentQuestionList[0];
 
        }

        // 問題セット切り替え
        // 問題セットが変更されたときにコードビハインドから呼ばれる
        public void PageChange(QuestionSetInfo menuItem)
        {
            SelectedItem = menuItem;

            var param = new NavigationParameters();
            param["SelectedQuestionSet"] = SelectedItem;
            param["RootPageViewModel"] = this;
            if (StartOption != null)
            {
                param["StartOption"] = StartOption;
            }

            this.NavigationService.NavigateAsync("NavigationPage/StartPage", param);
        }

        // ナビゲーション
        public void OnNavigatedFrom(NavigationParameters parameters)
        {
        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            if (parameters.Count > 0 && !parameters.ContainsKey("PrevPage"))
            {
                return;
            }

            QuestionSetInfo menuItem = null;
            if (parameters.ContainsKey("PrevPage") 
                && parameters["PrevPage"] as string == "ResultPage")
            {
                menuItem = parameters["SelectedQuestionSet"] as QuestionSetInfo;
                StartOption = parameters["StartOption"];
            }

            if(menuItem == null)
            {
                menuItem = Menus[0];
            }
            PageChange(menuItem);
        }
    }
}
