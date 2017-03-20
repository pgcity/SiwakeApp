using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace SiwakeApp.ViewModels
{
    public class RootPageViewModel : BindableBase
    {
        private QuestionModel QuestionModel { get; set; } = new QuestionModel();

        public ObservableCollection<QuestionSetInfo> Menus { get; }

        private INavigationService NavigationService { get; }

        private bool isPresented;
        public bool IsPresented
        {
            get { return this.isPresented; }
            set { this.SetProperty(ref this.isPresented, value); }
        }

        private QuestionSetInfo selectedItem;
        public QuestionSetInfo SelectedItem {
            get { return selectedItem; }
            set { this.SetProperty(ref this.selectedItem, value);
                CurrentQuestionList = new ObservableCollection<QuestionInfo>(selectedItem.Questions);
                ResetPage();
                if(Device.OS != TargetPlatform.Windows)
                {
                    StartPageName = selectedItem.SetName;
                    QuestionPageName = selectedItem.SetName;
                    ResultPageName = selectedItem.SetName + " 結果発表";
                }
            }
        }
        public ObservableCollection<QuestionInfo> CurrentQuestionList { get; set; }
        private QuestionInfo currentQuestionPage;
        public QuestionInfo CurrentQuestionPage
        {
            get { return currentQuestionPage; }
            set { this.SetProperty(ref this.currentQuestionPage, value); }
        }

        //ページ遷移
        public void ResetPage()
        {
            CurrentQuestionPage = CurrentQuestionList[0];
        }
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

        //ページタイトル
        private string startPageName = "開始";
        public string StartPageName
        {
            get { return startPageName; }
            set { this.SetProperty(ref this.startPageName, value); }
        }

        private string questionPageName = "トレーニング";
        public string QuestionPageName
        {
            get { return questionPageName; }
            set { this.SetProperty(ref this.questionPageName, value); }
        }

        private string resultPageName = "結果発表";
        public string ResultPageName
        {
            get { return resultPageName; }
            set { this.SetProperty(ref this.resultPageName, value); }
        }


        public RootPageViewModel(INavigationService navigationService)
        {
            Menus = QuestionModel.GetQuestionSetList();

            SelectedItem = Menus[0];
            this.NavigationService = navigationService;
        }

        public void PageChange(QuestionSetInfo menuItem)
        {
            SelectedItem = menuItem;
            this.IsPresented = false;
        }
    }
}
