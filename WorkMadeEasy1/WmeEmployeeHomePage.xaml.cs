using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class WmeEmployeeHomePage : ContentPage
	{
		SignupManager signUpManager;
		String emailid, empId;
		public WmeEmployeeHomePage()
		{
			InitializeComponent();
			BindingContext = new Model();
			NavigationPage.SetHasNavigationBar(this, false);

		}
		public WmeEmployeeHomePage(String emailU)
		{
			InitializeComponent();

			emailid = emailU;
			signUpManager = SignupManager.DefaultManager;
			Employeeusername.Text = emailid;
			BindingContext = new Model();
			getList();
			NavigationPage.SetHasNavigationBar(this, false);

		}

		private async Task getList()
		{
			empId = await signUpManager.getEmpID(emailid);

		}

		async void OnListClicked(object sender, EventArgs e)
		{
			// handle the tap  
			await Navigation.PushAsync(new SaEmployeePage(emailid));
		}

	
		async void OnPickUpClicked(object s, EventArgs e)
		{
			await Navigation.PushAsync(new PickUpPage(empId));
		}

		async void OnEmployeeLogOutButtonClicked(object s, EventArgs e)
		{
			await Navigation.PushAsync(new WmeLoginPage());
		}

		async void OnRuleClicked(object s, EventArgs e)
		{
			await Navigation.PushAsync(new RulesPage());

		}
	}
}
