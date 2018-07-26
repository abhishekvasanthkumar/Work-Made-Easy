using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Plugin.Messaging;
using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class LPrEmployeePage : ContentPage
	{
		ScheduleManager manager;
		SignupManager signUpManager;
		PickupManager pickupManager;
		String emailid, empId;
		Label workPlace, workDay, shift;
		List<Schedule> schedule;

		public LPrEmployeePage()
		{
			InitializeComponent();
			manager = ScheduleManager.DefaultManager;
		}

		public LPrEmployeePage(String emailid)
		{
			InitializeComponent();
			this.emailid = emailid;
			signUpManager = SignupManager.DefaultManager;
			manager = ScheduleManager.DefaultManager;
			pickupManager = PickupManager.DefaultManager;
			getList();
		}

		private async Task getList()
		{
			empId = await signUpManager.getEmpID(emailid);
			employeeschedule.ItemsSource = await manager.getScheduleList(empId);
		}

		async void OnSchedule(object s, EventArgs e)
		{
			StackLayout schedule = (StackLayout)s;
			workPlace = (Label)schedule.Children[0];
			workDay = (Label)schedule.Children[1];
			shift = (Label)schedule.Children[2];

			PickUp pick = new PickUp
			{
				Workplace = workPlace.Text,
				Day = workDay.Text,
				Shift = shift.Text,
				CalloutId = empId
			};

			Schedule schedule1 = new Schedule
			{
				Workplace = workPlace.Text,
				Day = workDay.Text,
				Shift = shift.Text,
				EmployeeId = empId

			};
			await addshifttoPickup(pick);
			await removeshiftfromschedule(schedule1);

		}

		async Task addshifttoPickup(PickUp item)

		{
			Boolean result = await pickupManager.SaveTaskAsync(item);
			if (result == true)
			{

				var emailMessenger = CrossMessaging.Current.EmailMessenger;
				if (emailMessenger.CanSendEmail)
				{
					emailMessenger.SendEmail("sindukandula@gmail.com", "Call-Out Shift", "I am calling out the Shift " + shift.Text + " at " + workPlace.Text + " on " + workDay.Text + ". Sorry!");
				}
				await DisplayAlert("Alert", "You Called out the shift!", "OK");

			}
			else
			{
				await DisplayAlert("Alert", "Unable to Call-out", "OK");
			}
		}

		async Task removeshiftfromschedule(Schedule item)

		{
			Boolean result = await manager.DeleteTaskAsync(item);
			if (result == true)
			{

				await DisplayAlert("Alert", "Shift Deleted from your schedule!!", "OK");
			}
			else
			{
				await DisplayAlert("Alert", "Unable to delete from schedule", "OK");
			}
		}

	}
}
