using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class WmeForgotPassword1Page : ContentPage
	{
		SignupManager manager;
		public WmeForgotPassword1Page()
		{
			InitializeComponent();
			manager = SignupManager.DefaultManager;
		}

		async void getSecurityQuestion(object sender, EventArgs e)
		{
			var user = new Employee { Email = emailEntry.Text };
			List<Employee> items = await manager.checkUserName(user);
			if (items.Count > 0)
			{
				securityQuestion.Placeholder = items[0].SecurityQuestion;
				securityQuestionAnswer.IsEnabled = true;
			}
			else
			{
				await DisplayAlert("Alert", "Username does not exist in our database. Please try again!!", "OK");
			}
		}

		async void OnRecoverPasswordClicked(object sender, EventArgs e)
		{
			var user = new Employee
			{
				Email = emailEntry.Text,
				Answer = securityQuestionAnswer.Text
			};
			List<Employee> items = await manager.checkUserName(user);
			if (items.Count > 0)
			{
				if (user.Answer == items[0].Answer)
				{
					await DisplayAlert("Alert", "Password is : "+ items[0].Password, "OK");
				}
				else
				{
					await DisplayAlert("Alert", "Answer does not match to given answer. Please try again!!", "OK");
				}
			}
		}
	}
}
