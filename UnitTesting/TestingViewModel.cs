using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MVVMExercises;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xunit;
using Xamarin.Forms;

namespace UnitTesting
{
    public class TestingViewModel
    {
        [Fact]
        public void TestAddContact()
        {
            // arrange
            var contact = new MVVMExercises.Models.User() { ID = 5, Username = "Mathias", Password = "Test" };
            var testContact = new MVVMExercises.ViewModels.ContactsTestViewModel();


            // act
            
            testContact.GetUser = contact.Username;
            testContact.AddContact();

            // assert
            Assert.Single(testContact.Users);
        }

        [Fact]
        public void TroubleShooting()
        {
            int a = 5;

            Assert.True(a > 2);
        }

        [Fact]
        public void TestCarCollectionPropertyChanged()
        {
            // arrange
            bool invoked = false;
            var contact = new MVVMExercises.Models.User() { ID = 2, Username = "Mathias1", Password = "Test1" };
            var testContact = new MVVMExercises.ViewModels.ContactsTestViewModel();

            testContact.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName.Equals("Users")) invoked = true;
            };

            // act
            testContact.Users.Add(contact);

            // assert
            Assert.True(invoked);
        }
    }
}