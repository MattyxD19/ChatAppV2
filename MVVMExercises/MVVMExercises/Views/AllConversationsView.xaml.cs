using MVVMExercises.Models;
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
    public partial class AllConversationsView : ContentPage
    {
        public AllConversationsView()
        {
            InitializeComponent();
        }

        private void ConversationList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            

            //IsPresented = false;
        }
    }
}