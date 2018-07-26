using System;
using System.Collections.Generic;
using Plugin.Messaging;
using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{
			InitializeComponent();
		}

		 void Callscu(object s, EventArgs e)
		{
			// Make Phone Call
			var phoneDialer = CrossMessaging.Current.PhoneDialer;
			if (phoneDialer.CanMakePhoneCall)
					phoneDialer.MakePhoneCall("+14085544000");

		}

		 void Messagescu(object s, EventArgs e)
		{
			// Send Sms
			var smsMessenger = CrossMessaging.Current.SmsMessenger;
			if (smsMessenger.CanSendSms)
				smsMessenger.SendSms("+14085544000", "Hello I want to contact you!");
		}

		 void Callbonappetit(object s, EventArgs e)
		{
			// Make Phone Call
			var phoneDialer = CrossMessaging.Current.PhoneDialer;
			if (phoneDialer.CanMakePhoneCall)
				phoneDialer.MakePhoneCall("+14085544070");

		}

		void Messagebonappetit(object s, EventArgs e)
		{
			var smsMessenger = CrossMessaging.Current.SmsMessenger;
			if (smsMessenger.CanSendSms)
				smsMessenger.SendSms("+14085544070", "Hello I want to contact you!");
		}

		void Onsculink(object s, EventArgs e)
		{
			Device.OpenUri(new Uri("https://www.scu.edu/aboutscu/"));
		}
		void Ondininglink(object s, EventArgs e)
		{
			Device.OpenUri(new Uri("https://www.scu.edu/auxiliary-services/dining-services/"));
		}

	}
}
