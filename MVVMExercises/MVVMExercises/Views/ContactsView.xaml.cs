using MVVMExercises.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MVVMExercises.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactsView : ContentPage
    {
        public ContactsView()
        {
            InitializeComponent();

        }

        private void ContactList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {

        }

        //private void Button_Clicked(object sender, EventArgs e)
        //{
        //    Button btnTapped = (Button)sender;
        //    ((ContactsViewModel)this.BindingContext).OnButtonClicked(btnTapped);
        //}
    }
}