using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WorkMadeEasy1
{
	public partial class SScheulePage : ContentPage
	{
		
		ScheduleManager manager;
		String day, shift;
	

		public SScheulePage()
		{
			InitializeComponent();
			manager = ScheduleManager.DefaultManager;

		}

		async void OnSaveClicked(object s, EventArgs e)
		{

			if (SWorkDayU.SelectedIndex == 0)
			{
				day = "Monday";
			}
			if (SWorkDayU.SelectedIndex == 1)
			{
				day = "Tuesday";
			}
			if (SWorkDayU.SelectedIndex == 2)
			{
				day = "Wednesday";
			}
			if (SWorkDayU.SelectedIndex == 3)
			{
				day = "Thursday";
			}
			if (SWorkDayU.SelectedIndex == 4)
			{
				day = "Friday";
			}

			if (SshiftU.SelectedIndex == 0)
			{
				shift = "Shift1:9:00am to 12:00pm";
			}
			if (SshiftU.SelectedIndex == 1)
			{
				shift = "Shift2:12:00pm to 3:00pm";
			}
			if (SshiftU.SelectedIndex == 2)
			{
				shift = "Shift3:3:00pm to 6:00pm";
			}


			var todo1 = new Schedule
			{

				Workplace = "Saute",
				EmployeeId = SemployeeidU.Text,
				Day = day,
				Shift = shift,

			};
			await AddItem(todo1);
		}

			


		async Task AddItem(Schedule item)

		{
			Boolean result = await manager.SaveTaskAsync(item);
			if (result == true)
			{
				await DisplayAlert("Alert", "Schedule is saved", "OK");

			}
			else
			{
				await DisplayAlert("Alert", "Schedule couldnot save. Please try again!", "OK");

			}


		}

	}
}
