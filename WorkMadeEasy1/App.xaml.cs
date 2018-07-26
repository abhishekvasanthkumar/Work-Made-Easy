using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class App : Application
	{
		public static bool IsUserLoggedIn { get; set; }

		public App()
		{
			InitializeComponent();

			BindingContext = new WmeLoginPage();


			MainPage = new NavigationPage(new WmeSplashPage());
		}

		protected override void OnStart()
		{
			// Handle when your app starts

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
