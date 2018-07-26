using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class WmeLoginPage : ContentPage
	{
		SignupManager manager;

		public WmeLoginPage()
		{
			InitializeComponent();
			NavigationPage.SetHasNavigationBar(this, false);
			manager = SignupManager.DefaultManager;
		}

		async void OnSignUpClicked(object s, EventArgs e)
		{
			await Navigation.PushAsync(new WmeRegistrationPage());
		}

		async void OnLogInClicked(object sender, EventArgs e)
		{
			var user1 = new User { };
			var user2 = new Employee { };

			if (Persontype.SelectedIndex == 0)
			{
				user1 = new User
				{
					Email = emailU.Text,
					Password = passwordU.Text
				};
				var isValid = AreCredentialsCorrect(user1);

				if (isValid)
				{
					App.IsUserLoggedIn = true;
					await Navigation.PushAsync(new WmeEmployerHomePage(emailU.Text));
				}
				else
				{
					await DisplayAlert("Alert", "Login Failed", "OK");
				}
			}
			if (Persontype.SelectedIndex == 1)
			{
				user2 = new Employee
				{
					Email = emailU.Text,
					Password = passwordU.Text
				};
				await checkItem(user2);
			}


		}

		async Task checkItem(Employee item)

		{
			Boolean result = await manager.CheckTaskAsync(item);
			if (result == true)
			{
				
					await Navigation.PushAsync(new WmeEmployeeHomePage(emailU.Text));
				
			}
			else
			{
				await DisplayAlert("Alert", "Login Failed", "OK");
			}
		}

		bool AreCredentialsCorrect(User user)
		{
			return user.Email == Input.Email && user.Password == Input.Password;
		}                                                                                       

		async void OnForgotPasswordClicked(object s, EventArgs e)
		{
			await Navigation.PushAsync(new WmeForgotPassword1Page());
		}

		async void OnAboutClicked(object s, EventArgs e)
		{
			await Navigation.PushAsync(new AboutPage());
		}

	}
}
