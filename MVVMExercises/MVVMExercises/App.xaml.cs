using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MVVMExercises.Views;
using MVVMExercises.Services;
using MVVMExercises.ViewModels;
using System.Threading.Tasks;

namespace MVVMExercises
{
    public partial class App : Application
    {

        ISettingsService _settingsService;
        public App()
        {
            InitializeComponent();

            ServiceContainer.Register<ISettingsService>(() => new SettingsService());
            _settingsService = ServiceContainer.Resolve<ISettingsService>();
            ServiceContainer.Register<INavigationService>(() => new NavigationService(_settingsService));

            var masterDetailViewModel = new MasterDetailViewModel();
            ServiceContainer.Register<MasterDetailViewModel>(() => masterDetailViewModel);
            ServiceContainer.Register<ContactsViewModel>(() => new ContactsViewModel());


            //MainPage = new MainPage();
            var master = new MasterDetail();
            MainPage = master;
            master.BindingContext = masterDetailViewModel;
        }

        private Task InitNavigation()
        {
            var navigationService = ServiceContainer.Resolve<INavigationService>();
            return navigationService.InitializeAsync();
        }

        protected async override void OnStart()
        {
            // Handle when your app starts
            base.OnStart();
            await InitNavigation();
            base.OnResume();
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
