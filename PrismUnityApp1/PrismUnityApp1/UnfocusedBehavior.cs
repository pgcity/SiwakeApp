using SiwakeApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SiwakeApp
{
    public class UnfocusedBehavior : Behavior<Entry>
    {
        protected override void OnAttachedTo(Entry entry)
        {
            entry.Completed += OnCompleted;
            base.OnAttachedTo(entry);
        }

        protected override void OnDetachingFrom(Entry entry)
        {
            entry.Completed -= OnCompleted;
            base.OnDetachingFrom(entry);
        }

        private void OnCompleted(object sender, EventArgs e)
        {
            var vm = (sender as Entry).BindingContext as SiwakeKamokuViewModel;
            vm.OnTextChanged(sender, e);
        }

        void OnEntryTextChanged(object sender, FocusEventArgs args)
        {
            var vm = (sender as Entry).BindingContext as SiwakeKamokuViewModel;
            vm.OnTextChanged(sender, args);
        }
    }
}
