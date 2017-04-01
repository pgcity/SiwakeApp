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
        public void OnTextChanged(object sender, EventArgs e)
        {
            UpdateEmptyCell();
        }

        /// <summary>
        /// 空の入力欄を調整する
        /// </summary>
        protected void UpdateEmptyCell()
        {
            //リストが空の場合
            if (KariList.Count == 0)
            {
                KariList.Add(new SiwakeKamokuViewModel("", "", OnTextChanged));
            }
            else
            {
                //空欄追加条件 : 最終アイテムが空でない場合
                if (!Confirmed && KariList[KariList.Count - 1].IsFullInput())
                {
                    KariList.Add(new SiwakeKamokuViewModel("", "", OnTextChanged));
                }
                //空欄削除条件 : 最終から2番目のアイテムが空の場合
                var delIndex = (Confirmed) ? 1 : 2;
                while (KariList.Count >= delIndex && KariList[KariList.Count - delIndex].IsEmpty())
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
                //空欄追加条件 : 最終アイテムが空でない場合
                if (!Confirmed && KashiList[KashiList.Count - 1].IsFullInput())
                {
                    KashiList.Add(new SiwakeKamokuViewModel("", "", OnTextChanged));
                }
                //空欄削除条件 : 最終から2番目のアイテムが空の場合
                var delIndex = (Confirmed) ? 1 : 2;
                while (KashiList.Count >= delIndex && KashiList[KashiList.Count - delIndex].IsEmpty())
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

        public void Confirm()
        {
            if (Confirmed)
            {
                return;
            }
            Confirmed = true;
            UpdateEmptyCell();

            var check = new SiwakeCheck(this);
            ResultText = check.ResultText;


        }

        public QuestionInfo Question
        {
            get; set;
        }
        public int Number
        {
            get;set;
        }

        private string resultText;
        public string ResultText
        {
            get
            {
                return resultText;
            }
            set
            {
                this.SetProperty(ref this.resultText, value);
            }
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

        private bool confirmed;
        public bool Confirmed
        {
            get
            {
                return confirmed;
            }
            set
            {
                this.SetProperty(ref this.confirmed, value);
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
