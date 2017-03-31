using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiwakeApp.ViewModels
{
    public class QuestionViewModel : BindableBase
    {
        private void OnTextChanged(object sender, EventArgs e)
        {
            //リストが空の場合
            if (KariList.Count == 0)
            {
                KariList.Add(new SiwakeKamokuViewModel("", "", OnTextChanged));
            }
            else
            {
                //最終アイテムが空でない場合
                if (KariList[KariList.Count - 1].IsFullInput())
                {
                    KariList.Add(new SiwakeKamokuViewModel("", "", OnTextChanged));
                }
                //最終から2番目のアイテムが空の場合
                while (KariList.Count >= 2 && KariList[KariList.Count - 2].IsEmpty())
                {
                    KariList.RemoveAt(KariList.Count - 1);
                }
            }

            //リストが空の場合
            if (KashiList.Count == 0)
            {
                KashiList.Add(new SiwakeKamokuViewModel("", "", OnTextChanged));
            }
            else
            {
                //最終アイテムが空でない場合
                if (KashiList[KashiList.Count - 1].IsFullInput())
                {
                    KashiList.Add(new SiwakeKamokuViewModel("", "", OnTextChanged));
                }
                //最終から2番目のアイテムが空の場合
                while (KashiList.Count >= 2 && KashiList[KashiList.Count - 2].IsEmpty())
                {
                    KashiList.RemoveAt(KashiList.Count - 1);
                }
            }
        }
        public QuestionViewModel(QuestionInfo questionInfo)
        {
            Question = questionInfo;

            KariList = new ObservableCollection<SiwakeKamokuViewModel>();
            KashiList = new ObservableCollection<SiwakeKamokuViewModel>();
            KariList.Add(new SiwakeKamokuViewModel("", "", OnTextChanged));
            KashiList.Add(new SiwakeKamokuViewModel("", "", OnTextChanged));
        }

        public QuestionInfo Question
        {
            get; set;
        }
        public int Number
        {
            get;set;
        }

        public ObservableCollection<SiwakeKamokuViewModel> KariList
        {
            get;set;
        }
        public ObservableCollection<SiwakeKamokuViewModel> KashiList
        {
            get; set;
        }

        private bool answered;
        public bool Answered {
            get
            {
                return answered;
            }
            set
            {
                this.SetProperty(ref this.answered, value);
                AnswerButtonLabel = "";
            }
        }

        private string answerButtonLabel;
        public string AnswerButtonLabel
        {
            get
            {
                return Answered ? "次へ" : "回答";
            }
            set
            {
                this.SetProperty(ref this.answerButtonLabel, value);
            }
        }
    }
}
