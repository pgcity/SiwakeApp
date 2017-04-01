﻿using SiwakeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiwakeApp
{
    public class SiwakeCheck
    {
        public SiwakeCheck(QuestionViewModel viewModel)
        {
            ViewModel = viewModel;
            Check();
        }

        private bool Checked { get; set; }

        // メソッド
        // 採点
        private void Check()
        {
            if (Checked)
            {
                return;
            }

            ResultText = "正解";

            //仕訳の確認
            //いったん全部の仕訳をWrongにする
            foreach(var item in ViewModel.KariList)
            {
                item.KamokuType = SiwakeKamokuViewModel.ItemType.Wrong;
                item.MoneyType = SiwakeKamokuViewModel.ItemType.Wrong;
            }
            foreach (var item in ViewModel.KashiList)
            {
                item.KamokuType = SiwakeKamokuViewModel.ItemType.Wrong;
                item.MoneyType = SiwakeKamokuViewModel.ItemType.Wrong;
            }

            foreach (var correctItem in ViewModel.Question.SiwakeList)
            {
                var targetList = (correctItem.isKari) 
                    ? ViewModel.KariList : ViewModel.KashiList;

                //完全一致アイテム
                var results = from siwake in targetList
                              where siwake.Kamoku == correctItem.Kamoku
                              && siwake.Money == correctItem.Money.ToString()
                              && siwake.KamokuType == SiwakeKamokuViewModel.ItemType.Wrong
                              && siwake.MoneyType == SiwakeKamokuViewModel.ItemType.Wrong
                              select siwake;
                if (results.Any())
                {
                    //見つかった場合
                    foreach(var item in results)
                    {
                        item.KamokuType = SiwakeKamokuViewModel.ItemType.Correct;
                        item.MoneyType = SiwakeKamokuViewModel.ItemType.Correct;
                        break;
                    }
                }
                else
                {
                    //なかった場合は
                    var addItem = new SiwakeKamokuViewModel(
                        correctItem.Kamoku
                        , correctItem.Money.ToString()
                        , ViewModel.OnTextChanged);
                    addItem.KamokuType = SiwakeKamokuViewModel.ItemType.Add;
                    addItem.MoneyType = SiwakeKamokuViewModel.ItemType.Add;
                    targetList.Add(addItem);
                }
            }

            Checked = true;
        }


        //プロパティ
        private QuestionViewModel ViewModel
        {
            get;
            set;
        }
        public string ResultText {
            get; internal set;
        }
    }
}
