using Prism.Navigation;
using SiwakeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SiwakeApp
{

    public class AppearingBehavior : Behavior<Page>
    {
        protected override void OnAttachedTo(Page page)
        {
            page.Appearing += OnAppearing;
            base.OnAttachedTo(page);
        }

        protected override void OnDetachingFrom(Page page)
        {
            page.Unfocused -= OnAppearing;
            base.OnDetachingFrom(page);
        }

        void OnAppearing(object sender, EventArgs args)
        {
            //((sender as Page).BindingContext as INavigationAware)?.OnNavigatedFrom();
        }
    }
}
