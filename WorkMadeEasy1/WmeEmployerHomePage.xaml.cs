using System;
using System.Collections.Generic;
using Plugin.Messaging;
using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class WmeEmployerHomePage : ContentPage
	{
		SignupManager manager;
		List<Employee> emplist;
		String[] emails;
		string emailU;

		public WmeEmployerHomePage()
		{
			InitializeComponent();
			BindingContext = new Model();
			NavigationPage.SetHasNavigationBar(this, false);
			//Creating TapGestureRecognizers  
			var tap1Image = new TapGestureRecognizer();
			var tap2Image = new TapGestureRecognizer();
			var tap3Image = new TapGestureRecognizer();
			var tap4Image = new TapGestureRecognizer();
			var tap5Image = new TapGestureRecognizer();
			//Binding events  
			tap1Image.Tapped += tap1Image_Tapped;
			tap2Image.Tapped += tap2Image_Tapped;
			tap3Image.Tapped += tap3Image_Tapped;
			tap4Image.Tapped += tap4Image_Tapped;
			tap5Image.Tapped += tap5Image_Tapped;
			//Associating tap events to the image buttons  
			lprimg.GestureRecognizers.Add(tap1Image);
			brimg.GestureRecognizers.Add(tap2Image);
			srimg.GestureRecognizers.Add(tap3Image);
			drimg.GestureRecognizers.Add(tap4Image);
			crimg.GestureRecognizers.Add(tap5Image);
		}

		public WmeEmployerHomePage(String emailU)
		{
			InitializeComponent();
			this.emailU = emailU;
			BindingContext = new Model();
			NavigationPage.SetHasNavigationBar(this, false);
			//Creating TapGestureRecognizers  
			var tap1Image = new TapGestureRecognizer();
			var tap2Image = new TapGestureRecognizer();
			var tap3Image = new TapGestureRecognizer();
			var tap4Image = new TapGestureRecognizer();
			var tap5Image = new TapGestureRecognizer();
			//Binding events  
			tap1Image.Tapped += tap1Image_Tapped;
			tap2Image.Tapped += tap2Image_Tapped;
			tap3Image.Tapped += tap3Image_Tapped;
			tap4Image.Tapped += tap4Image_Tapped;
			tap5Image.Tapped += tap5Image_Tapped;
			//Associating tap events to the image buttons  
			lprimg.GestureRecognizers.Add(tap1Image);
			brimg.GestureRecognizers.Add(tap2Image);
			srimg.GestureRecognizers.Add(tap3Image);
			drimg.GestureRecognizers.Add(tap4Image);
			crimg.GestureRecognizers.Add(tap5Image);
		}

		async void tap1Image_Tapped(object sender, EventArgs e)
		{
			// handle the tap  
			await Navigation.PushAsync(new LPrSchedulePage());
		}

		async void tap2Image_Tapped(object sender, EventArgs e)
		{
			// handle the tap  
			await Navigation.PushAsync(new BSchedulePage());
		}

		async void tap3Image_Tapped(object sender, EventArgs e)
		{
			// handle the tap  
			await Navigation.PushAsync(new SScheulePage());
		}

		async void tap4Image_Tapped(object sender, EventArgs e)
		{
			// handle the tap  
			await Navigation.PushAsync(new DSchedulePage());
		}

		async void tap5Image_Tapped(object sender, EventArgs e)
		{
			// handle the tap  
			await Navigation.PushAsync(new CSchedulePage());
		}

		async void OnCallClicked(object s, EventArgs e)
		{
			await Navigation.PushAsync(new OnCallPage());
		}

		async void OnNotifyClicked(object s, EventArgs e)
		{
			manager = SignupManager.DefaultManager;
			emplist = await manager.getEmails();
			emails = new String[emplist.Count];
			for (int i = 0; i < emplist.Count; i++)
			{
				
				emails[i] = emplist[i].Email;

			}


			var emailMessenger = CrossMessaging.Current.EmailMessenger;
			if (emailMessenger.CanSendEmail)
			{
				

				// use EmailBuilder fluent interface to construct more complex e-mail with multiple recipients, bcc, attachments etc. 
				var email = new EmailMessageBuilder()
					.To(emails)
				    .Subject("Notification about the schedule")
				    .Body("The latest schedule is updated please check your shifts!")
				    .Build();

				emailMessenger.SendEmail(email);
			}

		
		}

		async void OnEmployerLogOutButtonClicked(object s, EventArgs e)
		{
			await Navigation.PushAsync(new WmeLoginPage());
		}
	}
}
