using System;
using System.Collections.Generic;
using RestSharp;
using System.Collections.ObjectModel;
using RestSharp.Portable;
using RestSharp.Portable.Authenticators;
using RestSharp.Portable.HttpClient;
using Plugin.Messaging;
using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class OnCallPage : ContentPage
	{
		String workplace, workday, shift;
		SignupManager manager;
		List<Employee> emplist;
		String[] emails;
		int j = 0;

		public OnCallPage()
		{
			InitializeComponent();
		}

		public void OnCallClicked(object s, EventArgs e)
		{
			 workplace = WorkPlaceU.Text;
			workday = WorkDayU.Text;
			shift = shiftU.Text;
			sendOnCall();
			//sendEmail("sindukandula@gmail.com");
		}

		public async void sendOnCall()
		{
			manager = SignupManager.DefaultManager;
			emplist = await manager.getEmails();
			//int c = emplist.Count;
			emails = new String[emplist.Count];
			for (int i = 0; i <emplist.Count;i++)
			{
				
				emails[i] = emplist[i].Email;
			
		    }


				

			var emailMessenger = CrossMessaging.Current.EmailMessenger;
			if (emailMessenger.CanSendEmail)
			{
				// Send simple e-mail to single receiver without attachments, bcc, cc etc.
				//emailMessenger.SendEmail("to.plugins@xamarin.com", "Xamarin Messaging Plugin", "Well hello there from Xam.Messaging.Plugin");

				// Alternatively use EmailBuilder fluent interface to construct more complex e-mail with multiple recipients, bcc, attachments etc. 
				var email = new EmailMessageBuilder()
					.To(emails)
				  .Subject("On-Call Shift")
				  .Body("Shift " + shift + " at " + workplace + " on " + workday + " is available.Please pick up!")
				.Build();

				emailMessenger.SendEmail(email);
			}

		}

		//public static System.Threading.Tasks.Task<IRestResponse> SendSimpleMessage()
		//{
		//	RestClient client = new RestClient();
		//	System.Uri uri= new System.Uri("https://api.mailgun.net/v3");
		//	client.BaseUrl = uri;
		//	client.Authenticator =
		//	new HttpBasicAuthenticator("api",
		//							  "key-aef6e86ad036e0f11a818702e973307c");
		//	RestRequest request = new RestRequest();
		//	request.AddParameter("domain", "sandboxaf76a564d63e49e8a63778033c5a9d4b.mailgun.org", ParameterType.UrlSegment);
		//	request.Resource = "{domain}/messages";
		//	request.AddParameter("from", "skandula@scu.edu");
		//	request.AddParameter("to", "vapatil@scu.edu");
		//	request.AddParameter("subject", "Hello Sindu Kandula");
		//	request.AddParameter("text", "Congratulations Sindu Kandula, you just sent an email with Mailgun!  You are truly awesome!");
		//	request.Method = Method.POST;
		//	var result= client.Execute(request);
		//	return result;
		//	//request.AddParameter("to", "Sindu Kandula <sindukandula@gmail.com>");
		//}

		//private void sendEmail(string email)
		//{
		//	var emailMessenger = CrossMessaging.Current.EmailMessenger;
		//	if (emailMessenger.CanSendEmail)
		//	{
		//		emailMessenger.SendEmail(email,"On-Call Shift","Shift "+shift+" at "+workplace+" on "+workday+" is available. Please pick up!");
		//	}
		//}


	}
}
