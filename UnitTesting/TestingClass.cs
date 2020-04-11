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
    public class TestingClass
    {
        [Fact]
        public void TestAddContact()
        {
            // arrange
            var contact = new MVVMExercises.Models.User() { ID = 5, Username = "Martin", Password = "Test" };
            var testContact = new MVVMExercises.ViewModels.ContactsViewModel();


            // act
            testContact.GetUser = contact.Username;
            testContact.AddContact();

            // assert
            Assert.Single(testContact.Users);
        }

        //[Fact]
        //public Command TestAddContact => new Command(async () =>
        //{
        //    // arrange
        //    var contact = new MVVMExercises.Models.User() { ID = 1, Username = "Mathias", Password = "Test" };
        //    var testContact = new MVVMExercises.ViewModels.ContactsViewModel();


        //    // act
        //    testContact.GetUser = contact;
        //    testContact.CreateContactCMD;

        //    // assert
        //    Assert.Single(testContact.Users);
        //});


        /// <summary>
        /// Test if a propertychanged event is fired when a car is added
        /// </summary>
        //[Fact]
        //public void TestCarCollectionPropertyChanged()
        //{
        //    // arrange
        //    bool invoked = false;
        //    var contact = new MVVMExercises.Models.User() { ID = 2, Username = "Mathias1", Password = "Test1" };
        //    var testContact = new MVVMExercises.ViewModels.ContactsViewModel();

        //    testContact.PropertyChanged += (sender, e) =>
        //    {
        //        if (e.PropertyName.Equals("Users")) invoked = true;
        //    };

        //    // act
        //    testContact.Users.Add(contact);


        //    //    var order = await orderService.GetOrderAsync(1, GlobalSetting.Instance.AuthToken);
        //    //await orderViewModel.InitializeAsync(order);

        //    // assert
        //    Assert.True(invoked);
        //}

        /// <summary>
        /// Test the AddCarCanCMD Command
        /// It should only be possible to add up to two cars
        /// </summary>
        /// <param name="noOfCarsToAdd"></param>
        /// <param name="result"></param>
        //[Theory]
        //[InlineData(0, true)]
        //[InlineData(1, true)]
        //[InlineData(3, false)]
        //public void CanAddCarCMD(int noOfCarsToAdd, bool result)
        //{
        //    // arrange
        //    var car = new IcomIvalEx.Model.Car() { Brand = "Ford", Price = 100, Model = "Probe" };
        //    var carDealerVM = new IcomIvalEx.ViewModel.CarDealer();
        //    carDealerVM.InputCar = car;

        //    // act
        //    for (int i = 0; i < noOfCarsToAdd; i++)
        //    {
        //        carDealerVM.AddCar();
        //    }

        //    bool canExecuteVal = (carDealerVM.AddCarCanCMD as Command).CanExecute(null);

        //    // assert
        //    Assert.Equal(result, canExecuteVal);
        //}
    }
}