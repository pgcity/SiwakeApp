using Prism.Mvvm;
using Prism.Navigation;
using System.Collections.ObjectModel;

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
