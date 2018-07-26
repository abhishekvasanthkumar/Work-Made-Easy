using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class WmeRegistrationPage : ContentPage
	{
		SignupManager manager;

		public WmeRegistrationPage()
		{
			InitializeComponent();

			manager = SignupManager.DefaultManager;

		}
		async void OnSubmitClicked(object s, EventArgs e)
		{

			var todo = new Employee
			{
				Email = emailU.Text,
				Password = passwordU.Text,
				EId = EidU.Text,
				FirstName = FirstnameU.Text,
				LastName = SecondnameU.Text,
				ContactNumber=phoneNumberU.Text,
				SecurityQuestion = questionU.Text,
				Answer = answerU.Text
			};
			await AddItem(todo);
		}

		async Task AddItem(Employee item)

		{
			Boolean result = await manager.SaveTaskAsync(item);
			if (result == true)
			{
				
				await Navigation.PushAsync(new WmeLoginPage());
				emailU.Text ="";
				passwordU.Text ="";
				questionU.Text ="";
				answerU.Text ="";
			}
			else
			{
				await DisplayAlert("Alert", "Username already exists. Please try different username!", "OK");

			}

		}

	}
}
