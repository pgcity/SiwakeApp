﻿using Prism.Commands;
using Prism.Mvvm;
using System;

namespace SiwakeApp
{
    public class SiwakeKamokuViewModel : BindableBase
    {
        public enum ItemType
        {
            Normal,
            Correct,
            Wrong,
            Add
        }

        public EventHandler OnTextChanged;

        private string kamoku;
        public string Kamoku
        {
            get { return kamoku; }
            set {
                this.SetProperty(ref this.kamoku, value);
            }
        }

        private string money;
        public string Money
        {
            get { return money; }
            set {
                this.SetProperty(ref this.money, value);
            }
        }

        private ItemType kamokuType = ItemType.Normal;
        public ItemType KamokuType
        {
            get { return kamokuType; }
            set
            {
                this.SetProperty(ref kamokuType, value);
            }
        }

        private ItemType moneyType = ItemType.Normal;
        public ItemType MoneyType
        {
            get { return moneyType; }
            set
            {
                this.SetProperty(ref moneyType, value);
            }
        }

        public SiwakeKamokuViewModel(string kamoku, string money, EventHandler onchange)
        {
            this.Kamoku = kamoku;
            this.Money = money;
            
            this.OnTextChanged += onchange;
        }

        public bool IsEmpty()
        {
            return (Kamoku == "") && (Money == "");
        }

        public bool IsFullInput()
        {
            return (Kamoku != "") && (Money != "");
        }
    }
}