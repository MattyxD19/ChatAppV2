using Android.App;
using Android.Widget;
using Android.OS;
using Xunit.Sdk;
using Xunit.Runners.UI;
using System.Reflection;

namespace UnitTesting
{
    [Activity(Label = "UnitTesting", MainLauncher = true)]
    public class MainActivity : RunnerActivity
    {
        //int count = 1;

        protected override void OnCreate(Bundle savedInstanceState)
        {

            // tests can be inside the main assembly
            AddTestAssembly(Assembly.GetExecutingAssembly());

            AddExecutionAssembly(typeof(ExtensibilityPointFactory).Assembly);

            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            //SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            //Button button = FindViewById<Button>(Resource.Id.myButton);

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
        }
    }
}