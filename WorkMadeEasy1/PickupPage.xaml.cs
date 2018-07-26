using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Messaging;

using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class PickUpPage : ContentPage
	{
		Label workplace, workday, shift,caid;
		ScheduleManager manager;
		PickupManager pickupmanager;
		string empId;

		public PickUpPage()
		{
			InitializeComponent();
		}

		public PickUpPage(String empid)
		{
			InitializeComponent();
			empId = empid;

			pickupmanager = PickupManager.DefaultManager;
			manager = ScheduleManager.DefaultManager;
			displayPickUpShifts();
		}

		public async void displayPickUpShifts()
		{
			pickuplist.ItemsSource = await pickupmanager.getPickupList();
		}


		public void OnPickup(object s, EventArgs e)
		{
			StackLayout schedule = (StackLayout)s;
			workplace = (Label)schedule.Children[0];
			workday = (Label)schedule.Children[1];
			shift = (Label)schedule.Children[2];
			caid = (Label)schedule.Children[3];

			PickUp pick1 = new PickUp
			{
				Workplace = workplace.Text,
				Day = workday.Text,
				Shift = shift.Text,
				CalloutId=caid.Text
			};

			Schedule newSchedule = new Schedule
			{
				Workplace = workplace.Text,
				Day = workday.Text,
				Shift = shift.Text,
				EmployeeId = empId
			};
			 addSchedule(newSchedule);
			 removePickedUpShift(pick1);

		}

		async Task addSchedule(Schedule schedule)
		{
			bool result = await manager.SaveTaskAsync(schedule);

		}

		async Task removePickedUpShift(PickUp pick1)
		{
			bool result = await pickupmanager.DeleteTaskAsync(pick1);
			if (result == true)
			{
				await DisplayAlert("Congrats", " You Picked Up the shift!", "OK");
				var emailMessenger = CrossMessaging.Current.EmailMessenger;
				if (emailMessenger.CanSendEmail)
				{
					emailMessenger.SendEmail("nhlin@scu.edu", "Pick-up Shift", "I want to pick-up the Shift " + shift.Text + " at " + workplace.Text + " on " + workday.Text + ". Thank You!");
				}
			}
		
		}


	}
}
