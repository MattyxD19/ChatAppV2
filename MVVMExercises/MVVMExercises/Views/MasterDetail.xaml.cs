﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMExercises.Models;
using MVVMExercises.ViewModels;
using System.Reflection;
using MVVMExercises.View;

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
                Text = "Welcome Screen",
                Detail = "Welcome",
                ImagePath = "skeleton.png",
                TargetViewModel = typeof(ContactsView) 
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