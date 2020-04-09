using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMExercises.Models;

namespace MVVMExercises.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetail : MasterDetailPage
    {
		public MasterDetail ()
		{
			InitializeComponent ();
            profileImage.Source = ImageSource.FromFile("spider.jpg");

            navigationList.ItemsSource = GetMenuList();

            IsPresented = false;
        }

        public List<MasterMenuItems> GetMenuList()
        {
            var list = new List<MasterMenuItems>();

            list.Add(new MasterMenuItems()
            {
                Text = "Contacts",
                Detail = "Will be completed in iteration 2",
                ImagePath = "",
                TargetViewModel = typeof(ContactsView) 
            });
            list.Add(new MasterMenuItems()
            {
                Text = "All Conversations",
                Detail = "Will be completed in iteration 2",
                ImagePath = "",
                TargetViewModel = typeof(AllConversationsView)
            });
            list.Add(new MasterMenuItems()
            {
                Text = "Current conversation",
                Detail = "Will be completed in iteration 2",
                ImagePath = "",
                TargetViewModel = typeof(ContactsView)
            });

            list.Add(new MasterMenuItems()
            { 
                Text = "Chat with everybody",
                Detail = "",
                ImagePath = "",
                TargetViewModel = typeof(ChatView)
            });

            return list;
        }

        private void OnMenuItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenuItem = (MasterMenuItems)e.SelectedItem;

            var viewModel = (ViewModels.MasterDetailViewModel)this.BindingContext;
            viewModel.ChangeVMCMD.Execute(selectedMenuItem);

            IsPresented = false;
        }
    }
}