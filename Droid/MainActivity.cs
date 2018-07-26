using Android.App;
using Android.Content.PM;
using Android.OS; 

namespace WorkMadeEasy1.Droid
{
	[Activity(Label = "WorkMadeEasy1.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			TabLayoutResource = Resource.Layout.Tabbar;
			ToolbarResource = Resource.Layout.Toolbar;

			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);

			LoadApplication(new App());

		}
	}
}
