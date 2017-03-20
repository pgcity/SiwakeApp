using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace SiwakeApp.ViewModels
{
    public class RootPageViewModel : BindableBase
    {
        public ObservableCollection<MenuItem> Menus { get; } = new ObservableCollection<MenuItem>
        {
            new MenuItem
            {
                Title = "問題集1",
                PageName = "StartPage"
            },
            new MenuItem
            {
                Title = "問題集2",
                PageName = "StartPage"
            },
            new MenuItem
            {
                Title = "問題集3",
                PageName = "StartPage"
            },
            new MenuItem
            {
                Title = "問題集4",
                PageName = "StartPage"
            },
        };

        private INavigationService NavigationService { get; }

        private bool isPresented;
        public bool IsPresented
        {
            get { return this.isPresented; }
            set { this.SetProperty(ref this.isPresented, value); }
        }

        private MenuItem selectedItem;
        public MenuItem SelectedItem {
            get { return selectedItem; }
            set { this.SetProperty(ref this.selectedItem, value); }
        }

        public RootPageViewModel(INavigationService navigationService)
        {
            SelectedItem = Menus[0];
            this.NavigationService = navigationService;
        }

        public void PageChange(MenuItem menuItem)
        {
            SelectedItem = menuItem;
            this.IsPresented = false;
        }
    }
}
